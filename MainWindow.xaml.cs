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
					}
				} catch (Exception) {
					_ = this.StatusListBox.Items.Add($"Error de sintaxis en la línea {lineNumber}");
					isTheCodeRegexGood = false;
				}
			}
			if (isTheCodeRegexGood) {

			}
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
