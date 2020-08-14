namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public sealed partial class Cpu {
		#region Current Program Status (Flags)
		/// <summary>
		/// Equal flag
		/// </summary>
		private bool EqualFlag { get; set; }
		/// <summary>
		/// Greater than flag
		/// </summary>
		private bool GreaterThanFlag { get; set; }
		#endregion
	}
}
