using System;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the fourth type of instruction
	/// nop, ret: nop, ret
	/// </summary>
	public sealed class FourthTypeInstruction : Instruction {
		/// <summary>
		/// Creates a fourth type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		public FourthTypeInstruction(string keyword) : base(keyword) {
			if (!(keyword.Equals(Keywords.NoOperation)
				|| keyword.Equals(Keywords.Return))) {
				throw new ArgumentException("Keyword not valid.");
			}
		}
	}
}
