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
using GalaxyWarsClassLibrary;

namespace WpfUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Controller.StartGame();
		}

		/// <summary>
		/// on click, update game state according to user input and display
		/// the results.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
		{
			if (SubmitButton.Content is "Play")
			{
				SubmitButton.Content = "Submit";
			}
			// change button text to reflect state.

			Controller.Update(InputTextBox.Text);
			// get input and update game state. 

			WriteOutput(Controller.CallFrame());
			// create and display game frame. 

			ClearInput();
			// clear text box in prep for next entry.
		}

		/// <summary>
		/// on click, clear input text box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearInput();
		}

		/// <summary>
		/// on click, close program.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// write list of strings to output textbox. each list entry will be 
		/// displayed on a new line. 
		/// </summary>
		/// <param name="displayList">list of strings to be displayed.</param>
		private void WriteOutput(List<string> displayList)
		{
			OutputTextBlock.Text = null;
			// clear old frame.

			foreach (string line in displayList)
			{
				if (string.IsNullOrEmpty(OutputTextBlock.Text))
				{
					OutputTextBlock.Text = line;
				}
				// write first line without newline character. 
				else
				{
					OutputTextBlock.Text = $"{OutputTextBlock.Text}{Environment.NewLine}{line}";
				}
				// seperate following entries with newline chars. 
			}
			// write strings to output textbox.
		}

		/// <summary>
		/// clear all text from input field.
		/// </summary>
		private void ClearInput()
		{
			InputTextBox.Clear();
		}
	}
}
