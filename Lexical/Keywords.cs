using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Lexical {
	#region Keywords
	/// <summary>
	/// Defines the instruction set of RISC
	/// </summary>
	public sealed class Keywords {
		/// <summary>
		/// Addition
		/// </summary>
		public static string Add = "add";
		/// <summary>
		/// Substraction
		/// </summary>
		public static string Substract = "sub";
		/// <summary>
		/// Multiplication
		/// </summary>
		public static string Multiply = "mul";
		/// <summary>
		/// Division
		/// </summary>
		public static string Divide = "div";
		/// <summary>
		/// Modulo
		/// </summary>
		public static string Modulo = "mod";
		/// <summary>
		/// Comparison
		/// </summary>
		public static string Compare = "cmp";
		/// <summary>
		/// Bitwise AND
		/// </summary>
		public static string BitwiseAnd = "and";
		/// <summary>
		/// Bitwise OR
		/// </summary>
		public static string BitwiseOr = "or";
		/// <summary>
		/// Bitwise NOT
		/// </summary>
		public static string BitwiseNot = "not";
		/// <summary>
		/// Move data
		/// </summary>
		public static string Move = "mov";
		/// <summary>
		/// Logical left shift
		/// </summary>
		public static string LogicalShiftLeft = "lsl";
		/// <summary>
		/// Logical right shift
		/// </summary>
		public static string LogicalShiftRight = "lsr";
		/// <summary>
		/// Arithmetical right shift
		/// </summary>
		public static string ArithmeticalShiftRight = "asr";
		/// <summary>
		/// No operation
		/// </summary>
		public static string NoOperation = "nop";
		/// <summary>
		/// Load from memory
		/// </summary>
		public static string Load = "ld";
		/// <summary>
		/// Store in memory
		/// </summary>
		public static string Store = "st";
		/// <summary>
		/// Branch equal
		/// </summary>
		public static string BranchEqual = "beq";
		/// <summary>
		/// Branch greater than
		/// </summary>
		public static string BranchGreaterThan = "bgt";
		/// <summary>
		/// Unconditional branch
		/// </summary>
		public static string Branch = "b";
		/// <summary>
		/// Call procedure
		/// </summary>
		public static string Call = "call";
		/// <summary>
		/// Return
		/// </summary>
		public static string Return = "ret";
		/// <summary>
		/// Comment
		/// </summary>
		public static string Comment = "@";
		/// <summary>
		/// Label
		/// </summary>
		public static string Label = ":";
	}
	#endregion
}
