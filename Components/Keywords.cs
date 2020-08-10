using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public partial class Cpu {
		#region Keywords
		/// <summary>
		/// Defines the instruction set of RISC
		/// </summary>
		public enum Keywords {
			/// <summary>
			/// Addition
			/// </summary>
			[Description("add")]
			Add,
			/// <summary>
			/// Substraction
			/// </summary>
			[Description("sub")]
			Substract,
			/// <summary>
			/// Multiplication
			/// </summary>
			[Description("mul")]
			Multiply,
			/// <summary>
			/// Division
			/// </summary>
			[Description("div")]
			Divide,
			/// <summary>
			/// Modulo
			/// </summary>
			[Description("mod")]
			Modulo,
			/// <summary>
			/// Comparison
			/// </summary>
			[Description("cmp")]
			Compare,
			/// <summary>
			/// Bitwise AND
			/// </summary>
			[Description("and")]
			BitwiseAnd,
			/// <summary>
			/// Bitwise OR
			/// </summary>
			[Description("or")]
			BitwiseOr,
			/// <summary>
			/// Bitwise NOT
			/// </summary>
			[Description("not")]
			BitwiseNot,
			/// <summary>
			/// Move data
			/// </summary>
			[Description("mov")]
			Move,
			/// <summary>
			/// Logical left shift
			/// </summary>
			[Description("lsl")]
			LogicalShiftLeft,
			/// <summary>
			/// Logical right shift
			/// </summary>
			[Description("lsr")]
			LogicalShiftRight,
			/// <summary>
			/// Arithmetical right shift
			/// </summary>
			[Description("asr")]
			ArithmeticalShiftRight,
			/// <summary>
			/// No operation
			/// </summary>
			[Description("nop")]
			NoOperation,
			/// <summary>
			/// Load from memory
			/// </summary>
			[Description("ld")]
			Load,
			/// <summary>
			/// Store in memory
			/// </summary>
			[Description("st")]
			Store,
			/// <summary>
			/// Branch equal
			/// </summary>
			[Description("beq")]
			BranchEqual,
			/// <summary>
			/// Branch great than
			/// </summary>
			[Description("bgt")]
			BranchGreaterThan,
			/// <summary>
			/// Branch
			/// </summary>
			[Description("b")]
			Branch,
			/// <summary>
			/// Call procedure
			/// </summary>
			[Description("call")]
			Call,
			/// <summary>
			/// Return
			/// </summary>
			[Description("return")]
			Return
		}
		#endregion
	}
}
