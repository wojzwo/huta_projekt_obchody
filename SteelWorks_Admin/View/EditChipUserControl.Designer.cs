namespace SteelWorks_Admin.View
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
			this.SuspendLayout();
			// 
			// chipIdName
			// 
			this.chipIdName.AutoSize = true;
			this.chipIdName.Location = new System.Drawing.Point(21, 29);
			this.chipIdName.Name = "chipIdName";
			this.chipIdName.Size = new System.Drawing.Size(108, 32);
			this.chipIdName.TabIndex = 0;
			this.chipIdName.Text = "Chip ID";
			// 
			// chipIdText
			// 
			this.chipIdText.Location = new System.Drawing.Point(136, 26);
			this.chipIdText.Name = "chipIdText";
			this.chipIdText.Size = new System.Drawing.Size(157, 38);
			this.chipIdText.TabIndex = 2;
			// 
			// ReloadChipFromDBButton
			// 
			this.ReloadChipFromDBButton.Location = new System.Drawing.Point(313, 14);
			this.ReloadChipFromDBButton.Name = "ReloadChipFromDBButton";
			this.ReloadChipFromDBButton.Size = new System.Drawing.Size(500, 60);
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
			this.chipStateComboBox.Location = new System.Drawing.Point(136, 93);
			this.chipStateComboBox.Name = "chipStateComboBox";
			this.chipStateComboBox.Size = new System.Drawing.Size(266, 39);
			this.chipStateComboBox.TabIndex = 4;
			this.chipStateComboBox.SelectedIndexChanged += new System.EventHandler(this.chipStateComboBox_SelectedIndexChanged);
			// 
			// chipTypeName
			// 
			this.chipTypeName.AutoSize = true;
			this.chipTypeName.Location = new System.Drawing.Point(21, 93);
			this.chipTypeName.Name = "chipTypeName";
			this.chipTypeName.Size = new System.Drawing.Size(62, 32);
			this.chipTypeName.TabIndex = 5;
			this.chipTypeName.Text = "Typ";
			// 
			// chipStringName
			// 
			this.chipStringName.AutoSize = true;
			this.chipStringName.Location = new System.Drawing.Point(27, 150);
			this.chipStringName.Name = "chipStringName";
			this.chipStringName.Size = new System.Drawing.Size(101, 32);
			this.chipStringName.TabIndex = 6;
			this.chipStringName.Text = "Nazwa";
			// 
			// chipStringText
			// 
			this.chipStringText.Location = new System.Drawing.Point(247, 144);
			this.chipStringText.Name = "chipStringText";
			this.chipStringText.Size = new System.Drawing.Size(566, 38);
			this.chipStringText.TabIndex = 7;
			// 
			// addChangeButton
			// 
			this.addChangeButton.Location = new System.Drawing.Point(27, 202);
			this.addChangeButton.Name = "addChangeButton";
			this.addChangeButton.Size = new System.Drawing.Size(400, 120);
			this.addChangeButton.TabIndex = 8;
			this.addChangeButton.Text = "Dodaj/Zmień Chip";
			this.addChangeButton.UseVisualStyleBackColor = true;
			this.addChangeButton.Click += new System.EventHandler(this.addChangeButton_Click);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(432, 202);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(400, 120);
			this.RemoveButton.TabIndex = 9;
			this.RemoveButton.Text = "Usuń Chip";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// EditChipUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.addChangeButton);
			this.Controls.Add(this.chipStringText);
			this.Controls.Add(this.chipStringName);
			this.Controls.Add(this.chipTypeName);
			this.Controls.Add(this.chipStateComboBox);
			this.Controls.Add(this.ReloadChipFromDBButton);
			this.Controls.Add(this.chipIdText);
			this.Controls.Add(this.chipIdName);
			this.Name = "EditChipUserControl";
			this.Size = new System.Drawing.Size(835, 344);
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
	}
}
