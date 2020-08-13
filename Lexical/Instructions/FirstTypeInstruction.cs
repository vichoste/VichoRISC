using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the first type of instruction
	/// and, sub, mul, div, mod, and, or, lsl, lsr, asr: (\w+ r[0-9]+, r[0-9]+, r[0-9]+)|(\w+ r[0-9]+, r[0-9]+, #[0-9]+)
	/// </summary>
	public class FirstTypeInstruction : Instruction {
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
		public string SecondRegister { get; private set; }
		/// <summary>
		/// Third operand
		/// </summary>
		public string ThirdRegisterOrImmediate { get; private set; }
		/// <summary>
		/// Determines if the third operand is an immediate value
		/// </summary>
		public bool IsThirdRegisterImmediate { get; private set; }
		/// <summary>
		/// Creates a first type instruction
		/// </summary>
		/// <param name="lineNumber">Line number</param>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="destinationRegister">Destination register</param>
		/// <param name="firstRegister">First operand</param>
		/// <param name="secondRegister">Second operand</param>
		/// <param name="thirdRegisterPrefix">Third operand prefix to determine if it's an immediate value</param>
		/// <param name="thirdRegisterOrImmediate">Third operand</param>
		public FirstTypeInstruction(int lineNumber, string keyword, string destinationRegister, string firstRegister, string secondRegister, string thirdRegisterPrefix, string thirdRegisterOrImmediate) : base(lineNumber, keyword) {
			this.FirstRegister = firstRegister;
			this.DestinationRegister = destinationRegister;
			this.ThirdRegisterOrImmediate = thirdRegisterOrImmediate;
			this.IsThirdRegisterImmediate = string.Compare(thirdRegisterPrefix, "r") != 0;
		}
	}
}
