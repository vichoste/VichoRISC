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
		public int LineNumber { get; private set; }
		/// <summary>
		/// Instruction keyword
		/// </summary>
		public string Keyword { get; private set; }
		/// <summary>
		/// Creates an instruction
		/// </summary>
		/// <param name="lineNumber">Instruction order</param>
		/// <param name="keyword">Instruction keyword</param>
		public Instruction(int lineNumber, string keyword) {
			this.Keyword = keyword;
			this.LineNumber = lineNumber;
		}
	}
}
