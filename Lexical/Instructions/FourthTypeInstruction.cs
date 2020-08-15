using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the fourth type of instruction
	/// nop
	/// </summary>
	public sealed class FourthTypeInstruction : Instruction {
		/// <summary>
		/// Creates a fourth type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		public FourthTypeInstruction(string keyword) : base(keyword) {
			if (!keyword.Equals(Keywords.NoOperation)) {
				throw new ArgumentException("Keyword not valid.");
			}
		}
		/// <summary>
		/// Prints to debug
		/// </summary>
		public override void PrintDebug() => System.Diagnostics.Debug.WriteLine($"(i) Fourth type instruction. Line: {this.LineNumber} - Keyword: {this.Keyword} (i)");
	}
}
