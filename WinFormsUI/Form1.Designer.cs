
namespace WinFormsUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.playSubmitButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.userInputTextBox = new System.Windows.Forms.TextBox();
            this.displayOutputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // playSubmitButton
            // 
            this.playSubmitButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playSubmitButton.Location = new System.Drawing.Point(388, 351);
            this.playSubmitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playSubmitButton.Name = "playSubmitButton";
            this.playSubmitButton.Size = new System.Drawing.Size(80, 29);
            this.playSubmitButton.TabIndex = 0;
            this.playSubmitButton.Text = "Play";
            this.playSubmitButton.UseVisualStyleBackColor = true;
            this.playSubmitButton.Click += new System.EventHandler(this.playSubmitButton_Click_1);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(388, 385);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(80, 29);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(388, 419);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(80, 29);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // userInputTextBox
            // 
            this.userInputTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userInputTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.userInputTextBox.Location = new System.Drawing.Point(9, 351);
            this.userInputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userInputTextBox.Multiline = true;
            this.userInputTextBox.Name = "userInputTextBox";
            this.userInputTextBox.Size = new System.Drawing.Size(376, 103);
            this.userInputTextBox.TabIndex = 3;
            // 
            // displayOutputTextBox
            // 
            this.displayOutputTextBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.displayOutputTextBox.Enabled = false;
            this.displayOutputTextBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOutputTextBox.HideSelection = false;
            this.displayOutputTextBox.Location = new System.Drawing.Point(9, 10);
            this.displayOutputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayOutputTextBox.Multiline = true;
            this.displayOutputTextBox.Name = "displayOutputTextBox";
            this.displayOutputTextBox.Size = new System.Drawing.Size(464, 337);
            this.displayOutputTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.displayOutputTextBox);
            this.Controls.Add(this.userInputTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.playSubmitButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "GalaxyWars";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button playSubmitButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox userInputTextBox;
        private System.Windows.Forms.TextBox displayOutputTextBox;
    }
}

