using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			System.Diagnostics.Debug.WriteLine("Run!");
			var armCodeRichTextBox = this.ArmCodeRichTextBox;
			var selection = new TextRange(armCodeRichTextBox.Document.ContentStart, armCodeRichTextBox.Document.ContentEnd);
			var code = selection.Text;
			System.Diagnostics.Debug.WriteLine(code);
		}
		/// <summary>
		/// Executes the run command
		/// </summary>
		/// <param name="sender">Who sends the event</param>
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
