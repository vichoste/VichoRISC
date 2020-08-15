using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the third type of instruction
	/// ld, st
	/// </summary>
	public sealed class ThirdTypeInstruction : Instruction {
		/// <summary>
		/// First operand
		/// </summary>
		public string FirstOperand { get; private set; }
		/// <summary>
		/// Second operand
		/// </summary>
		public string SecondOperand { get; private set; }
		/// <summary>
		/// Creates a third type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperand">Second operand</param>
		public ThirdTypeInstruction(string keyword, string firstOperand, string secondOperand) : base(keyword) {
			if (!(keyword.Equals(Keywords.Load)
				|| keyword.Equals(Keywords.Store))) {
				throw new ArgumentException("Keyword not valid.");
			}
			if (int.Parse(firstOperand) < 0 || int.Parse(firstOperand) > 15) {
				throw new ArgumentException("Register from first operand is not valid.");
			}
			if (int.Parse(secondOperand) < 0 || int.Parse(secondOperand) > 15) {
				throw new ArgumentException("Register from second operand is not valid.");
			}
			this.FirstOperand = firstOperand;
			this.SecondOperand = secondOperand;
		}
		/// <summary>
		/// Prints to debug
		/// </summary>
		public override void PrintDebug() => System.Diagnostics.Debug.WriteLine($"(i) Third type instruction. Line: {this.LineNumber} - Keyword: {this.Keyword} - 1: r{this.FirstOperand} - 2: [r{this.SecondOperand}] (i)");
	}
}
