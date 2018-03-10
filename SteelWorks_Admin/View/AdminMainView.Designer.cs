namespace SteelWorks_Admin.View
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.LoadChipButton.Location = new System.Drawing.Point(4, 5);
            this.LoadChipButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.LoadChipButton.Name = "LoadChipButton";
            this.LoadChipButton.Size = new System.Drawing.Size(150, 42);
            this.LoadChipButton.TabIndex = 0;
            this.LoadChipButton.Text = "Wczytaj Chip";
            this.LoadChipButton.UseVisualStyleBackColor = false;
            this.LoadChipButton.Click += new System.EventHandler(this.LoadChipButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(722, 380);
            this.MainPanel.TabIndex = 3;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonPanel.Controls.Add(this.button2);
            this.ButtonPanel.Controls.Add(this.button1);
            this.ButtonPanel.Controls.Add(this.keyPadSettingButton);
            this.ButtonPanel.Controls.Add(this.chipListButton);
            this.ButtonPanel.Controls.Add(this.LoadChipButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(722, 60);
            this.ButtonPanel.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(614, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 42);
            this.button2.TabIndex = 6;
            this.button2.Text = "Trasy";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(461, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trasy";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // keyPadSettingButton
            // 
            this.keyPadSettingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.keyPadSettingButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyPadSettingButton.BackgroundImage")));
            this.keyPadSettingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.keyPadSettingButton.Location = new System.Drawing.Point(309, 5);
            this.keyPadSettingButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.keyPadSettingButton.Name = "keyPadSettingButton";
            this.keyPadSettingButton.Size = new System.Drawing.Size(150, 42);
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
            this.chipListButton.Location = new System.Drawing.Point(157, 5);
            this.chipListButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chipListButton.Name = "chipListButton";
            this.chipListButton.Size = new System.Drawing.Size(150, 42);
            this.chipListButton.TabIndex = 3;
            this.chipListButton.Text = "Lista Czipów";
            this.chipListButton.UseVisualStyleBackColor = false;
            this.chipListButton.Click += new System.EventHandler(this.chipListButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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
            this.splitContainer.Size = new System.Drawing.Size(722, 442);
            this.splitContainer.SplitterDistance = 60;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 5;
            // 
            // AdminMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 442);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button keyPadSettingButton;
	}
}