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
		/// Negative bit
		/// </summary>
		private bool N { get; set; }
		/// <summary>
		/// Negative bit
		/// </summary>
		public bool Negative => this.N;
		/// <summary>
		/// Zero bit
		/// </summary>
		private bool Z { get; set; }
		/// <summary>
		/// Zero bit
		/// </summary>
		public bool Zero => this.Z;
		/// <summary>
		/// Carry bit
		/// </summary>
		private bool C { get; set; }
		/// <summary>
		/// Carry bit
		/// </summary>
		public bool Carry => this.C;
		/// <summary>
		/// Overflow bit
		/// </summary>
		private bool V { get; set; }
		/// <summary>
		/// Overflow bit
		/// </summary>
		public bool Overflow => this.V;
		#endregion
	}
}
