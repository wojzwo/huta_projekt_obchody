﻿namespace SteelWorks_Admin.View
{
    partial class MainWindowView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(13, 13);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(259, 23);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Log To File";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TestButton);
            this.Name = "MainWindowView";
            this.Text = "MainWindowView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestButton;
    }
}