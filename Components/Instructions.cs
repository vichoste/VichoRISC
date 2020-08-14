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
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Add(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister + secondRegisterOrImmediate;
		/// <summary>
		/// Substracts two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the substraction result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Substract(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister - secondRegisterOrImmediate;
		/// <summary>
		/// Multiply two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the multiplication result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Multiply(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister * secondRegisterOrImmediate;
		/// <summary>
		/// Divides two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the division result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Divide(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister / secondRegisterOrImmediate;
		/// <summary>
		/// Compares two registers
		/// </summary>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void Compare(ref int firstRegister, ref int secondRegisterOrImmediate) {
			if (firstRegister > secondRegisterOrImmediate) {
				this.GreaterThanFlag = true;
				this.EqualFlag = false;
			} else if (firstRegister == secondRegisterOrImmediate) {
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
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void BitwiseAnd(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister & secondRegisterOrImmediate;
		/// <summary>
		/// Applies bitwise OR between two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the bitwise operation result into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value</param>
		public void BitwiseOr(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister | secondRegisterOrImmediate;
		/// <summary>
		/// Applies bitwise NOT in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the bitwise operation result into this register</param>
		/// <param name="sourceRegister">Register that will be used for the bitwise operation</param>
		public void BitwiseNot(ref int destinationRegister, ref int sourceRegister) => destinationRegister = ~sourceRegister;
		/// <summary>
		/// Moves content between two registers
		/// </summary>
		/// <param name="destinationRegister">Contents will be moved to this register</param>
		/// <param name="sourceRegisterOrImmediate">Register who has the source content</param>
		public void Move(ref int destinationRegister, ref int sourceRegisterOrImmediate) => destinationRegister = sourceRegisterOrImmediate;
		/// <summary>
		/// Applies a left logical shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void LogicalShiftLeft(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister << secondRegisterOrImmediate;
		/// <summary>
		/// Applies a right logical shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void LogicalShiftRight(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = (int)((uint) firstRegister >> secondRegisterOrImmediate);
		/// <summary>
		/// Applies a right arithmetic shift in a register
		/// </summary>
		/// <param name="destinationRegister">Saves the shift operation result into this register</param>
		/// <param name="firstRegister">Register that will be used for the shift operation</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value used for offset</param>
		public void ArithmeticlShiftRight(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) => destinationRegister = firstRegister >> secondRegisterOrImmediate;
		/// <summary>
		/// Does nothing
		/// </summary>
		public void NoOperation() {

		}
		/// <summary>
		/// Loads content from memory into a register
		/// </summary>
		/// <param name="destinationRegister">Register used for storing the content</param>
		/// <param name="sourceFromMemory">Pointer locating the data in memory</param>
		public void Load(ref int destinationRegister, ref int sourceFromMemory) {

		}
		/// <summary>
		/// Saves content from a register into memory
		/// </summary>
		/// <param name="sourceRegister">Register used as the source of the content</param>
		/// <param name="destinationIntoMemory">Pointer locating the location into memory where the content must be saved</param>
		public void Store(ref int sourceRegister, ref int destinationIntoMemory) {

		}
		/// <summary>
		/// Jumps if the comparison done previously is equal
		/// </summary>
		/// <param name="label">Destination label</param>
		public void BranchEqual(ref string label) {

		}
		/// <summary>
		/// Jumps if the comparison done previously is greater than
		/// </summary>
		/// <param name="label">Destination label</param>
		public void BranchGreaterThan(ref string label) {

		}
		/// <summary>
		/// Jumps unconditionally
		/// </summary>
		/// <param name="label">Destination label</param>
		public void Branch(ref string label) {

		}
		/// <summary>
		/// Calls a function
		/// </summary>
		/// <param name="label">Function label</param>
		public void Call(ref string label) {

		}
		/// <summary>
		/// Exits the current function
		/// </summary>
		public void Return() {

		}
		#endregion
	}
}
