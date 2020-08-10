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
		#region General purpose registers
		/// <summary>
		/// General purpose register 0
		/// </summary>
		public int RegisterZero { get; set; }
		/// <summary>
		/// General purpose register 1
		/// </summary>
		public int RegisterOne { get; set; }
		/// <summary>
		/// General purpose register 2
		/// </summary>
		public int RegisterTwo { get; set; }
		/// <summary>
		/// General purpose register 3
		/// </summary>
		public int RegisterThree { get; set; }
		/// <summary>
		/// General purpose register 4
		/// </summary>
		public int RegisterFour { get; set; }
		/// <summary>
		/// General purpose register 5
		/// </summary>
		public int RegisterFive { get; set; }
		/// <summary>
		/// General purpose register 6
		/// </summary>
		public int RegisterSix { get; set; }
		/// <summary>
		/// General purpose register 7
		/// </summary>
		public int RegisterSeven { get; set; }
		/// <summary>
		/// General purpose register 8
		/// </summary>
		public int RegisterEight { get; set; }
		/// <summary>
		/// General purpose register 9
		/// </summary>
		public int RegisterNine { get; set; }
		/// <summary>
		/// General purpose register 10
		/// </summary>
		public int RegisterTen { get; set; }
		#endregion
		#region Special purpose registers
		/// <summary>
		/// Frame pointer (Register 11)
		/// </summary>
		public int RegisterEleven { get; set; }
		/// <summary>
		/// Frame pointer (Register 11)
		/// </summary>
		public int FramePointer {
			get => this.RegisterEleven;
			set => this.RegisterEleven = value;
		}
		/// <summary>
		/// Intra procedural call (Register 12)
		/// </summary>
		public int RegisterTwelve { get; set; }
		/// <summary>
		/// Intra procedural call (Register 12)
		/// </summary>
		public int IntraProceduralCall {
			get => this.RegisterTwelve;
			set => this.RegisterTwelve = value;
		}
		/// <summary>
		/// Stack pointer (Register 13)
		/// </summary>
		public int RegisterThirteen { get; set; }
		/// <summary>
		/// Stack pointer (Register 13)
		/// </summary>
		public int StackPointer {
			get => this.RegisterThirteen;
			set => this.RegisterThirteen = value;
		}
		/// <summary>
		/// Link register (Register 14)
		/// </summary>
		public int RegisterFourteen { get; set; }
		/// <summary>
		/// Link register (Register 14)
		/// </summary>
		public int LinkRegister {
			get => this.RegisterFourteen;
			set => this.RegisterFourteen = value;
		}
		/// <summary>
		/// Program counter (Register 15)
		/// </summary>
		public int RegisterFifteen { get; set; }
		/// <summary>
		/// Program counter (Register 15)
		/// </summary>
		public int ProgramCounter {
			get => this.RegisterFifteen;
			set => this.RegisterFifteen = value;
		}
		#endregion
	}
}
