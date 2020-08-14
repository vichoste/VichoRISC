using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the first type of instruction
	/// and, sub, mul, div, mod, and, or, lsl, lsr, asr: (\w+ r[0-9]+, r[0-9]+, r[0-9]+)|(\w+ r[0-9]+, r[0-9]+, #[0-9]+)
	/// </summary>
	public sealed class FirstTypeInstruction : Instruction {
		/// <summary>
		/// First operand
		/// </summary>
		public string FirstOperand { get; private set; }
		/// <summary>
		/// Second operand
		/// </summary>
		public string SecondOperand { get; private set; }
		/// <summary>
		/// Third operand
		/// </summary>
		public string ThirdOperand { get; private set; }
		/// <summary>
		/// Determines if the third operand is an immediate value
		/// </summary>
		public bool IsThirdOperandImmediate { get; private set; }
		/// <summary>
		/// Creates a first type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperand">Second operand</param>
		/// <param name="thirdOperandPrefix">Third operand prefix to determine if it's an immediate value</param>
		/// <param name="thirdOperand">Third operand</param>
		public FirstTypeInstruction(string keyword, string firstOperand, string secondOperand, string thirdOperandPrefix, string thirdOperand) : base(keyword) {
			if (!(keyword.Equals(Keywords.Add)
				|| keyword.Equals(Keywords.Substract)
				|| keyword.Equals(Keywords.Multiply)
				|| keyword.Equals(Keywords.Divide)
				|| keyword.Equals(Keywords.Modulo)
				|| keyword.Equals(Keywords.BitwiseAnd)
				|| keyword.Equals(Keywords.BitwiseOr)
				|| keyword.Equals(Keywords.LogicalShiftLeft)
				|| keyword.Equals(Keywords.LogicalShiftRight)
				|| keyword.Equals(Keywords.ArithmeticalShiftRight))) {
				throw new ArgumentException("Keyword not valid.");
			}
			if (int.Parse(firstOperand) < 0 || int.Parse(firstOperand) > 15) {
				throw new ArgumentException("Register from first operand is not valid.");
			}
			if (int.Parse(secondOperand) < 0 || int.Parse(secondOperand) > 15) {
				throw new ArgumentException("Register from second operand is not valid.");
			}
			if (string.Compare(thirdOperandPrefix, "r") == 0 && (int.Parse(thirdOperand) < 0 || int.Parse(thirdOperand) > 15)) {
				throw new ArgumentException("Register from third operand is not valid.");
			}
			this.FirstOperand = firstOperand;
			this.SecondOperand = secondOperand;
			this.ThirdOperand = thirdOperand;
			this.IsThirdOperandImmediate = string.Compare(thirdOperandPrefix, "r") != 0;
		}
		/// <summary>
		/// Prints to debug
		/// </summary>
		public override void PrintDebug() => System.Diagnostics.Debug.WriteLine($"(i) First type instruction. Line: {this.LineNumber} - Keyword: {this.Keyword} - 1: r{this.FirstOperand} - 2: r{this.SecondOperand} - 3: {(this.IsThirdOperandImmediate ? "#" : "r")}{this.ThirdOperand} (i)");
	}
}
