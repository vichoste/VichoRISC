using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical {
	/// <summary>
	/// Holds the instruction
	/// </summary>
	public class Instruction {
		/// <summary>
		/// Instruction order
		/// </summary>
		public int LineNumber { get; set; }
		/// <summary>
		/// Instruction keyword
		/// </summary>
		public string Keyword { get; private set; }
		/// <summary>
		/// Creates an instruction
		/// </summary>
		/// <param name="keyword">Instruction keyword</param>
		public Instruction(string keyword) => this.Keyword = keyword;
	}
}
