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
using VichoRISC.Components;

namespace VichoRISC.Tools {
	/// <summary>
	/// Memory visualizer tool
	/// </summary>
	public partial class MemoryVisualizer : Window {
		/// <summary>
		/// Holds the reference for the memory
		/// </summary>
		public Memory Memory { get; private set; }
		/// <summary>
		/// Creates a memory visualizer instance
		/// </summary>
		public MemoryVisualizer(Memory memory) {
			this.InitializeComponent();
			this.Memory = memory;
			this.DataContext = this.Memory;
		}
	}
}
