using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public partial sealed class Cpu {
		/// <summary>
		/// Register values
		/// </summary>
		public List<Register> Registers { get; set; }
		#region General purpose registers
		/// <summary>
		/// General purpose register 0
		/// </summary>
		public int RegisterZero {
			get => this.Registers[0].Value;
			set => this.Registers[0].Value = value;
		}
		/// <summary>
		/// General purpose register 1
		/// </summary>
		public int RegisterOne {
			get => this.Registers[1].Value;
			set => this.Registers[1].Value = value;
		}
		/// <summary>
		/// General purpose register 2
		/// </summary>
		public int RegisterTwo {
			get => this.Registers[2].Value;
			set => this.Registers[2].Value = value;
		}
		/// <summary>
		/// General purpose register 3
		/// </summary>
		public int RegisterThree {
			get => this.Registers[3].Value;
			set => this.Registers[3].Value = value;
		}
		/// <summary>
		/// General purpose register 4
		/// </summary>
		public int RegisterFour {
			get => this.Registers[4].Value;
			set => this.Registers[4].Value = value;
		}
		/// <summary>
		/// General purpose register 5
		/// </summary>
		public int RegisterFive {
			get => this.Registers[5].Value;
			set => this.Registers[5].Value = value; }
		/// <summary>
		/// General purpose register 6
		/// </summary>
		public int RegisterSix {
			get => this.Registers[6].Value;
			set => this.Registers[6].Value = value;
		}
		/// <summary>
		/// General purpose register 7 (Syscall number)
		/// </summary>
		public int RegisterSeven {
			get => this.Registers[7].Value;
			set => this.Registers[7].Value = value;
		}
		/// <summary>
		/// General purpose register 7 (Syscall number)
		/// </summary>
		public int SyscallNumber {
			get => this.RegisterSeven;
			set => this.RegisterSeven = value;
		}
		/// <summary>
		/// General purpose register 8
		/// </summary>
		public int RegisterEight {
			get => this.Registers[8].Value;
			set => this.Registers[8].Value = value;
		}
		/// <summary>
		/// General purpose register 9
		/// </summary>
		public int RegisterNine {
			get => this.Registers[9].Value;
			set => this.Registers[9].Value = value;
		}
		/// <summary>
		/// General purpose register 10
		/// </summary>
		public int RegisterTen {
			get => this.Registers[10].Value;
			set => this.Registers[10].Value = value;
		}
		#endregion
		#region Special purpose registers
		/// <summary>
		/// Frame pointer (Register 11)
		/// </summary>
		public int RegisterEleven {
			get => this.Registers[11].Value;
			set => this.Registers[11].Value = value;
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
			get => this.Registers[12].Value;
			set => this.Registers[12].Value = value;
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
			get => this.Registers[13].Value;
			set => this.Registers[13].Value = value;
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
			get => this.Registers[14].Value;
			set => this.Registers[14].Value = value;
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
			get => this.Registers[15].Value;
			set => this.Registers[15].Value = value;
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
