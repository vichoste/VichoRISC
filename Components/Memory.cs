using System;
using System.Collections;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the memory
	/// </summary>
	public sealed class Memory {
		/// <summary>
		/// Instead of a long array that overflows, I'm using a hashtable that emulates RAM
		/// </summary>
		public Hashtable Ram { get; set; }
		/// <summary>
		/// Creates a memory
		/// </summary>
		public Memory() => this.Ram = new Hashtable();
		/// <summary>
		/// Gets a memory value
		/// </summary>
		/// <param name="address">Desired address</param>
		/// <returns>Value of the address</returns>
		public int this[int address] {
			get {
				if (this.Ram[address] == null) {
					throw new NullReferenceException();
				}
				var value = (int)this.Ram[address];
				return value;
			}
			set {
				if (!this.Ram.ContainsKey(address)) {
					this.Ram.Add(address, value);
				} else {
					this.Ram[address] = value;
				}
			}
		}
		/// <summary>
		/// Clears an address content in the memory
		/// </summary>
		/// <param name="address">Desired address</param>
		public void Clear(int address) {
			if (this.Ram.ContainsKey(address)) {
				this.Ram.Remove(address);
			}
		}
		/// <summary>
		/// Clears all the memory
		/// </summary>
		public void ClearMemory() => this.Ram.Clear();
	}
}