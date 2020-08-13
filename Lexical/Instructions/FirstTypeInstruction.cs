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
	public sealed class FirstTypeInstruction : Instruction {
		/// <summary>
		/// First operand
		/// </summary>
		public string FirstOperand { get; private set; }
		/// <summary>
		/// Second operand
		/// </summary>
		public string SecondOperand { get; private set; }
		/// <summary>
		/// Third operand
		/// </summary>
		public string ThirdOperand { get; private set; }
		/// <summary>
		/// Determines if the third operand is an immediate value
		/// </summary>
		public bool IsThirdOperandImmediate { get; private set; }
		/// <summary>
		/// Creates a first type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperand">Second operand</param>
		/// <param name="thirdOperandPrefix">Third operand prefix to determine if it's an immediate value</param>
		/// <param name="thirdOperand">Third operand</param>
		public FirstTypeInstruction(string keyword, string firstOperand, string secondOperand, string thirdOperandPrefix, string thirdOperand) : base(keyword) {
			this.FirstOperand = firstOperand;
			this.ThirdOperand = thirdOperand;
			this.IsThirdOperandImmediate = string.Compare(thirdOperandPrefix, "r") != 0;
		}
	}
}
