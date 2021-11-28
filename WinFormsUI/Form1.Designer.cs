
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
            this.playSubmitButton.Location = new System.Drawing.Point(518, 432);
            this.playSubmitButton.Name = "playSubmitButton";
            this.playSubmitButton.Size = new System.Drawing.Size(107, 36);
            this.playSubmitButton.TabIndex = 0;
            this.playSubmitButton.Text = "Play";
            this.playSubmitButton.UseVisualStyleBackColor = true;
            this.playSubmitButton.Click += new System.EventHandler(this.playSubmitButton_Click_1);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(518, 474);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(107, 36);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(518, 516);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(107, 36);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // userInputTextBox
            // 
            this.userInputTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userInputTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.userInputTextBox.Location = new System.Drawing.Point(12, 432);
            this.userInputTextBox.Multiline = true;
            this.userInputTextBox.Name = "userInputTextBox";
            this.userInputTextBox.Size = new System.Drawing.Size(500, 126);
            this.userInputTextBox.TabIndex = 3;
            // 
            // displayOutputTextBox
            // 
            this.displayOutputTextBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.displayOutputTextBox.Enabled = false;
            this.displayOutputTextBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOutputTextBox.HideSelection = false;
            this.displayOutputTextBox.Location = new System.Drawing.Point(12, 12);
            this.displayOutputTextBox.Multiline = true;
            this.displayOutputTextBox.Name = "displayOutputTextBox";
            this.displayOutputTextBox.Size = new System.Drawing.Size(617, 414);
            this.displayOutputTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 568);
            this.Controls.Add(this.displayOutputTextBox);
            this.Controls.Add(this.userInputTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.playSubmitButton);
            this.Name = "Form1";
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

