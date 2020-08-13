using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the first type of instruction
	/// mov, not: ((mov|not) r[0-9]+, r[0-9]+)|((mov|not) r[0-9]+, #[0-9]+)
	/// </summary>
	public class SecondTypeInstruction : Instruction {
		/// <summary>
		/// Regiser for storing the result
		/// </summary>
		public string DestinationRegister { get; private set; }
		/// <summary>
		/// First operand
		/// </summary>
		public string FirstRegister { get; private set; }
		/// <summary>
		/// Second operand
		/// </summary>
		public string SecondRegisterOrImmediate { get; private set; }
		/// <summary>
		/// Determines if the second operand is an immediate value
		/// </summary>
		public bool IsSecondRegisterImmediate { get; private set; }
		/// <summary>
		/// Creates a first type instruction
		/// </summary>
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="destinationRegister">Destination register</param>
		/// <param name="firstRegister">First operand</param>
		/// <param name="secondRegisterPrefix">Second operand prefix to determine if it's an immediate value</param>
		/// <param name="secondRegisterOrImmediate">Second operand</param>
		public SecondTypeInstruction(int lineNumber, string keyword, string destinationRegister, string firstRegister, string secondRegisterPrefix, string secondRegisterOrImmediate) : base(lineNumber, keyword) {
			this.FirstRegister = firstRegister;
			this.DestinationRegister = destinationRegister;
			this.SecondRegisterOrImmediate = secondRegisterOrImmediate;
			this.IsSecondRegisterImmediate = string.Compare(secondRegisterPrefix, "r") != 0;
		}
	}
}
