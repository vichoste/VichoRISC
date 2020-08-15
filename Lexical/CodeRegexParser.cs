using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Shapes;
using VichoRISC.Lexical.Instructions;

namespace VichoRISC.Lexical {
	/// <summary>
	/// Parses the input code via regex
	/// </summary>
	public sealed class CodeRegexParser {
		#region Parsers
		/// <summary>
		/// Parser for: and, sub, mul, div, mod, and, or, lsl, lsr, asr: (\w+ r[0-9]+, r[0-9]+, r[0-9]+)|(\w+ r[0-9]+, r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<FirstTypeInstruction> _FirstType = from instruction in Parse.LetterOrDigit.Many().Text()
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
																		  from negativeSign in Parse.String("-").Text().Optional()
																		  from thirdInputNumber in Parse.Number
																		  select new FirstTypeInstruction(instruction.Trim(), firstInputNumber.Trim(), secondInputNumber.Trim(), thirdPrefix.Trim(), !negativeSign.IsDefined ? string.Empty : negativeSign.Get().Trim(), thirdInputNumber.Trim());
		/// <summary>
		/// Parser for: mov, not, ld (no pointer), st, cmp (no pointer): ((mov|not) r[0-9]+, r[0-9]+)|((mov|not) r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<SecondTypeInstruction> _SecondType = from instruction in Parse.LetterOrDigit.Many().Text()
																			from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
																			from firstPrefix in Parse.Char('r').Once().Text()
																			from firstInputNumber in Parse.Number
																			from firstComma in Parse.Char(',').Once().Text()
																			from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
																			from secondPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
																			from negativeSign in Parse.String("-").Text().Optional()
																			from secondInputNumber in Parse.Number
																			select new SecondTypeInstruction(instruction.Trim(), firstInputNumber.Trim(), secondPrefix.Trim(), !negativeSign.IsDefined ? string.Empty : negativeSign.Get().Trim(), secondInputNumber.Trim());
		/// <summary>
		/// Parser for ld, st: (ld|st) r[0-9]+, \[r[0-9]+\]
		/// </summary>
		private static readonly Parser<ThirdTypeInstruction> _ThirdType = from instruction in Parse.LetterOrDigit.Many().Text()
																		  from firstWhiteSpace in Parse.WhiteSpace.Many().Text()
																		  from firstPrefix in Parse.Char('r').Once().Text()
																		  from firstInputNumber in Parse.Number
																		  from firstComma in Parse.Char(',').Once().Text()
																		  from secondWhiteSpace in Parse.WhiteSpace.Many().Text()
																		  from startPointer in Parse.Char('[').Once().Text()
																		  from secondPrefix in Parse.Char('r').Once().Text()
																		  from secondInputNumber in Parse.Number
																		  from endPointer in Parse.Char(']').Once().Text()
																		  select new ThirdTypeInstruction(instruction.Trim(), firstInputNumber.Trim(), secondInputNumber.Trim());
		/// <summary>
		/// Parser for nop, ret: nop, ret
		/// </summary>
		private static readonly Parser<FourthTypeInstruction> _FourthType = from instruction in Parse.LetterOrDigit.Many().Text()
																			select new FourthTypeInstruction(instruction);
		/// <summary>
		/// Parser for beq, bgt, b, call: (beq|bgt|b|call) \w+
		/// </summary>
		private static readonly Parser<FifthTypeInstruction> _FifthType = from instruction in Parse.LetterOrDigit.Many().Text()
																		  from whiteSpace in Parse.WhiteSpace.Many().Text()
																		  from label in Parse.LetterOrDigit.Many().Text()
																		  select new FifthTypeInstruction(instruction.Trim(), label.Trim());
		/// <summary>
		/// Parser for comment: @\w+
		/// </summary>
		private static readonly Parser<SixthTypeInstruction> _SixthType = from symbol in Parse.Char('@').Once().Text()
																		  from comment in Parse.LetterOrDigit.Or(Parse.WhiteSpace).Many().Text()
																		  select new SixthTypeInstruction(symbol.Trim(), comment.Trim());
		/// <summary>
		/// Parser for label: \w+:
		/// </summary>
		private static readonly Parser<SeventhTypeInstruction> _SeventhType = from label in Parse.LetterOrDigit.Many().Text()
																			 from symbol in Parse.Char(':').Once().Text()
																			 select new SeventhTypeInstruction(symbol.Trim(), label.Trim());

