using System.Collections.Generic;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public sealed partial class Cpu {
		/// <summary>
		/// Register values
		/// </summary>
		public List<Register> Registers { get; set; }
		/// <summary>
		/// Resets all the values of the registers
		/// </summary>
		public void ClearRegisters() {
			foreach (var register in this.Registers) {
				register.Value = 0;
			}
		}
		/// <summary>
		/// Clears all the memory
		/// </summary>
		public void ClearMemory() => this.Memory.ClearMemory();
		/// <summary>
		/// Program counter (Register 15)
		/// </summary>
		public int ProgramCounter {
			get => this.Registers[15].Value;
			set => this.Registers[15].Value = value;
		}
	}
}
