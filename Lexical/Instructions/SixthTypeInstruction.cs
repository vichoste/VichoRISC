using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the sixth type of instruction
	/// label: \w+:
	/// </summary>
	public sealed class SixthTypeInstruction : Instruction {
		/// <summary>
		/// Operand
		/// </summary>
		public string Operand { get; private set; }
		/// <summary>
		/// Creates a sixth type instruction
		/// </summary>
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="operand">Operand</param>
		public SixthTypeInstruction(int lineNumber, string keyword, string operand) : base(lineNumber, keyword) => this.Operand = operand;
	}
}
