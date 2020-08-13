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
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="firstOperand">First operand</param>
		/// <param name="secondOperand">Second operand</param>
		public ThirdTypeInstruction(string keyword, string firstOperand, string secondOperand) : base(keyword) {
			if (!(keyword.Equals(Keywords.Load)
				|| keyword.Equals(Keywords.Store))) {
				throw new ArgumentException("Keyword not valid.");
			}
			this.FirstOperand = firstOperand;
			this.SecondOperand = secondOperand;
		}
	}
}
