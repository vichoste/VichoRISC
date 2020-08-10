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
		/// List of registers
		/// </summary>
		public List<int> Registers { get; private set; }
		#region General purpose registers
		/// <summary>
		/// General purpose register 0
		/// </summary>
		public int RegisterZero {
			get => this.Registers[0];
			set => this.Registers[0] = value;
		}
		/// <summary>
		/// General purpose register 1
		/// </summary>
		public int RegisterOne {
			get => this.Registers[1];
			set => this.Registers[1] = value;
		}
		/// <summary>
		/// General purpose register 2
		/// </summary>
		public int RegisterTwo {
			get => this.Registers[2];
			set => this.Registers[2] = value;
		}
		/// <summary>
		/// General purpose register 3
		/// </summary>
		public int RegisterThree {
			get => this.Registers[3];
			set => this.Registers[3] = value;
		}
		/// <summary>
		/// General purpose register 4
		/// </summary>
		public int RegisterFour {
			get => this.Registers[4];
			set => this.Registers[4] = value;
		}
		/// <summary>
		/// General purpose register 5
		/// </summary>
		public int RegisterFive {
			get => this.Registers[5];
			set => this.Registers[5] = value; }
		/// <summary>
		/// General purpose register 6
		/// </summary>
		public int RegisterSix {
			get => this.Registers[6];
			set => this.Registers[6] = value;
		}
		/// <summary>
		/// General purpose register 7
		/// </summary>
		public int RegisterSeven {
			get => this.Registers[7];
			set => this.Registers[7] = value;
		}
		/// <summary>
		/// General purpose register 8
		/// </summary>
		public int RegisterEight {
			get => this.Registers[8];
			set => this.Registers[8] = value;
		}
		/// <summary>
		/// General purpose register 9
		/// </summary>
		public int RegisterNine {
			get => this.Registers[9];
			set => this.Registers[9] = value;
		}
		/// <summary>
		/// General purpose register 10
		/// </summary>
		public int RegisterTen {
			get => this.Registers[10];
			set => this.Registers[10] = value;
		}
		#endregion
		#region Special purpose registers
		/// <summary>
		/// Frame pointer (Register 11)
		/// </summary>
		public int RegisterEleven {
			get => this.Registers[11];
			set => this.Registers[11] = value;
		}
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
		public int RegisterTwelve {
			get => this.Registers[12];
			set => this.Registers[12] = value;
		}
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
		public int RegisterThirteen {
			get => this.Registers[13];
			set => this.Registers[13] = value;
		}
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
		public int RegisterFourteen {
			get => this.Registers[14];
			set => this.Registers[14] = value;
		}
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
		public int RegisterFifteen {
			get => this.Registers[15];
			set => this.Registers[15] = value;
		}
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
