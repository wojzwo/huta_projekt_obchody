namespace SteelWorks_Admin.View
{
	partial class RoutineUserControl
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateLabel = new System.Windows.Forms.Label();
			this.saveRoutineButton = new System.Windows.Forms.Button();
			this.trackComboBox = new System.Windows.Forms.ComboBox();
			this.teamComboBox = new System.Windows.Forms.ComboBox();
			this.oneTimeRadioButton = new System.Windows.Forms.RadioButton();
			this.repeatedRadioButton = new System.Windows.Forms.RadioButton();
			this.cycleLengthNumeric = new System.Windows.Forms.NumericUpDown();
			this.trackLabel = new System.Windows.Forms.Label();
			this.teamLabel = new System.Windows.Forms.Label();
			this.cycleLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(446, 322);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(555, 38);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// dateLabel
			// 
			this.dateLabel.AutoSize = true;
			this.dateLabel.Location = new System.Drawing.Point(55, 328);
			this.dateLabel.Name = "dateLabel";
			this.dateLabel.Size = new System.Drawing.Size(318, 32);
			this.dateLabel.TabIndex = 1;
			this.dateLabel.Text = "Data rozpoczecia rutyny";
			// 
			// saveRoutineButton
			// 
			this.saveRoutineButton.Location = new System.Drawing.Point(180, 831);
			this.saveRoutineButton.Name = "saveRoutineButton";
			this.saveRoutineButton.Size = new System.Drawing.Size(314, 123);
			this.saveRoutineButton.TabIndex = 2;
			this.saveRoutineButton.Text = "button1";
			this.saveRoutineButton.UseVisualStyleBackColor = true;
			this.saveRoutineButton.Click += new System.EventHandler(this.saveRoutineButton_Click);
			// 
			// trackComboBox
			// 
			this.trackComboBox.FormattingEnabled = true;
			this.trackComboBox.Location = new System.Drawing.Point(446, 139);
			this.trackComboBox.Name = "trackComboBox";
			this.trackComboBox.Size = new System.Drawing.Size(476, 39);
			this.trackComboBox.TabIndex = 3;
			// 
			// teamComboBox
			// 
			this.teamComboBox.FormattingEnabled = true;
			this.teamComboBox.Location = new System.Drawing.Point(446, 227);
			this.teamComboBox.Name = "teamComboBox";
			this.teamComboBox.Size = new System.Drawing.Size(476, 39);
			this.teamComboBox.TabIndex = 4;
			// 
			// oneTimeRadioButton
			// 
			this.oneTimeRadioButton.AutoSize = true;
			this.oneTimeRadioButton.Location = new System.Drawing.Point(311, 419);
			this.oneTimeRadioButton.Name = "oneTimeRadioButton";
			this.oneTimeRadioButton.Size = new System.Drawing.Size(221, 36);
			this.oneTimeRadioButton.TabIndex = 5;
			this.oneTimeRadioButton.TabStop = true;
			this.oneTimeRadioButton.Text = "Jednorazowa";
			this.oneTimeRadioButton.UseVisualStyleBackColor = true;
			this.oneTimeRadioButton.CheckedChanged += new System.EventHandler(this.oneTimeRadioButton_CheckedChanged);
			// 
			// repeatedRadioButton
			// 
			this.repeatedRadioButton.AutoSize = true;
			this.repeatedRadioButton.Location = new System.Drawing.Point(311, 461);
			this.repeatedRadioButton.Name = "repeatedRadioButton";
			this.repeatedRadioButton.Size = new System.Drawing.Size(209, 36);
			this.repeatedRadioButton.TabIndex = 6;
			this.repeatedRadioButton.TabStop = true;
			this.repeatedRadioButton.Text = "Powtarzalna";
			this.repeatedRadioButton.UseVisualStyleBackColor = true;
			this.repeatedRadioButton.CheckedChanged += new System.EventHandler(this.repeatedRadioButton_CheckedChanged);
			// 
			// cycleLengthNumeric
			// 
			this.cycleLengthNumeric.Location = new System.Drawing.Point(583, 461);
			this.cycleLengthNumeric.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
			this.cycleLengthNumeric.Name = "cycleLengthNumeric";
			this.cycleLengthNumeric.Size = new System.Drawing.Size(120, 38);
			this.cycleLengthNumeric.TabIndex = 7;
			// 
			// trackLabel
			// 
			this.trackLabel.AutoSize = true;
			this.trackLabel.Location = new System.Drawing.Point(61, 142);
			this.trackLabel.Name = "trackLabel";
			this.trackLabel.Size = new System.Drawing.Size(87, 32);
			this.trackLabel.TabIndex = 8;
			this.trackLabel.Text = "Trasa";
			// 
			// teamLabel
			// 
			this.teamLabel.AutoSize = true;
			this.teamLabel.Location = new System.Drawing.Point(61, 227);
			this.teamLabel.Name = "teamLabel";
			this.teamLabel.Size = new System.Drawing.Size(265, 32);
			this.teamLabel.TabIndex = 9;
			this.teamLabel.Text = "Grupa pracowników";
			// 
			// cycleLabel
			// 
			this.cycleLabel.AutoSize = true;
			this.cycleLabel.Location = new System.Drawing.Point(61, 435);
			this.cycleLabel.Name = "cycleLabel";
			this.cycleLabel.Size = new System.Drawing.Size(165, 32);
			this.cycleLabel.TabIndex = 10;
			this.cycleLabel.Text = "Cykliczność";
			// 
			// RoutineUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cycleLabel);
			this.Controls.Add(this.teamLabel);
			this.Controls.Add(this.trackLabel);
			this.Controls.Add(this.cycleLengthNumeric);
			this.Controls.Add(this.repeatedRadioButton);
			this.Controls.Add(this.oneTimeRadioButton);
			this.Controls.Add(this.teamComboBox);
			this.Controls.Add(this.trackComboBox);
			this.Controls.Add(this.saveRoutineButton);
			this.Controls.Add(this.dateLabel);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "RoutineUserControl";
			this.Size = new System.Drawing.Size(1815, 1012);
			((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.Button saveRoutineButton;
		private System.Windows.Forms.ComboBox trackComboBox;
		private System.Windows.Forms.ComboBox teamComboBox;
		private System.Windows.Forms.RadioButton oneTimeRadioButton;
		private System.Windows.Forms.RadioButton repeatedRadioButton;
		private System.Windows.Forms.NumericUpDown cycleLengthNumeric;
		private System.Windows.Forms.Label trackLabel;
		private System.Windows.Forms.Label teamLabel;
		private System.Windows.Forms.Label cycleLabel;
	}
}
