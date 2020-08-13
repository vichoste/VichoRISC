using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the first type of instruction
	/// mov, not: ld, st: ((ld|st) r[0-9]+, #[0-9]+)|((ld|st) r[0-9]+, r[0-9]+)
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
		/// Determines if the second operand is an immediate value
		/// </summary>
		public bool IsSecondOperandImmediate { get; private set; }
		/// <summary>
		/// Creates a first type instruction
		/// </summary>
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="destination">Destination register</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperandPrefix">Second operand prefix to determine if it's an immediate value</param>
		/// <param name="secondOperand">Second operand</param>
		public ThirdTypeInstruction(int lineNumber, string keyword, string destination, string firstOperand, string secondOperandPrefix, string secondOperand) : base(lineNumber, keyword) {
			this.FirstOperand = firstOperand;
			this.Destination = destination;
			this.SecondOperand = secondOperand;
			this.IsSecondOperandImmediate = string.Compare(secondOperandPrefix, "r") != 0;
		}
	}
}
