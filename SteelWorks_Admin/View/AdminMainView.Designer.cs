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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.teamButton = new System.Windows.Forms.Button();
            this.keyPadSettingButton = new System.Windows.Forms.Button();
            this.trackButton = new System.Windows.Forms.Button();
            this.chipListButton = new System.Windows.Forms.Button();
            this.mailButton = new System.Windows.Forms.Button();
            this.routineButton = new System.Windows.Forms.Button();
            this.LoadChipButton = new System.Windows.Forms.Button();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1263, 599);
            this.MainPanel.TabIndex = 3;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonPanel.Controls.Add(this.pictureBox1);
            this.ButtonPanel.Controls.Add(this.teamButton);
            this.ButtonPanel.Controls.Add(this.keyPadSettingButton);
            this.ButtonPanel.Controls.Add(this.trackButton);
            this.ButtonPanel.Controls.Add(this.chipListButton);
            this.ButtonPanel.Controls.Add(this.mailButton);
            this.ButtonPanel.Controls.Add(this.routineButton);
            this.ButtonPanel.Controls.Add(this.LoadChipButton);
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1264, 80);
            this.ButtonPanel.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(1);
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
            this.splitContainer.Size = new System.Drawing.Size(1264, 681);
            this.splitContainer.SplitterDistance = 80;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SteelWorks_Admin.Properties.Resources.acelor;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 57);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // teamButton
            // 
            this.teamButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.teamButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("teamButton.BackgroundImage")));
            this.teamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.teamButton.Location = new System.Drawing.Point(806, 10);
            this.teamButton.Margin = new System.Windows.Forms.Padding(1);
            this.teamButton.Name = "teamButton";
            this.teamButton.Size = new System.Drawing.Size(140, 60);
            this.teamButton.TabIndex = 6;
            this.teamButton.Text = "Grupy Pracowników";
            this.teamButton.UseVisualStyleBackColor = false;
            this.teamButton.Click += new System.EventHandler(this.teamButton_Click);
            // 
            // keyPadSettingButton
            // 
            this.keyPadSettingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.keyPadSettingButton.BackgroundImage = global::SteelWorks_Admin.Properties.Resources.Button;
            this.keyPadSettingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.keyPadSettingButton.Location = new System.Drawing.Point(499, 10);
            this.keyPadSettingButton.Margin = new System.Windows.Forms.Padding(1);
            this.keyPadSettingButton.Name = "keyPadSettingButton";
            this.keyPadSettingButton.Size = new System.Drawing.Size(140, 60);
            this.keyPadSettingButton.TabIndex = 4;
            this.keyPadSettingButton.Text = "Ustawienia Keypada";
            this.keyPadSettingButton.UseVisualStyleBackColor = false;
            this.keyPadSettingButton.Click += new System.EventHandler(this.keyPadSettingButton_Click);
            // 
            // trackButton
            // 
            this.trackButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trackButton.BackgroundImage = global::SteelWorks_Admin.Properties.Resources.Button;
            this.trackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackButton.Location = new System.Drawing.Point(654, 10);
            this.trackButton.Margin = new System.Windows.Forms.Padding(1);
            this.trackButton.Name = "trackButton";
            this.trackButton.Size = new System.Drawing.Size(140, 60);
            this.trackButton.TabIndex = 5;
            this.trackButton.Text = "Trasy";
            this.trackButton.UseVisualStyleBackColor = false;
            this.trackButton.Click += new System.EventHandler(this.trackButton_Click);
            // 
            // chipListButton
            // 
            this.chipListButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chipListButton.BackgroundImage = global::SteelWorks_Admin.Properties.Resources.Button;
            this.chipListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chipListButton.Location = new System.Drawing.Point(345, 10);
            this.chipListButton.Margin = new System.Windows.Forms.Padding(1);
            this.chipListButton.Name = "chipListButton";
            this.chipListButton.Size = new System.Drawing.Size(140, 60);
            this.chipListButton.TabIndex = 3;
            this.chipListButton.Text = "Lista Czipów";
            this.chipListButton.UseVisualStyleBackColor = false;
            this.chipListButton.Click += new System.EventHandler(this.chipListButton_Click);
            // 
            // mailButton
            // 
            this.mailButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mailButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mailButton.BackgroundImage")));
            this.mailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mailButton.Location = new System.Drawing.Point(1113, 9);
            this.mailButton.Margin = new System.Windows.Forms.Padding(1);
            this.mailButton.Name = "mailButton";
            this.mailButton.Size = new System.Drawing.Size(140, 60);
            this.mailButton.TabIndex = 8;
            this.mailButton.Text = "Ustawienia Maili";
            this.mailButton.UseVisualStyleBackColor = false;
            this.mailButton.Click += new System.EventHandler(this.mailButton_Click);
            // 
            // routineButton
            // 
            this.routineButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.routineButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("routineButton.BackgroundImage")));
            this.routineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routineButton.Location = new System.Drawing.Point(960, 9);
            this.routineButton.Margin = new System.Windows.Forms.Padding(1);
            this.routineButton.Name = "routineButton";
            this.routineButton.Size = new System.Drawing.Size(140, 60);
            this.routineButton.TabIndex = 7;
            this.routineButton.Text = "Rutyny";
            this.routineButton.UseVisualStyleBackColor = false;
            this.routineButton.Click += new System.EventHandler(this.routineButton_Click);
            // 
            // LoadChipButton
            // 
            this.LoadChipButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoadChipButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadChipButton.BackgroundImage")));
            this.LoadChipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadChipButton.Location = new System.Drawing.Point(193, 10);
            this.LoadChipButton.Margin = new System.Windows.Forms.Padding(1);
            this.LoadChipButton.Name = "LoadChipButton";
            this.LoadChipButton.Size = new System.Drawing.Size(140, 60);
            this.LoadChipButton.TabIndex = 0;
            this.LoadChipButton.Text = "Wczytaj Chip";
            this.LoadChipButton.UseVisualStyleBackColor = false;
            this.LoadChipButton.Click += new System.EventHandler(this.LoadChipButton_Click);
            // 
            // AdminMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "AdminMainView";
            this.Text = "Obchody - Panel administratora";
            this.ButtonPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button teamButton;
        private System.Windows.Forms.Button keyPadSettingButton;
        private System.Windows.Forms.Button trackButton;
        private System.Windows.Forms.Button chipListButton;
        private System.Windows.Forms.Button mailButton;
        private System.Windows.Forms.Button routineButton;
        private System.Windows.Forms.Button LoadChipButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}