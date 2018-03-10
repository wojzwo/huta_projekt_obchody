﻿namespace SteelWorks_Admin.View
{
    partial class AdminMainView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainView));
			this.LoadChipButton = new System.Windows.Forms.Button();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.trackButton = new System.Windows.Forms.Button();
			this.keyPadSettingButton = new System.Windows.Forms.Button();
			this.chipListButton = new System.Windows.Forms.Button();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.ButtonPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// LoadChipButton
			// 
			this.LoadChipButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.LoadChipButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadChipButton.BackgroundImage")));
			this.LoadChipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LoadChipButton.Location = new System.Drawing.Point(12, 12);
			this.LoadChipButton.Name = "LoadChipButton";
			this.LoadChipButton.Size = new System.Drawing.Size(400, 100);
			this.LoadChipButton.TabIndex = 0;
			this.LoadChipButton.Text = "Wczytaj Chip";
			this.LoadChipButton.UseVisualStyleBackColor = false;
			this.LoadChipButton.Click += new System.EventHandler(this.LoadChipButton_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1982, 944);
			this.MainPanel.TabIndex = 3;
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.BackColor = System.Drawing.SystemColors.Control;
			this.ButtonPanel.Controls.Add(this.button2);
			this.ButtonPanel.Controls.Add(this.trackButton);
			this.ButtonPanel.Controls.Add(this.keyPadSettingButton);
			this.ButtonPanel.Controls.Add(this.chipListButton);
			this.ButtonPanel.Controls.Add(this.LoadChipButton);
			this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.Size = new System.Drawing.Size(1982, 106);
			this.ButtonPanel.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button2.Location = new System.Drawing.Point(1636, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(400, 100);
			this.button2.TabIndex = 6;
			this.button2.Text = "Trasy";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// trackButton
			// 
			this.trackButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.trackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trackButton.BackgroundImage")));
			this.trackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.trackButton.Location = new System.Drawing.Point(1230, 12);
			this.trackButton.Name = "trackButton";
			this.trackButton.Size = new System.Drawing.Size(400, 100);
			this.trackButton.TabIndex = 5;
			this.trackButton.Text = "Trasy";
			this.trackButton.UseVisualStyleBackColor = false;
			this.trackButton.Click += new System.EventHandler(this.trackButton_Click);
			// 
			// keyPadSettingButton
			// 
			this.keyPadSettingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.keyPadSettingButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyPadSettingButton.BackgroundImage")));
			this.keyPadSettingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.keyPadSettingButton.Location = new System.Drawing.Point(824, 12);
			this.keyPadSettingButton.Name = "keyPadSettingButton";
			this.keyPadSettingButton.Size = new System.Drawing.Size(400, 100);
			this.keyPadSettingButton.TabIndex = 4;
			this.keyPadSettingButton.Text = "Ustawienia Keypada";
			this.keyPadSettingButton.UseVisualStyleBackColor = false;
			this.keyPadSettingButton.Click += new System.EventHandler(this.keyPadSettingButton_Click);
			// 
			// chipListButton
			// 
			this.chipListButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.chipListButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chipListButton.BackgroundImage")));
			this.chipListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.chipListButton.Location = new System.Drawing.Point(418, 12);
			this.chipListButton.Name = "chipListButton";
			this.chipListButton.Size = new System.Drawing.Size(400, 100);
			this.chipListButton.TabIndex = 3;
			this.chipListButton.Text = "Lista Czipów";
			this.chipListButton.UseVisualStyleBackColor = false;
			this.chipListButton.Click += new System.EventHandler(this.chipListButton_Click);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.ButtonPanel);
			this.splitContainer.Panel1MinSize = 60;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.MainPanel);
			this.splitContainer.Size = new System.Drawing.Size(1982, 1054);
			this.splitContainer.SplitterDistance = 106;
			this.splitContainer.TabIndex = 5;
			// 
			// AdminMainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1982, 1054);
			this.Controls.Add(this.splitContainer);
			this.Name = "AdminMainView";
			this.Text = "AdminMainView";
			this.ButtonPanel.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadChipButton;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel ButtonPanel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Button chipListButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button trackButton;
		private System.Windows.Forms.Button keyPadSettingButton;
	}
}