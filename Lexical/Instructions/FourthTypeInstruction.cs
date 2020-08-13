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
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		public FourthTypeInstruction(int lineNumber, string keyword) : base(lineNumber, keyword) {
		}
	}
}
