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
		/// <summary>
		/// Executes the parsed instructions into the CPU
		/// </summary>
		/// <param name="instructions">Parsed instructions</param>
		public void Execute(CodeRegexParser instructions) {
			System.Diagnostics.Debug.WriteLine("(i) Program excecution started (i)");
			for (var i = 0; i < instructions.Count; i++) {
				var currentInstruction = instructions[i];
				System.Diagnostics.Debug.WriteLine($"(i) Executing line {i + 1}. The keyword is {currentInstruction.Keyword} (i)");
				if (currentInstruction is FirstTypeInstruction firstTypeInstruction) {
					var firstOperand = int.Parse(firstTypeInstruction.FirstOperand);
					var secondOperand = int.Parse(firstTypeInstruction.SecondOperand);
					var isThirdOperandImmediate = firstTypeInstruction.IsThirdOperandImmediate;
					var thirdOperand = int.Parse(firstTypeInstruction.ThirdOperand);
					switch (firstTypeInstruction.Keyword) {
						case "add":
							this.Add(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "sub":
							this.Substract(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "mul":
							this.Multiply(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "div":
							this.Divide(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "mod":
							this.Modulo(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "and":
							this.BitwiseAnd(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "or":
							this.BitwiseOr(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "lsl":
							this.LogicalShiftLeft(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "lsr":
							this.LogicalShiftRight(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
						case "asr":
							this.ArithmeticlShiftRight(firstOperand, secondOperand, isThirdOperandImmediate, thirdOperand);
							break;
					}
				} else if (currentInstruction is SecondTypeInstruction secondTypeInstruction) {
					var firstOperand = int.Parse(secondTypeInstruction.FirstOperand);
					var isSecondOperandImmediate = secondTypeInstruction.IsSecondOperandImmediate;
					var secondOperand = int.Parse(secondTypeInstruction.SecondOperand);
					switch (secondTypeInstruction.Keyword) {
						case "mov":
							this.Move(firstOperand, isSecondOperandImmediate, secondOperand);
							break;
						// TODO el resto
					}
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
