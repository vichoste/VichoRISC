using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the fifth type of instruction
	/// beq, bgt, b: (beq|bgt|b) \w+
	/// </summary>
	public sealed class FifthTypeInstruction : Instruction {
		/// <summary>
		/// Operand
		/// </summary>
		public string Operand { get; private set; }
		/// <summary>
		/// Creates a fifth type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="operand">Operand</param>
		public FifthTypeInstruction(string keyword, string operand) : base(keyword) {
			if (!(keyword.Equals(Keywords.BranchEqual)
				|| keyword.Equals(Keywords.BranchGreaterThan)
				|| keyword.Equals(Keywords.Branch))) {
				throw new ArgumentException("Keyword not valid.");
			}
			this.Operand = operand;
		}
		/// <summary>
		/// Prints to debug
		/// </summary>
		public override void PrintDebug() => System.Diagnostics.Debug.WriteLine($"(i) Fifth type instruction. Line: {this.LineNumber} - Keyword: {this.Keyword} - 1: {this.Operand} (i)");
	}
}
