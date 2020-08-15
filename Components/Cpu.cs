using System.Collections.Generic;
using VichoRISC.Lexical;
using VichoRISC.Lexical.Instructions;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public sealed partial class Cpu {
		/// <summary>
		/// Defines a instance of RAM
		/// </summary>
		private readonly Memory _Memory;
		/// <summary>
		/// Creates a new CPU
		/// </summary>
		public Cpu() {
			this.Registers = new List<Register>() {
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
			this._Memory = new Memory();
		}
		/// <summary>
		/// Executes the parsed instructions into the CPU
		/// </summary>
		/// <param name="instructions">Parsed instructions</param>
		public void Execute(CodeRegexParser instructions) {
			while (this.ProgramCounter < instructions.Count) {
				var currentInstruction = instructions[this.ProgramCounter];
				if (currentInstruction is FirstTypeInstruction firstTypeInstruction) {
					var firstOperand = int.Parse(firstTypeInstruction.FirstOperand);
					var secondOperand = int.Parse(firstTypeInstruction.SecondOperand);
					var isThirdOperandImmediate = firstTypeInstruction.IsThirdOperandImmediate;
					var isThirdOperandNegative = firstTypeInstruction.IsThirdOperandNegative;
					var thirdOperand = int.Parse(firstTypeInstruction.ThirdOperand);
					switch (firstTypeInstruction.Keyword) {
						case "add":
							this.Add(firstOperand, secondOperand, isThirdOperandImmediate, isThirdOperandNegative, thirdOperand);
							break;
						case "sub":
							this.Substract(firstOperand, secondOperand, isThirdOperandImmediate, isThirdOperandNegative, thirdOperand);
							break;
						case "mul":
							this.Multiply(firstOperand, secondOperand, isThirdOperandImmediate, isThirdOperandNegative, thirdOperand);
							break;
						case "div":
							this.Divide(firstOperand, secondOperand, isThirdOperandImmediate, isThirdOperandNegative, thirdOperand);
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
					++this.ProgramCounter;
				} else if (currentInstruction is SecondTypeInstruction secondTypeInstruction) {
					var firstOperand = int.Parse(secondTypeInstruction.FirstOperand);
					var isSecondOperandImmediate = secondTypeInstruction.IsSecondOperandImmediate;
					var isSecondOperandNegative = secondTypeInstruction.IsSecondOperandNegative;
					var secondOperand = int.Parse(secondTypeInstruction.SecondOperand);
					switch (secondTypeInstruction.Keyword) {
						case "mov":
							this.Move(firstOperand, isSecondOperandImmediate, isSecondOperandNegative, secondOperand);
							break;
						case "not":
							this.BitwiseNot(firstOperand, secondOperand);
							break;
						case "ld":
							this.Load(firstOperand, isSecondOperandImmediate, false, isSecondOperandNegative, secondOperand);
							break;
						case "st":
							this.Store(firstOperand, isSecondOperandImmediate, false, isSecondOperandNegative, secondOperand);
							break;
						case "cmp":
							this.Compare(firstOperand, isSecondOperandImmediate, isSecondOperandNegative, secondOperand);
							break;
					}
					++this.ProgramCounter;
				} else if (currentInstruction is ThirdTypeInstruction thirdTypeInstruction) {
					var firstOperand = int.Parse(thirdTypeInstruction.FirstOperand);
					var secondOperand = int.Parse(thirdTypeInstruction.SecondOperand);
					switch (thirdTypeInstruction.Keyword) {
						case "ld":
							this.Load(firstOperand, false, true, false, secondOperand);
							break;
						case "st":
							this.Store(firstOperand, false, true, false, secondOperand);
							break;
					}
					++this.ProgramCounter;
				} else if (currentInstruction is FifthTypeInstruction fifthTypeInstruction) {
					switch (fifthTypeInstruction.Keyword) {
						case "beq":
							this.BranchEqual(fifthTypeInstruction.Operand, instructions);
							break;
						case "bgt":
							this.BranchGreaterThan(fifthTypeInstruction.Operand, instructions);
							break;
						case "b":
							this.Branch(fifthTypeInstruction.Operand, instructions);
							break;
					}
				} else if (currentInstruction is FourthTypeInstruction || currentInstruction is SixthTypeInstruction || currentInstruction is SeventhTypeInstruction) {
					++this.ProgramCounter;
				}
			}
		}
	}
}
