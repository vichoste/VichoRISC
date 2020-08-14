using System.Collections.Generic;
using VichoRISC.Lexical;
using VichoRISC.Lexical.Instructions;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public sealed partial class Cpu {
		/// <summary>
		/// Creates a new CPU
		/// </summary>
		public Cpu() => this.Registers = new List<Register>() {
				new Register("R0"),
				new Register("R1"),
				new Register("R2"),
				new Register("R3"),
				new Register("R4"),
				new Register("R5"),
				new Register("R6"),
				new Register("R7 (Syscall)"),
				new Register("R8"),
				new Register("R9"),
				new Register("R10"),
				new Register("R11 (FP)"),
				new Register("R12 (IP)"),
				new Register("R13 (SP)"),
				new Register("R14 (LR)"),
				new Register("R15 (PC)"),
			};
		public void Execute(CodeRegexParser instructions, int lineCount) {
			System.Diagnostics.Debug.WriteLine("(i) Program excecution started (i)");
			for (var i = 0; i < lineCount; i++) {
				var currentInstruction = instructions[i];
				System.Diagnostics.Debug.WriteLine($"(i) Executing line {i + 1}. The keyword is {currentInstruction.Keyword} (i)");
				if (currentInstruction is FirstTypeInstruction firstTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"First");
				} else if (currentInstruction is SecondTypeInstruction secondTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"Second");
				} else if (currentInstruction is ThirdTypeInstruction thirdTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"Third");
				} else if (currentInstruction is FourthTypeInstruction fourthTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"Fourth");
				} else if (currentInstruction is FifthTypeInstruction fifthTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"Fifth");
				} else if (currentInstruction is SixthTypeInstruction sixthTypeInstruction) {
					System.Diagnostics.Debug.WriteLine($"Sixth");
				} else if (currentInstruction is SeventhTypeInstrucion seventhTypeInstrucion) {
					System.Diagnostics.Debug.WriteLine($"Seventh");
				} else {
					System.Diagnostics.Debug.WriteLine($"(!) It's not an instruction (!)");
				}
			}
		}
	}
}
