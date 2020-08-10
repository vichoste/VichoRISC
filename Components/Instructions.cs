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
		#region Instructions
		/// <summary>
		/// Adds two registers
		/// </summary>
		/// <param name="destinationRegister">Saves the sum into this register</param>
		/// <param name="firstRegister">First register</param>
		/// <param name="secondRegisterOrImmediate">Second register or immediate value'</param>
		public void Add(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void Substract(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void Multiply(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void Divide(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void Compare(ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void BitwiseAnd(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void BitwiseOr(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void BitwiseNot(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void Move(ref int destinationRegister, ref int originRegisterOrImmediate) {

		}
		public void LogicalShiftLeft(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void LogicalShiftRight(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void ArithmeticlShiftRight(ref int destinationRegister, ref int firstRegister, ref int secondRegisterOrImmediate) {

		}
		public void NoOperation() {

		}
		public void Load(ref int destinationRegister, ref int pointerRegisterOrImmediate) {

		}
		public void Store(ref int pointerRegister, ref int destinationPointerOrImmediate) {

		}
		public void BranchEqual(ref string label) {

		}
		public void BranchGreaterThan(ref string label) {

		}
		public void Branch(ref string label) {

		}
		public void Call(ref string label) {

		}
		public void Return() {

		}
		#endregion
	}
}
