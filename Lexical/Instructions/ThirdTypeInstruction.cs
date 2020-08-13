using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the third type of instruction
	/// ld, st: (ld|st) r[0-9]+, \[r[0-9]+\]
	/// </summary>
	public sealed class ThirdTypeInstruction : Instruction {
		/// <summary>
		/// Operand used as destination
		/// </summary>
		public string Destination { get; private set; }
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
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="destination">Destination register</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperand">Second operand</param>
		public ThirdTypeInstruction(int lineNumber, string keyword, string destination, string firstOperand, string secondOperand) : base(lineNumber, keyword) {
			this.FirstOperand = firstOperand;
			this.Destination = destination;
			this.SecondOperand = secondOperand;
		}
	}
}
