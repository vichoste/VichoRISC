using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	public class FirstTypeInstruction : Instruction {
		public string DestinationRegister { get; private set; }
		public string FirstRegister { get; private set; }
		public string SecondRegisterOrImmediate { get; private set; }
		public bool IsSecondRegisterImmediate { get; private set; }
		public FirstTypeInstruction(int lineNumber, string keyword, string destinationRegister, string firstRegister, string secondRegisterPrefix, string secondRegisterOrImmediate) : base(lineNumber, keyword) {
			this.FirstRegister = firstRegister;
			this.DestinationRegister = destinationRegister;
			this.SecondRegisterOrImmediate = secondRegisterOrImmediate;
			this.IsSecondRegisterImmediate = string.Compare(secondRegisterPrefix, "r") != 0;
		}
	}
}
