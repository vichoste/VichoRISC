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
using System.Windows.Shapes;

namespace VichoRISC.Tools {
	/// <summary>
	/// Memory visualizer tool
	/// </summary>
	public partial class MemoryVisualizer : Window {
		public MemoryVisualizer() => this.InitializeComponent();
		/// <summary>
		/// Overrides the window closing behavior
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel = true;
			this.Hide();
		}
	}
}
