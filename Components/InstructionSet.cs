using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public partial class Cpu {
		/// <summary>
		/// Defines the instruction set of RISC
		/// </summary>
		public enum InstructionSet {
			/// <summary>
			/// Addition
			/// </summary>
			Add,
			/// <summary>
			/// Substraction
			/// </summary>
			Sub,
			/// <summary>
			/// Multiplication
			/// </summary>
			Mul,
			/// <summary>
			/// Division
			/// </summary>
			Div,
			/// <summary>
			/// Modulo
			/// </summary>
			Mod,
			/// <summary>
			/// Comparison
			/// </summary>
			Cmp,
			/// <summary>
			/// Bitwise AND
			/// </summary>
			And,
			/// <summary>
			/// Bitwise OR
			/// </summary>
			Or,
			/// <summary>
			/// Bitwise NOT
			/// </summary>
			Not,
			/// <summary>
			/// Move data
			/// </summary>
			Mov,
			/// <summary>
			/// Logical left shift
			/// </summary>
			Lsl,
			/// <summary>
			/// Logical right shift
			/// </summary>
			Lsr,
			/// <summary>
			/// Arithmetical right shift
			/// </summary>
			Asr,
			/// <summary>
			/// No operation
			/// </summary>
			Nop,
			/// <summary>
			/// Load from memory
			/// </summary>
			Ld,
			/// <summary>
			/// Store in memory
			/// </summary>
			St,
			/// <summary>
			/// Branch equal
			/// </summary>
			Beq,
			/// <summary>
			/// Branch great than
			/// </summary>
			Bgt,
			/// <summary>
			/// Branch
			/// </summary>
			B,
			/// <summary>
			/// Call procedure
			/// </summary>
			Call,
			/// <summary>
			/// Return
			/// </summary>
			Ret
		}
	}
}