		#endregion
		/// <summary>
		/// List containing the instructions
		/// </summary>
		private readonly List<Instruction> _Instructions;
		/// <summary>
		/// Gets an instruction from the list
		/// </summary>
		/// <param name="lineNumber">Desired line</param>
		/// <returns>Instruction on the specified line</returns>
		public Instruction this[int lineNumber] => this._Instructions[lineNumber];
		/// <summary>
		/// Gets the amount of instructions inside this sturcture
		/// </summary>
		public int Count => this._Instructions.Count;
		/// <summary>
		/// Holds the label list
		/// </summary>
		public List<string> _Labels;
		/// <summary>
		/// Creates a regex code parser
		/// </summary>
		public CodeRegexParser() {
			this._Instructions = new List<Instruction>();
			this._Labels = new List<string>();
		}
		/// <summary>
		/// Adds a line into the list
		/// </summary>
		/// <param name="lineNumber">Line order</param>
		/// <param name="line">Line content</param>
		/// <returns>True if the line is valid and added successfuly into the list</returns>
		public bool AddLine(int lineNumber, string line) {
			Instruction detectedInstruction;
			if (line.StartsWith(Keywords.Add)
				|| line.StartsWith(Keywords.Substract)
				|| line.StartsWith(Keywords.Multiply)
				|| line.StartsWith(Keywords.Divide)
				|| line.StartsWith(Keywords.Modulo)
				|| line.StartsWith(Keywords.BitwiseAnd)
				|| line.StartsWith(Keywords.BitwiseOr)
				|| line.StartsWith(Keywords.LogicalShiftLeft)
				|| line.StartsWith(Keywords.LogicalShiftRight)
				|| line.StartsWith(Keywords.ArithmeticalShiftRight)) { // and, sub, mul, div, mod, and, or, lsl, lsr, asr
				detectedInstruction = _FirstType.Parse(line);
			} else if (line.StartsWith(Keywords.Move)
				|| line.StartsWith(Keywords.BitwiseNot)
				|| line.StartsWith(Keywords.Compare)) { // mov, not
				detectedInstruction = _SecondType.Parse(line);
			} else if (line.StartsWith(Keywords.Load)
				|| line.StartsWith(Keywords.Store)) { // ld, st: ((ld|st) r[0-9]+, #[0-9]+)|((ld|st) r[0-9]+, r[0-9]+)|((ld|st) r[0-9]+, \[r[0-9]+\])
				detectedInstruction = line.Contains('[') && line.Contains(']') ? _ThirdType.Parse(line) : _SecondType.Parse(line) as Instruction;
			} else if (line.StartsWith(Keywords.NoOperation)
				|| line.StartsWith(Keywords.Return)) {
				detectedInstruction = _FourthType.Parse(line);
			} else if (line.StartsWith(Keywords.Branch)
				|| line.StartsWith(Keywords.BranchEqual)
				|| line.StartsWith(Keywords.BranchGreaterThan)
				|| line.StartsWith(Keywords.Call)) {
				detectedInstruction = _FifthType.Parse(line);
			} else if (line.StartsWith(Keywords.Comment)) { // Comment: @\w+
				detectedInstruction = _SixthType.Parse(line);
			} else if (line.Contains(Keywords.Label)) { // Label: \w+:
				detectedInstruction = _SeventhType.Parse(line);
				var detectedLabel = detectedInstruction as SeventhTypeInstruction;
				if (this._Labels.Contains(detectedLabel.Operand)) {
					throw new ArgumentException("Label already exists");
				}
				this._Labels.Add(detectedLabel.Operand);
			} else { // It's not a keyword
				return false;
			}
			detectedInstruction.LineNumber = lineNumber;
			this._Instructions.Add(detectedInstruction);
			return true;
		}
		/// <summary>
		/// Finds the line where the label is
		/// </summary>
		/// <param name="label">Label to find its line</param>
		/// <returns>Line number</returns>
		public int FindLine(string label) {
			var line = -1;
			foreach (var instruction in this._Instructions) {
				if (instruction is SeventhTypeInstruction seventhTypeInstruction) {
					if (seventhTypeInstruction.Operand.Equals(label)) {
						line = seventhTypeInstruction.LineNumber;
						break;
					}
				}
			}
			return line;
		}
	}
}
