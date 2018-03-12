namespace SteelWorks_Admin.View
{
	partial class TeamUserControl
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
			this.trackNametextBox = new System.Windows.Forms.TextBox();
			this.trackNameLabel2 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.fromTrackButton = new System.Windows.Forms.Button();
			this.toTrackButton = new System.Windows.Forms.Button();
			this.deletTrackButton = new System.Windows.Forms.Button();
			this.addTrackButton = new System.Windows.Forms.Button();
			this.trackComboBox = new System.Windows.Forms.ComboBox();
			this.trackPlacesListBox = new System.Windows.Forms.ListBox();
			this.noTrackPlacesListBox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.addTrackUserControl1 = new SteelWorks_Admin.View.addTrackUserControl();
			this.SuspendLayout();
			// 
			// trackNametextBox
			// 
			this.trackNametextBox.Location = new System.Drawing.Point(193, 197);
			this.trackNametextBox.Name = "trackNametextBox";
			this.trackNametextBox.Size = new System.Drawing.Size(921, 38);
			this.trackNametextBox.TabIndex = 23;
			// 
			// trackNameLabel2
			// 
			this.trackNameLabel2.AutoSize = true;
			this.trackNameLabel2.Location = new System.Drawing.Point(9, 197);
			this.trackNameLabel2.Name = "trackNameLabel2";
			this.trackNameLabel2.Size = new System.Drawing.Size(177, 32);
			this.trackNameLabel2.TabIndex = 22;
			this.trackNameLabel2.Text = "Nazwa trasy:";
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(328, 906);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(441, 85);
			this.saveButton.TabIndex = 21;
			this.saveButton.Text = "Zapisz";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// fromTrackButton
			// 
			this.fromTrackButton.Location = new System.Drawing.Point(494, 621);
			this.fromTrackButton.Name = "fromTrackButton";
			this.fromTrackButton.Size = new System.Drawing.Size(90, 90);
			this.fromTrackButton.TabIndex = 20;
			this.fromTrackButton.Text = "<<";
			this.fromTrackButton.UseVisualStyleBackColor = true;
			this.fromTrackButton.Click += new System.EventHandler(this.fromTrackButton_Click);
			// 
			// toTrackButton
			// 
			this.toTrackButton.Location = new System.Drawing.Point(494, 479);
			this.toTrackButton.Name = "toTrackButton";
			this.toTrackButton.Size = new System.Drawing.Size(90, 90);
			this.toTrackButton.TabIndex = 19;
			this.toTrackButton.Text = ">>";
			this.toTrackButton.UseVisualStyleBackColor = true;
			this.toTrackButton.Click += new System.EventHandler(this.toTrackButton_Click);
			// 
			// deletTrackButton
			// 
			this.deletTrackButton.Location = new System.Drawing.Point(622, 21);
			this.deletTrackButton.Name = "deletTrackButton";
			this.deletTrackButton.Size = new System.Drawing.Size(417, 83);
			this.deletTrackButton.TabIndex = 18;
			this.deletTrackButton.Text = "Usuń Trase";
			this.deletTrackButton.UseVisualStyleBackColor = true;
			this.deletTrackButton.Click += new System.EventHandler(this.deletTrackButton_Click);
			// 
			// addTrackButton
			// 
			this.addTrackButton.Location = new System.Drawing.Point(167, 21);
			this.addTrackButton.Name = "addTrackButton";
			this.addTrackButton.Size = new System.Drawing.Size(378, 83);
			this.addTrackButton.TabIndex = 17;
			this.addTrackButton.Text = "Dodaj Trase";
			this.addTrackButton.UseVisualStyleBackColor = true;
			this.addTrackButton.Click += new System.EventHandler(this.addTrackButton_Click);
			// 
			// trackComboBox
			// 
			this.trackComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.trackComboBox.FormattingEnabled = true;
			this.trackComboBox.Items.AddRange(new object[] {
            "test"});
			this.trackComboBox.Location = new System.Drawing.Point(15, 140);
			this.trackComboBox.Name = "trackComboBox";
			this.trackComboBox.Size = new System.Drawing.Size(1176, 39);
			this.trackComboBox.TabIndex = 16;
			this.trackComboBox.SelectedIndexChanged += new System.EventHandler(this.trackComboBox_SelectedIndexChanged);
			// 
			// trackPlacesListBox
			// 
			this.trackPlacesListBox.FormattingEnabled = true;
			this.trackPlacesListBox.ItemHeight = 31;
			this.trackPlacesListBox.Location = new System.Drawing.Point(622, 245);
			this.trackPlacesListBox.Name = "trackPlacesListBox";
			this.trackPlacesListBox.Size = new System.Drawing.Size(569, 655);
			this.trackPlacesListBox.TabIndex = 15;
			// 
			// noTrackPlacesListBox
			// 
			this.noTrackPlacesListBox.FormattingEnabled = true;
			this.noTrackPlacesListBox.ItemHeight = 31;
			this.noTrackPlacesListBox.Location = new System.Drawing.Point(15, 245);
			this.noTrackPlacesListBox.Name = "noTrackPlacesListBox";
			this.noTrackPlacesListBox.Size = new System.Drawing.Size(450, 655);
			this.noTrackPlacesListBox.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 32);
			this.label1.TabIndex = 13;
			this.label1.Text = "Trasa";
			// 
			// addTrackUserControl1
			// 
			this.addTrackUserControl1.Location = new System.Drawing.Point(1062, 266);
			this.addTrackUserControl1.Name = "addTrackUserControl1";
			this.addTrackUserControl1.Size = new System.Drawing.Size(1248, 557);
			this.addTrackUserControl1.TabIndex = 24;
			this.addTrackUserControl1.Visible = false;
			// 
			// TeamUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.addTrackUserControl1);
			this.Controls.Add(this.trackNametextBox);
			this.Controls.Add(this.trackNameLabel2);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.fromTrackButton);
			this.Controls.Add(this.toTrackButton);
			this.Controls.Add(this.deletTrackButton);
			this.Controls.Add(this.addTrackButton);
			this.Controls.Add(this.trackComboBox);
			this.Controls.Add(this.trackPlacesListBox);
			this.Controls.Add(this.noTrackPlacesListBox);
			this.Controls.Add(this.label1);
			this.Name = "TeamUserControl";
			this.Size = new System.Drawing.Size(2029, 1039);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private addTrackUserControl addTrackUserControl1;
		private System.Windows.Forms.TextBox trackNametextBox;
		private System.Windows.Forms.Label trackNameLabel2;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button fromTrackButton;
		private System.Windows.Forms.Button toTrackButton;
		private System.Windows.Forms.Button deletTrackButton;
		private System.Windows.Forms.Button addTrackButton;
		private System.Windows.Forms.ComboBox trackComboBox;
		private System.Windows.Forms.ListBox trackPlacesListBox;
		private System.Windows.Forms.ListBox noTrackPlacesListBox;
		private System.Windows.Forms.Label label1;
	}
}
