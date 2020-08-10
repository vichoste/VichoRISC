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
		public Cpu() => this.Registers = new List<int>(16);
	}
}
