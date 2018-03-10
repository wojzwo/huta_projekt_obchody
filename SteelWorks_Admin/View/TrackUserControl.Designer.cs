namespace SteelWorks_Admin.View
{
	partial class TrackUserControl
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
			this.label1 = new System.Windows.Forms.Label();
			this.noTrackPlacesListBox = new System.Windows.Forms.ListBox();
			this.trackPlacesListBox = new System.Windows.Forms.ListBox();
			this.trackComboBox = new System.Windows.Forms.ComboBox();
			this.addTrackButton = new System.Windows.Forms.Button();
			this.deletTrackButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Trasa";
			// 
			// noTrackPlacesListBox
			// 
			this.noTrackPlacesListBox.FormattingEnabled = true;
			this.noTrackPlacesListBox.ItemHeight = 31;
			this.noTrackPlacesListBox.Location = new System.Drawing.Point(46, 208);
			this.noTrackPlacesListBox.Name = "noTrackPlacesListBox";
			this.noTrackPlacesListBox.Size = new System.Drawing.Size(450, 655);
			this.noTrackPlacesListBox.TabIndex = 1;
			// 
			// trackPlacesListBox
			// 
			this.trackPlacesListBox.FormattingEnabled = true;
			this.trackPlacesListBox.ItemHeight = 31;
			this.trackPlacesListBox.Location = new System.Drawing.Point(653, 208);
			this.trackPlacesListBox.Name = "trackPlacesListBox";
			this.trackPlacesListBox.Size = new System.Drawing.Size(569, 655);
			this.trackPlacesListBox.TabIndex = 2;
			// 
			// trackComboBox
			// 
			this.trackComboBox.FormattingEnabled = true;
			this.trackComboBox.Location = new System.Drawing.Point(46, 152);
			this.trackComboBox.Name = "trackComboBox";
			this.trackComboBox.Size = new System.Drawing.Size(1176, 39);
			this.trackComboBox.TabIndex = 3;
			// 
			// addTrackButton
			// 
			this.addTrackButton.Location = new System.Drawing.Point(164, 33);
			this.addTrackButton.Name = "addTrackButton";
			this.addTrackButton.Size = new System.Drawing.Size(378, 83);
			this.addTrackButton.TabIndex = 4;
			this.addTrackButton.Text = "Dodaj Trase";
			this.addTrackButton.UseVisualStyleBackColor = true;
			this.addTrackButton.Click += new System.EventHandler(this.addTrackButton_Click);
			// 
			// deletTrackButton
			// 
			this.deletTrackButton.Location = new System.Drawing.Point(653, 33);
			this.deletTrackButton.Name = "deletTrackButton";
			this.deletTrackButton.Size = new System.Drawing.Size(417, 83);
			this.deletTrackButton.TabIndex = 5;
			this.deletTrackButton.Text = "Usuń Trase";
			this.deletTrackButton.UseVisualStyleBackColor = true;
			this.deletTrackButton.Click += new System.EventHandler(this.deletTrackButton_Click);
			// 
			// TrackUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.deletTrackButton);
			this.Controls.Add(this.addTrackButton);
			this.Controls.Add(this.trackComboBox);
			this.Controls.Add(this.trackPlacesListBox);
			this.Controls.Add(this.noTrackPlacesListBox);
			this.Controls.Add(this.label1);
			this.Name = "TrackUserControl";
			this.Size = new System.Drawing.Size(1790, 966);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox noTrackPlacesListBox;
		private System.Windows.Forms.ListBox trackPlacesListBox;
		private System.Windows.Forms.ComboBox trackComboBox;
		private System.Windows.Forms.Button addTrackButton;
		private System.Windows.Forms.Button deletTrackButton;
	}
}
