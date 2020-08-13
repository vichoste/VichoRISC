using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the fourth type of instruction
	/// nop: nop
	/// </summary>
	public sealed class FourthTypeInstruction : Instruction {
		/// <summary>
		/// Creates a fourth type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		public FourthTypeInstruction(string keyword) : base(keyword) {
		}
	}
}
