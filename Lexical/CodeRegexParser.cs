using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical {
	/// <summary>
	/// Parses the input code via regex
	/// </summary>
	public class CodeRegexParser {
		#region Parsers
		/// <summary>
		/// Parser for: and, sub, mul, div, mod, and, or, lsl, lsr, asr: (\w+ r[0-9]+, r[0-9]+, r[0-9]+)|(\w+ r[0-9]+, r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<string> _FirstType = from instruction in Parse.LetterOrDigit.Many().Text()
															from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
															from firstPrefix in Parse.Char('r').Once().Text()
															from firstInputNumber in Parse.Number
															from firstComma in Parse.Char(',').Once().Text()
															from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
															from secondPrefix in Parse.Char('r').Once().Text()
															from secondInputNumber in Parse.Number
															from secondComma in Parse.Char(',').Once().Text()
															from thirdWhiteSpace in Parse.WhiteSpace.Many().Text()
															from thirdPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
															from thirdInputNumber in Parse.Number
															select instruction.Trim() + firstInputNumber.Trim() + secondInputNumber.Trim() + thirdPrefix.Trim() + thirdInputNumber.Trim();
		/// <summary>
		/// Parser for: mov, not: ((mov|not) r[0-9]+, r[0-9]+)|((mov|not) r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<string> _SecondType = from instruction in Parse.LetterOrDigit.Many().Text()
															 from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
															 from firstPrefix in Parse.Char('r').Once().Text()
															 from firstInputNumber in Parse.Number
															 from firstComma in Parse.Char(',').Once().Text()
															 from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
															 from secondPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
															 from secondInputNumber in Parse.Number
															 select instruction.Trim() + firstInputNumber.Trim() + secondPrefix.Trim() + secondInputNumber.Trim();
		/// <summary>
		/// Parser for: ld, st: ((ld|st) r[0-9]+, #[0-9]+)|((ld|st) r[0-9]+, r[0-9]+)
		/// </summary>
		private static readonly Parser<string> _ThirdType = from instruction in Parse.LetterOrDigit.Many().Text()
															from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
															from firstPrefix in Parse.Char('r').Once().Text()
															from firstInputNumber in Parse.Number
															from firstComma in Parse.Char(',').Once().Text()
															from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
															from secondPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
															from secondInputNumber in Parse.Number
															select instruction.Trim() + firstInputNumber.Trim() + secondPrefix.Trim() + secondInputNumber.Trim();
		/// <summary>
		/// Parser for ld, st: (ld|st) r[0-9]+, \[r[0-9]+\]
		/// </summary>
		private static readonly Parser<string> _FourthType = from instruction in Parse.LetterOrDigit.Many().Text()
															 from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
															 from firstPrefix in Parse.Char('r').Once().Text()
															 from firstInputNumber in Parse.Number
															 from firstComma in Parse.Char(',').Once().Text()
															 from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
															 from startPointer in Parse.Char('[').Once().Text()
															 from secondPrefix in Parse.Char('r').Once().Text()
															 from secondInputNumber in Parse.Number
															 from endPointer in Parse.Char(']').Once().Text()
															 select instruction.Trim() + firstInputNumber.Trim() + startPointer.Trim() + secondPrefix.Trim() + secondInputNumber.Trim() + endPointer.Trim();
		/// <summary>
		/// Parser for nop: nop
		/// </summary>
		private static readonly Parser<string> _FifthType = from instruction in Parse.LetterOrDigit.Many().Text()
															select instruction.Trim();
		/// <summary>
		/// Parser for beq, bgt, b, call: (beq|bgt|b|call) \w+
		/// </summary>
		private static readonly Parser<string> _SixthType = from instruction in Parse.LetterOrDigit.Many().Text()
															from whiteSpace in Parse.WhiteSpace.Many().Text()
															from label in Parse.LetterOrDigit.Many().Text()
															select instruction.Trim() + label.Trim();
		/// <summary>
		/// Parser for comment: @\w+
		/// </summary>
		private static readonly Parser<string> _SeventhType = from symbol in Parse.Char('@').Once().Text()
															  from comment in Parse.LetterOrDigit.Or(Parse.WhiteSpace).Many().Text()
															  select symbol.Trim() + comment.Trim();
		/// <summary>
		/// Parser for label: \w+:
		/// </summary>
		private static readonly Parser<string> _EightType = from label in Parse.LetterOrDigit.Or(Parse.WhiteSpace).Many().Text()
															from symbol in Parse.Char(':').Once().Text()
															select label.Trim() + symbol.Trim();

		#endregion
		private List<Instruction> _Instructions;
		public CodeRegexParser() => this._Instructions = new List<Instruction>();
		public bool AddLine(int lineNumber, string line) {
			var detectedInput = string.Empty;
			if (line.Contains(Keyword.Add)
				|| line.Contains(Keyword.Substract)
				|| line.Contains(Keyword.Multiply)
				|| line.Contains(Keyword.Divide)
				|| line.Contains(Keyword.Modulo)
				|| line.Contains(Keyword.BitwiseAnd)
				|| line.Contains(Keyword.BitwiseOr)
				|| line.Contains(Keyword.LogicalShiftLeft)
				|| line.Contains(Keyword.LogicalShiftRight)
				|| line.Contains(Keyword.ArithmeticalShiftRight)) { // and, sub, mul, div, mod, and, or, lsl, lsr, asr
				detectedInput = _FirstType.Parse(line);
			} else if (line.Contains(Keyword.Move)
				|| line.Contains(Keyword.BitwiseNot)) { // mov, not
				detectedInput = _SecondType.Parse(line);
			} else if (line.Contains(Keyword.Load)
				|| line.Contains(Keyword.Store)) { // ld, st: ((ld|st) r[0-9]+, #[0-9]+)|((ld|st) r[0-9]+, r[0-9]+)|((ld|st) r[0-9]+, \[r[0-9]+\])
				detectedInput = line.Contains('[') && line.Contains(']') ? _FourthType.Parse(line) : _ThirdType.Parse(line);
			} else if (line.Contains(Keyword.NoOperation)) {
				detectedInput = _FifthType.Parse(line);
			} else if (line.Contains(Keyword.Branch) || line.Contains(Keyword.BranchEqual) || line.Contains(Keyword.BranchGreaterThan) || line.Contains(Keyword.Call)) {
				detectedInput = _SixthType.Parse(line);
			} else if (line.Contains(Keyword.Comment)) { // Comment: @\w+
				detectedInput = _SeventhType.Parse(line);
			} else if (line.Contains(Keyword.Label)) { // Label: \w+:
				detectedInput = _EightType.Parse(line);
			} else { // It's not a keyword
				return false;
			}
			return true;
		}
	}
}
