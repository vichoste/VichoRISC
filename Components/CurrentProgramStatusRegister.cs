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
		#region Current Program Status (Flags)
		/// <summary>
		/// Negative flag
		/// </summary>
		public bool N { get; set; }
		/// <summary>
		/// Negative flag
		/// </summary>
		public bool Negative {
			get => this.N;
			set => this.N = value;
		}
		/// <summary>
		/// Zero flag
		/// </summary>
		public bool Z { get; set; }
		/// <summary>
		/// Zero flag
		/// </summary>
		public bool Zero {
			get => this.Z;
			set => this.Z = value;
		}
		/// <summary>
		/// Carry flag
		/// </summary>
		public bool C { get; set; }
		/// <summary>
		/// Carry flag
		/// </summary>
		public bool Carry {
			get => this.C;
			set => this.Z = value;
		}
		/// <summary>
		/// Overflow flag
		/// </summary>
		public bool V { get; set; }
		/// <summary>
		/// Overflow flag
		/// </summary>
		public bool Overflow {
			get => this.V;
			set => this.V = value;
		}
		public bool Underflow { get; set; }
		public bool Jazelle { get; set; }
		public bool GreaterThanOrEqual { get; set; }
		public bool Endianness { get; set; }
		public bool AbortDisable { get; set; }
		public bool IrqDisable { get; set; }
		public bool FiqDisable { get; set; }
		public bool Thumb { get; set; }
		public bool ProcessorMode { get; set; }
		#endregion
	}
}
