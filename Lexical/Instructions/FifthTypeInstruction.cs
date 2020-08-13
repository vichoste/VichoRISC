using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the fifth type of instruction
	/// beq, bgt, b, call: (beq|bgt|b|call) \w+
	/// </summary>
	public sealed class FifthTypeInstruction : Instruction {
		/// <summary>
		/// Operand
		/// </summary>
		public string Operand { get; private set; }
		/// <summary>
		/// Creates a fifth type instruction
		/// </summary>
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="operand">Operand</param>
		public FifthTypeInstruction(int lineNumber, string keyword, string operand) : base(lineNumber, keyword) => this.Operand = operand;
	}
}
