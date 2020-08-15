using System;
using VichoRISC.Lexical;

namespace VichoRISC.Components {
	/// <summary>
	/// Defines the CPU
	/// </summary>
	public sealed partial class Cpu {
		#region Instructions
		/// <summary>
		/// Adds two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the sum result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="isNegative">Establish if the second immediate value is negative</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Add(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			second = isNegative && isImmediate ? -second : second;
			this.Registers[destinationRegister].Value = first + second;
		}
		/// <summary>
		/// Substracts two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the substraction result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="isNegative">Establish if the second immediate value is negative</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Substract(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			second = isNegative && isImmediate ? -second : second;
			this.Registers[destinationRegister].Value = first - second;
		}
		/// <summary>
		/// Multiply two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the multiplication result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="isNegative">Establish if the second immediate value is negative</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Multiply(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			second = isNegative && isImmediate ? -second : second;
			this.Registers[destinationRegister].Value = first * second;
		}
		/// <summary>
		/// Divides two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the division result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="isNegative">Establish if the second immediate value is negative</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Divide(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			second = isNegative && isImmediate ? -second : second;
			if (second == 0) {
				throw new ArithmeticException("Can't divide by zero!");
			}
			this.Registers[destinationRegister].Value = first / second;
		}
		/// <summary>
		/// Applies modulo between two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the division result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Modulo(int destinationRegister, int firstRegister, bool isImmediate, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			if (second == 0) {
				throw new ArithmeticException("Can't divide by zero!");
			}
			this.Registers[destinationRegister].Value = first % second;
		}
		/// <summary>
		/// Compares two registers
		/// </summary>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Compare(int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			second = isNegative && isImmediate ? -second : second;
			if (first > second) {
				this.GreaterThanFlag = true;
				this.EqualFlag = false;
			} else if (first == second) {
				this.GreaterThanFlag = false;
				this.EqualFlag = true;
			} else {
				this.GreaterThanFlag = this.EqualFlag = false;
			}
		}
		/// <summary>
		/// Applies bitwise AND between two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the bitwise operation result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void BitwiseAnd(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			this.Registers[destinationRegister].Value = first & second;
		}
		/// <summary>
		/// Applies bitwise OR between two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the bitwise operation result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void BitwiseOr(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			this.Registers[destinationRegister].Value = first | second;
		}
		/// <summary>
		/// Applies bitwise NOT in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the bitwise operation result into this register</param>
		/// <param name="register">Register that will be used for the bitwise operation</param>
		public void BitwiseNot(int destinationRegister, int register) => this.Registers[destinationRegister].Value = ~this.Registers[destinationRegister].Value;
		/// <summary>
		/// Moves content between two registers
		/// </summary>
		/// <param name="destinationRegister">Contents will be moved to this register</param>
		/// <param name="isImmediate">Establish if the source register is actually an immediate value</param>
		/// <param name="isNegative">Establish if the source value is negative</param>
		/// <param name="sourceRegisterOrImmediate">Register who has the source content</param>
		public void Move(int destinationRegister, bool isImmediate, bool isNegative, int sourceRegisterOrImmediate) {
			var source = isImmediate ? sourceRegisterOrImmediate : this.Registers[sourceRegisterOrImmediate].Value;
			source = isNegative && isImmediate ? -source : source;
			this.Registers[destinationRegister].Value = source;
		}
		/// <summary>
		/// Applies a left logical shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void LogicalShiftLeft(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			this.Registers[destinationRegister].Value = first << second;
		}
		/// <summary>
		/// Applies a right logical shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void LogicalShiftRight(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			this.Registers[destinationRegister].Value = (int)((uint)first >> second);
		}
		/// <summary>
		/// Applies a right arithmetic shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void ArithmeticlShiftRight(int destinationRegister, int firstRegister, bool isImmediate, bool isNegative, int secondRegisterOrImmediate) {
			var first = this.Registers[firstRegister].Value;
			var second = isImmediate ? secondRegisterOrImmediate : this.Registers[secondRegisterOrImmediate].Value;
			this.Registers[destinationRegister].Value = first >> second;
		}
		/// <summary>
		/// Does nothing
		/// </summary>
		public void NoOperation() {

		}
		/// <summary>
		/// Loads content from memory into a register
		/// </summary>
		/// <param name="destinationRegister">Register used for storing the content</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		///  <param name="isPointer">Establish if the second register is a pointer to memory</param>
		/// <param name="isNegative">Establish if the second register is negative</param>
		/// <param name="sourceFromMemory">Pointer locating the data in memory</param>
		public void Load(int destinationRegister, bool isImmediate, bool isPointer, bool isNegative, int sourceFromMemory) {
			if (isPointer) {
				this.Registers[destinationRegister].Value = this._Memory[sourceFromMemory];
			} else {
				this.Move(destinationRegister, isImmediate, isNegative, sourceFromMemory);
			}
		}
		/// <summary>
		/// Saves content from a register into memory
		/// </summary>
		/// <param name="sourceRegister">Register used as the source of the content</param>
		/// <param name="isImmediate">Establish if the second register is immediate</param>
		/// <param name="isPointer">Establish if the second register is a pointer to memory</param>
		/// <param name="isNegative">Establish if the second register is negative</param>
		/// <param name="destinationIntoMemory">Pointer locating the location into memory where the content must be saved</param>
		public void Store(int sourceRegister, bool isImmediate, bool isPointer, bool isNegative, int destinationIntoMemory) {
			if (isPointer) {
				this._Memory[destinationIntoMemory] = this.Registers[sourceRegister].Value;
			} else {
				this.Move(destinationIntoMemory, isImmediate, isNegative, sourceRegister);
			}
		}
		/// <summary>
		/// Jumps if the comparison done previously is equal
		/// </summary>
		/// <param name="label">Destination label</param>
		public void BranchEqual(string label, CodeRegexParser instructions) {
			if (this.EqualFlag) {
				var line = instructions.FindLine(label);
				if (line == -1) {
					throw new ArgumentException("Label doesn't exist");
				}
				this.ProgramCounter = line;
			} else {
				this.ProgramCounter++;
			}
		}
		/// <summary>
		/// Jumps if the comparison done previously is greater than
		/// </summary>
		/// <param name="label">Destination label</param>
		public void BranchGreaterThan(string label, CodeRegexParser instructions) {
			if (this.GreaterThanFlag) {
				var line = instructions.FindLine(label);
				if (line == -1) {
					throw new ArgumentException("Label doesn't exist");
				}
				this.ProgramCounter = line;
			} else {
				this.ProgramCounter++;
			}
		}
		/// <summary>
		/// Jumps unconditionally
		/// </summary>
		/// <param name="label">Destination label</param>
		public void Branch(string label, CodeRegexParser instructions) {
			var line = instructions.FindLine(label);
			if (line == -1) {
				throw new ArgumentException("Label doesn't exist");
			}
			this.ProgramCounter = line;
		}
		/// <summary>
		/// Calls a function
		/// </summary>
		/// <param name="label">Function label</param>
		public void Call(string label, CodeRegexParser instructions) => this.Branch(label, instructions);
		/// <summary>
		/// Exits the current function
		/// </summary>
		public void Return() {

		}
		
		#endregion
	}
}
