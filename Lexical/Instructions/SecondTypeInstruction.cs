using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the second type of instruction
	/// mov, not, ld (no pointer), st (no pointer): ((mov|not) r[0-9]+, r[0-9]+)|((mov|not) r[0-9]+, #[0-9]+)
	/// </summary>
	public sealed class SecondTypeInstruction : Instruction {
		/// <summary>
		/// First operand
		/// </summary>
		public string FirstOperand { get; private set; }
		/// <summary>
		/// Second operand
		/// </summary>
		public string SecondOperand { get; private set; }
		/// <summary>
		/// Determines if the second operand is an immediate value
		/// </summary>
		public bool IsSecondOperandImmediate { get; private set; }
		/// <summary>
		/// Determines if the second operand is negative
		/// </summary>
		public bool IsSecondOperandNegative { get; private set; }
		/// <summary>
		/// Creates a second type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperandPrefix">Second operand prefix to determine if it's an immediate value</param>
		/// <param name="secondOperand">Second operand</param>
		public SecondTypeInstruction(string keyword, string firstOperand, string secondOperandPrefix, string negativeSign, string secondOperand) : base(keyword) {
			if (!(keyword.Equals(Keywords.Move)
				|| keyword.Equals(Keywords.BitwiseNot)
				|| keyword.Equals(Keywords.Load)
				|| keyword.Equals(Keywords.Store))) {
				throw new ArgumentException("Keyword not valid.");
			}
			if (int.Parse(firstOperand) < 0 || int.Parse(firstOperand) > 15) {
				throw new ArgumentException("Register from first operand is not valid.");
			}
			if (string.Compare(secondOperandPrefix, "r") == 0 && (int.Parse(secondOperand) < 0 || int.Parse(secondOperand) > 15)) {
				throw new ArgumentException("Register from second operand is not valid.");
			}
			this.FirstOperand = firstOperand;
			this.SecondOperand = secondOperand;
			this.IsSecondOperandImmediate = string.Compare(secondOperandPrefix, "r") != 0;
			this.IsSecondOperandNegative = string.Compare(negativeSign, "-") == 0;
		}
		/// <summary>
		/// Prints to debug
		/// </summary>
		public override void PrintDebug() => System.Diagnostics.Debug.WriteLine($"(i) Second type instruction. Line: {this.LineNumber} - Keyword: {this.Keyword} - 1: r{this.FirstOperand} - 2: {(this.IsSecondOperandImmediate ? "#" : "r")}{(this.IsSecondOperandNegative ? "-" : string.Empty)}{this.SecondOperand} (i)");
	}
}
