using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VichoRISC.Components;

namespace VichoRISC {
	/// <summary>
	/// Main window
	/// </summary>
	public partial class MainWindow : Window {
		/// <summary>
		/// Parser for: and, sub, mul, div, mod, and, or, lsl, lsr, asr: (\w+ r[0-9]+, r[0-9]+, r[0-9]+)|(\w+ r[0-9]+, r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<string> _FirstType = from instruction in Parse.LetterOrDigit.Many().Text()
											   from firstWhiteSpace in Parse.WhiteSpace
											   from firstPrefix in Parse.Char('r').Once().Text()
											   from firstInputNumber in Parse.Number
											   from firstComma in Parse.Char(',').Once().Text()
											   from secondWhiteSpace in Parse.WhiteSpace
											   from secondPrefix in Parse.Char('r').Once().Text()
											   from secondInputNumber in Parse.Number
											   from secondComma in Parse.Char(',').Once().Text()
											   from thirdWhiteSpace in Parse.WhiteSpace
											   from thirdPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
											   from thirdInputNumber in Parse.Number
											   select instruction + firstInputNumber + secondInputNumber + thirdPrefix + thirdInputNumber;
		/// <summary>
		/// Parser for: mov, not: ((mov|not) r[0-9]+, r[0-9]+)|((mov|not) r[0-9]+, #[0-9]+)
		/// </summary>
		private static readonly Parser<string> _SecondType = from instruction in Parse.LetterOrDigit.Many().Text()
															from firstWhiteSpace in Parse.WhiteSpace
															from firstPrefix in Parse.Char('r').Once().Text()
															from firstInputNumber in Parse.Number
															from firstComma in Parse.Char(',').Once().Text()
															from secondWhiteSpace in Parse.WhiteSpace
															from secondPrefix in Parse.Char('r').Or(Parse.Char('#')).Once().Text()
															from secondInputNumber in Parse.Number
															select instruction + firstInputNumber + secondPrefix + secondInputNumber;
		/// <summary>
		/// Creates the main window
		/// </summary>
		public MainWindow() => this.InitializeComponent();
		/// <summary>
		/// Executes the new command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void New(object sender, ExecutedRoutedEventArgs e) {

		}
		/// <summary>
		/// Executes the open command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void Open(object sender, ExecutedRoutedEventArgs e) {

		}
		/// <summary>
		/// Executes the save command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void Save(object sender, ExecutedRoutedEventArgs e) {

		}
		/// <summary>
		/// Executes the save as command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void SaveAs(object sender, ExecutedRoutedEventArgs e) {

		}
		/// <summary>
		/// Executes the exit command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void Exit(object sender, ExecutedRoutedEventArgs e) {

		}
		#region Run
		/// <summary>
		/// Actually runs the code
		/// </summary>
		private void RunCode() {
			this.StatusListBox.Items.Clear();
			System.Diagnostics.Debug.WriteLine("Run!");
			var code = new TextRange(this.ArmCodeRichTextBox.Document.ContentStart, this.ArmCodeRichTextBox.Document.ContentEnd).Text.Replace("\r", string.Empty).Split('\n');
			var lineNumber = 0;
			foreach (var line in code) {
				++lineNumber;
				if (string.IsNullOrWhiteSpace(line)) {
					continue;
				}
				/*
				 * Regex patterns
				 * ld, st: ((ld|st) r[0-9]+, #[0-9]+)|((ld|st) r[0-9]+, r[0-9]+)|((ld|st) r[0-9]+, \[r[0-9]+\])
				 * nop: nop
				 * beq, bgt, b, call: (beq|bgt|b|call) \w+
				 * @: @\w+
				 * label: \w+:
				 */
				try {
					var detectedInput = string.Empty;
					// and, sub, mul, div, mod, and, or, lsl, lsr, asr
					if (line.Contains(Cpu.Keyword.Add)
						|| line.Contains(Cpu.Keyword.Substract)
						|| line.Contains(Cpu.Keyword.Multiply)
						|| line.Contains(Cpu.Keyword.Divide)
						|| line.Contains(Cpu.Keyword.Modulo)
						|| line.Contains(Cpu.Keyword.BitwiseAnd)
						|| line.Contains(Cpu.Keyword.BitwiseOr)
						|| line.Contains(Cpu.Keyword.LogicalShiftLeft)
						|| line.Contains(Cpu.Keyword.LogicalShiftRight)
						|| line.Contains(Cpu.Keyword.ArithmeticalShiftRight)) {
						detectedInput = _FirstType.Parse(line);
					} else if (line.Contains(Cpu.Keyword.Move)
						|| line.Contains(Cpu.Keyword.BitwiseNot)) { // mov, not
						detectedInput = _SecondType.Parse(line);
					}
					System.Diagnostics.Debug.WriteLine($"Línea: {line}");
					System.Diagnostics.Debug.WriteLine($"Parser {detectedInput}");
				} catch (Exception) {
					_ = this.StatusListBox.Items.Add($"Error de sintaxis en la línea {lineNumber}");
				}
			}
		}
		/// <summary>
		/// Executes the run command
		/// </summary>
		/// <param name="sender">Whos ends the event</param>
		/// <param name="e">Event arguments</param>
		private void Run(object sender, ExecutedRoutedEventArgs e) => this.RunCode();
		#endregion
		/// <summary>
		/// Executes the run command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void RunMenuItem_Click(object sender, RoutedEventArgs e) => this.RunCode();
	}
}
