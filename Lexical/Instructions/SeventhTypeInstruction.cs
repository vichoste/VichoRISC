using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical.Instructions {
	/// <summary>
	/// Defines the seventh type of instruction
	/// label: \w+:
	/// </summary>
	public sealed class SeventhTypeInstruction : Instruction {
		/// <summary>
		/// Operand
		/// </summary>
		public string Operand { get; private set; }
		/// <summary>
		/// Creates a seventh type instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		/// <param name="operand">Operand</param>
		public SeventhTypeInstruction(string keyword, string operand) : base(keyword) => this.Operand = operand;
	}
}
