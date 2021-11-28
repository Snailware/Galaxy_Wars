using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaxyWarsClassLibrary;

namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Controller.StartGame();
        }

        private void ClearInput()
        {
            userInputTextBox.Clear();
        }
        private void playSubmitButton_Click_1(object sender, EventArgs e)
        {
            OutputDisplay(Controller.CallFrame());

            Controller.Update(userInputTextBox.Text);
            // get input and update game state. 

            ClearInput();
            // clear text box in prep for next entry.
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OutputDisplay(List<string> displayList)
        {
            displayOutputTextBox.Text = null;
            // clear old frame.

            foreach (string line in displayList)
            {
                if (string.IsNullOrEmpty(displayOutputTextBox.Text))
                {
                    displayOutputTextBox.Text = line;
                }
                // write first line without newline character. 
                else
                {
                    displayOutputTextBox.Text = $"{displayOutputTextBox.Text}{Environment.NewLine}{line}";
                }
                // seperate following entries with newline chars. 
            }
        }
    }
}
