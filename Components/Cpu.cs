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
		/// Memory
		/// </summary>
		public Memory Memory { get; set; }
		/// <summary>
		/// Creates a new CPU
		/// </summary>
		public Cpu() {
			this.Registers = new List<Register>() {
				new Register("R0"),
				new Register("R1"),
				new Register("R2"),
				new Register("R3"),
				new Register("R4"),
				new Register("R5"),
				new Register("R6"),
				new Register("R7 (Syscall)"),
				new Register("R8"),
				new Register("R9"),
				new Register("R10"),
				new Register("R11 (FP)"),
				new Register("R12 (IP)"),
				new Register("R13 (SP)"),
				new Register("R14 (LR)"),
				new Register("R15 (PC)"),
			};
			this.Memory = new Memory();
		}
	}
}
