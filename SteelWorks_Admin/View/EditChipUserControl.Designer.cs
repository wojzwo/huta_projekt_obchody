﻿namespace SteelWorks_Admin.View
{
	partial class EditChipUserControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.chipIdName = new System.Windows.Forms.Label();
            this.chipIdText = new System.Windows.Forms.TextBox();
            this.ReloadChipFromDBButton = new System.Windows.Forms.Button();
            this.chipStateComboBox = new System.Windows.Forms.ComboBox();
            this.chipTypeName = new System.Windows.Forms.Label();
            this.chipStringName = new System.Windows.Forms.Label();
            this.chipStringText = new System.Windows.Forms.TextBox();
            this.addChangeButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.chipAreaName = new System.Windows.Forms.Label();
            this.chipAreaString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chipIdName
            // 
            this.chipIdName.AutoSize = true;
            this.chipIdName.Location = new System.Drawing.Point(8, 12);
            this.chipIdName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.chipIdName.Name = "chipIdName";
            this.chipIdName.Size = new System.Drawing.Size(42, 13);
            this.chipIdName.TabIndex = 0;
            this.chipIdName.Text = "Chip ID";
            // 
            // chipIdText
            // 
            this.chipIdText.Location = new System.Drawing.Point(51, 11);
            this.chipIdText.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chipIdText.Name = "chipIdText";
            this.chipIdText.Size = new System.Drawing.Size(61, 20);
            this.chipIdText.TabIndex = 2;
            // 
            // ReloadChipFromDBButton
            // 
            this.ReloadChipFromDBButton.Location = new System.Drawing.Point(117, 6);
            this.ReloadChipFromDBButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ReloadChipFromDBButton.Name = "ReloadChipFromDBButton";
            this.ReloadChipFromDBButton.Size = new System.Drawing.Size(188, 25);
            this.ReloadChipFromDBButton.TabIndex = 3;
            this.ReloadChipFromDBButton.Text = "Wczytaj Dane z Bazy";
            this.ReloadChipFromDBButton.UseVisualStyleBackColor = true;
            this.ReloadChipFromDBButton.Click += new System.EventHandler(this.ReloadChipFromDBButton_Click);
            // 
            // chipStateComboBox
            // 
            this.chipStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chipStateComboBox.FormattingEnabled = true;
            this.chipStateComboBox.Items.AddRange(new object[] {
            "",
            "Miejsce",
            "Pracownik"});
            this.chipStateComboBox.Location = new System.Drawing.Point(51, 39);
            this.chipStateComboBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chipStateComboBox.Name = "chipStateComboBox";
            this.chipStateComboBox.Size = new System.Drawing.Size(102, 21);
            this.chipStateComboBox.TabIndex = 4;
            this.chipStateComboBox.SelectedIndexChanged += new System.EventHandler(this.chipStateComboBox_SelectedIndexChanged);
            // 
            // chipTypeName
            // 
            this.chipTypeName.AutoSize = true;
            this.chipTypeName.Location = new System.Drawing.Point(8, 39);
            this.chipTypeName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.chipTypeName.Name = "chipTypeName";
            this.chipTypeName.Size = new System.Drawing.Size(25, 13);
            this.chipTypeName.TabIndex = 5;
            this.chipTypeName.Text = "Typ";
            // 
            // chipStringName
            // 
            this.chipStringName.AutoSize = true;
            this.chipStringName.Location = new System.Drawing.Point(10, 63);
            this.chipStringName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.chipStringName.Name = "chipStringName";
            this.chipStringName.Size = new System.Drawing.Size(40, 13);
            this.chipStringName.TabIndex = 6;
            this.chipStringName.Text = "Nazwa";
            // 
            // chipStringText
            // 
            this.chipStringText.Location = new System.Drawing.Point(93, 60);
            this.chipStringText.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.chipStringText.Name = "chipStringText";
            this.chipStringText.Size = new System.Drawing.Size(215, 20);
            this.chipStringText.TabIndex = 7;
            // 
            // addChangeButton
            // 
            this.addChangeButton.Location = new System.Drawing.Point(11, 109);
            this.addChangeButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.addChangeButton.Name = "addChangeButton";
            this.addChangeButton.Size = new System.Drawing.Size(150, 50);
            this.addChangeButton.TabIndex = 8;
            this.addChangeButton.Text = "Dodaj/Zmień Chip";
            this.addChangeButton.UseVisualStyleBackColor = true;
            this.addChangeButton.Click += new System.EventHandler(this.addChangeButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(163, 109);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(150, 50);
            this.RemoveButton.TabIndex = 9;
            this.RemoveButton.Text = "Usuń Chip";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // chipAreaName
            // 
            this.chipAreaName.AutoSize = true;
            this.chipAreaName.Location = new System.Drawing.Point(10, 86);
            this.chipAreaName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.chipAreaName.Name = "chipAreaName";
            this.chipAreaName.Size = new System.Drawing.Size(32, 13);
            this.chipAreaName.TabIndex = 10;
            this.chipAreaName.Text = "Dział";
            // 
            // chipAreaString
            // 
            this.chipAreaString.Location = new System.Drawing.Point(93, 82);
            this.chipAreaString.Margin = new System.Windows.Forms.Padding(1);
            this.chipAreaString.Name = "chipAreaString";
            this.chipAreaString.Size = new System.Drawing.Size(215, 20);
            this.chipAreaString.TabIndex = 11;
            // 
            // EditChipUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chipAreaString);
            this.Controls.Add(this.chipAreaName);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.addChangeButton);
            this.Controls.Add(this.chipStringText);
            this.Controls.Add(this.chipStringName);
            this.Controls.Add(this.chipTypeName);
            this.Controls.Add(this.chipStateComboBox);
            this.Controls.Add(this.ReloadChipFromDBButton);
            this.Controls.Add(this.chipIdText);
            this.Controls.Add(this.chipIdName);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "EditChipUserControl";
            this.Size = new System.Drawing.Size(313, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label chipIdName;
		private System.Windows.Forms.Button ReloadChipFromDBButton;
		private System.Windows.Forms.ComboBox chipStateComboBox;
		private System.Windows.Forms.Label chipTypeName;
		private System.Windows.Forms.Label chipStringName;
		private System.Windows.Forms.TextBox chipStringText;
		private System.Windows.Forms.TextBox chipIdText;
		public System.Windows.Forms.Button addChangeButton;
		public System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label chipAreaName;
        private System.Windows.Forms.TextBox chipAreaString;
    }
}
