using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using VichoRISC.Lexical;

namespace VichoRISC {
	/// <summary>
	/// Main window
	/// </summary>
	public partial class MainWindow : Window {
		/// <summary>
		/// Creates the main window
		/// </summary>
		public MainWindow() => this.InitializeComponent();
		#region New
		/// <summary>
		/// Executes the new command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void New(object sender, ExecutedRoutedEventArgs e) {

		}
		#endregion
		#region Open
		/// <summary>
		/// Executes the open command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void Open(object sender, ExecutedRoutedEventArgs e) {

		}
		#endregion
		#region Save and Save As
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
		#endregion
		#region Exit
		/// <summary>
		/// Executes the exit command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void Exit(object sender, ExecutedRoutedEventArgs e) {

		}
		#endregion
		#region Run
		/// <summary>
		/// Actually runs the code
		/// </summary>
		private void VerifyCodeRegex() {
			this.ArmCodeRichTextBox.IsEnabled = false;
			this.Cpu.ClearRegisters();
			this.Cpu.ClearMemory();
			this.RegistersDataGrid.ItemsSource = null;
			this.RegistersDataGrid.ItemsSource = this.Cpu.Registers;
			var isTheCodeRegexGood = true;
			this.StatusListBox.Items.Clear();
			var code = new TextRange(this.ArmCodeRichTextBox.Document.ContentStart, this.ArmCodeRichTextBox.Document.ContentEnd).Text.Replace("\r", string.Empty).Split('\n');
			var lineNumber = 0;
			var codeRegexParser = new CodeRegexParser();
			foreach (var line in code) {
				++lineNumber;
				if (string.IsNullOrWhiteSpace(line)) {
					continue;
				}
				try {
					var isLineParsingSuccessfull = codeRegexParser.AddLine(lineNumber, line);
					if (!isLineParsingSuccessfull) {
						_ = this.StatusListBox.Items.Add($"Instrucción no válida en la línea {lineNumber}");
						isTheCodeRegexGood = false;
					}
				} catch (ArithmeticException) {
					_ = this.StatusListBox.Items.Add($"Error de parseo: Se está dividiendo por cero en la línea {lineNumber}");
					isTheCodeRegexGood = false;
				} catch (Exception) {
					_ = this.StatusListBox.Items.Add($"Error de parseo: Error de sintaxis en la línea {lineNumber}");
					isTheCodeRegexGood = false;
				}
			}
			if (isTheCodeRegexGood) {
				try {
					this.Cpu.Execute(codeRegexParser);
					this.RegistersDataGrid.ItemsSource = null;
					this.RegistersDataGrid.ItemsSource = this.Cpu.Registers;
				} catch (NullReferenceException) {
					_ = this.StatusListBox.Items.Add($"Error de runtime: Se está tratando de acceder a una dirección de memoria que no tiene nada asignado");
				} catch (Exception) {
					_ = this.StatusListBox.Items.Add($"Error de runtime: El programa no tiene instrucciones");
				}
			}
			this.ArmCodeRichTextBox.IsEnabled = true;
		}
		/// <summary>
		/// Executes the run command
		/// </summary>
		/// <param name="sender">Whos ends the event</param>
		/// <param name="e">Event arguments</param>
		private void Run(object sender, ExecutedRoutedEventArgs e) => this.VerifyCodeRegex();
		/// <summary>
		/// Executes the run command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
		/// <param name="e">Event arguments</param>
		private void RunMenuItem_Click(object sender, RoutedEventArgs e) => this.VerifyCodeRegex();
		#endregion
	}
}
