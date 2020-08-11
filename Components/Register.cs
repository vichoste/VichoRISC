using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines a register
	/// </summary>
	public class Register {
		/// <summary>
		/// Name of the register
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Value of the register
		/// </summary>
		public int Value { get; set; }
		/// <summary>
		/// Creates a register
		/// </summary>
		/// <param name="name">Name of the register</param>
		public Register(string name) => this.Name = name;
	}
}
