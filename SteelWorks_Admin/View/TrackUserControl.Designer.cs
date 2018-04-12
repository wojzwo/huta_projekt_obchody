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
            this.deletTrackButton = new System.Windows.Forms.Button();
            this.toTrackButton = new System.Windows.Forms.Button();
            this.fromTrackButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.trackNameLabel2 = new System.Windows.Forms.Label();
            this.trackNametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackComboBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktualne Trasy:";
            // 
            // noTrackPlacesListBox
            // 
            this.noTrackPlacesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.noTrackPlacesListBox.FormattingEnabled = true;
            this.noTrackPlacesListBox.ItemHeight = 18;
            this.noTrackPlacesListBox.Location = new System.Drawing.Point(536, 125);
            this.noTrackPlacesListBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.noTrackPlacesListBox.Name = "noTrackPlacesListBox";
            this.noTrackPlacesListBox.Size = new System.Drawing.Size(300, 382);
            this.noTrackPlacesListBox.TabIndex = 1;
            // 
            // trackPlacesListBox
            // 
            this.trackPlacesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackPlacesListBox.FormattingEnabled = true;
            this.trackPlacesListBox.ItemHeight = 18;
            this.trackPlacesListBox.Location = new System.Drawing.Point(919, 125);
            this.trackPlacesListBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.trackPlacesListBox.Name = "trackPlacesListBox";
            this.trackPlacesListBox.Size = new System.Drawing.Size(300, 382);
            this.trackPlacesListBox.TabIndex = 2;
            // 
            // deletTrackButton
            // 
            this.deletTrackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deletTrackButton.Location = new System.Drawing.Point(1034, 521);
            this.deletTrackButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.deletTrackButton.Name = "deletTrackButton";
            this.deletTrackButton.Size = new System.Drawing.Size(185, 40);
            this.deletTrackButton.TabIndex = 5;
            this.deletTrackButton.Text = "Usuń Trasę";
            this.deletTrackButton.UseVisualStyleBackColor = true;
            this.deletTrackButton.Click += new System.EventHandler(this.deletTrackButton_Click);
            // 
            // toTrackButton
            // 
            this.toTrackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toTrackButton.Location = new System.Drawing.Point(847, 245);
            this.toTrackButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.toTrackButton.Name = "toTrackButton";
            this.toTrackButton.Size = new System.Drawing.Size(61, 61);
            this.toTrackButton.TabIndex = 7;
            this.toTrackButton.Text = ">>";
            this.toTrackButton.UseVisualStyleBackColor = true;
            this.toTrackButton.Click += new System.EventHandler(this.toTrackButton_Click);
            // 
            // fromTrackButton
            // 
            this.fromTrackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fromTrackButton.Location = new System.Drawing.Point(847, 334);
            this.fromTrackButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.fromTrackButton.Name = "fromTrackButton";
            this.fromTrackButton.Size = new System.Drawing.Size(61, 61);
            this.fromTrackButton.TabIndex = 8;
            this.fromTrackButton.Text = "<<";
            this.fromTrackButton.UseVisualStyleBackColor = true;
            this.fromTrackButton.Click += new System.EventHandler(this.fromTrackButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(536, 521);
            this.saveButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(483, 40);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Zapisz / Dodaj Trasę";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // trackNameLabel2
            // 
            this.trackNameLabel2.AutoSize = true;
            this.trackNameLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackNameLabel2.Location = new System.Drawing.Point(531, 77);
            this.trackNameLabel2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.trackNameLabel2.Name = "trackNameLabel2";
            this.trackNameLabel2.Size = new System.Drawing.Size(148, 29);
            this.trackNameLabel2.TabIndex = 10;
            this.trackNameLabel2.Text = "Nazwa trasy:";
            // 
            // trackNametextBox
            // 
            this.trackNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackNametextBox.Location = new System.Drawing.Point(681, 77);
            this.trackNametextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.trackNametextBox.Name = "trackNametextBox";
            this.trackNametextBox.Size = new System.Drawing.Size(538, 32);
            this.trackNametextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(709, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 37);
            this.label2.TabIndex = 12;
            this.label2.Text = "PANEL EDYCJI >> TRASY";
            // 
            // trackComboBox
            // 
            this.trackComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackComboBox.FormattingEnabled = true;
            this.trackComboBox.ItemHeight = 20;
            this.trackComboBox.Location = new System.Drawing.Point(42, 57);
            this.trackComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.trackComboBox.Name = "trackComboBox";
            this.trackComboBox.Size = new System.Drawing.Size(447, 504);
            this.trackComboBox.TabIndex = 13;
            this.trackComboBox.SelectedIndexChanged += new System.EventHandler(this.trackComboBox_SelectedIndexChanged_1);
            // 
            // TrackUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackNametextBox);
            this.Controls.Add(this.trackNameLabel2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fromTrackButton);
            this.Controls.Add(this.toTrackButton);
            this.Controls.Add(this.deletTrackButton);
            this.Controls.Add(this.trackPlacesListBox);
            this.Controls.Add(this.noTrackPlacesListBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "TrackUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox noTrackPlacesListBox;
		private System.Windows.Forms.ListBox trackPlacesListBox;
		private System.Windows.Forms.Button deletTrackButton;
		private System.Windows.Forms.Button toTrackButton;
		private System.Windows.Forms.Button fromTrackButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label trackNameLabel2;
		private System.Windows.Forms.TextBox trackNametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox trackComboBox;
    }
}
