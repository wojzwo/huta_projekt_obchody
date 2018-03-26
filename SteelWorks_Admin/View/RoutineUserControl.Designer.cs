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
			this.beginDateTime = new System.Windows.Forms.DateTimePicker();
			this.dateLabel = new System.Windows.Forms.Label();
			this.saveRoutineButton = new System.Windows.Forms.Button();
			this.trackComboBox = new System.Windows.Forms.ComboBox();
			this.teamComboBox = new System.Windows.Forms.ComboBox();
			this.cycleLengthNumeric = new System.Windows.Forms.NumericUpDown();
			this.trackLabel = new System.Windows.Forms.Label();
			this.teamLabel = new System.Windows.Forms.Label();
			this.cycleLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.repeatedCheckBox = new System.Windows.Forms.CheckBox();
			this.shiftCheckBox = new System.Windows.Forms.CheckBox();
			this.shiftLabel = new System.Windows.Forms.Label();
			this.shiftNumeric = new System.Windows.Forms.NumericUpDown();
			this.shift2Label = new System.Windows.Forms.Label();
			this._64buttonUserControl1 = new SteelWorks_Admin.View._64buttonUserControl();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.cycleLengthLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.shiftNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// beginDateTime
			// 
			this.beginDateTime.Location = new System.Drawing.Point(362, 255);
			this.beginDateTime.Name = "beginDateTime";
			this.beginDateTime.Size = new System.Drawing.Size(780, 38);
			this.beginDateTime.TabIndex = 0;
			// 
			// dateLabel
			// 
			this.dateLabel.AutoSize = true;
			this.dateLabel.Location = new System.Drawing.Point(17, 255);
			this.dateLabel.Name = "dateLabel";
			this.dateLabel.Size = new System.Drawing.Size(318, 32);
			this.dateLabel.TabIndex = 1;
			this.dateLabel.Text = "Data rozpoczecia rutyny";
			// 
			// saveRoutineButton
			// 
			this.saveRoutineButton.Location = new System.Drawing.Point(25, 734);
			this.saveRoutineButton.Name = "saveRoutineButton";
			this.saveRoutineButton.Size = new System.Drawing.Size(314, 123);
			this.saveRoutineButton.TabIndex = 2;
			this.saveRoutineButton.Text = "Zapisz/Dodaj";
			this.saveRoutineButton.UseVisualStyleBackColor = true;
			this.saveRoutineButton.Click += new System.EventHandler(this.saveRoutineButton_Click);
			// 
			// trackComboBox
			// 
			this.trackComboBox.FormattingEnabled = true;
			this.trackComboBox.Location = new System.Drawing.Point(164, 84);
			this.trackComboBox.Name = "trackComboBox";
			this.trackComboBox.Size = new System.Drawing.Size(989, 39);
			this.trackComboBox.TabIndex = 3;
			// 
			// teamComboBox
			// 
			this.teamComboBox.FormattingEnabled = true;
			this.teamComboBox.Location = new System.Drawing.Point(288, 173);
			this.teamComboBox.Name = "teamComboBox";
			this.teamComboBox.Size = new System.Drawing.Size(865, 39);
			this.teamComboBox.TabIndex = 4;
			// 
			// cycleLengthNumeric
			// 
			this.cycleLengthNumeric.Location = new System.Drawing.Point(734, 323);
			this.cycleLengthNumeric.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
			this.cycleLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cycleLengthNumeric.Name = "cycleLengthNumeric";
			this.cycleLengthNumeric.Size = new System.Drawing.Size(120, 38);
			this.cycleLengthNumeric.TabIndex = 7;
			this.cycleLengthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cycleLengthNumeric.ValueChanged += new System.EventHandler(this.cycleLengthNumeric_ValueChanged);
			// 
			// trackLabel
			// 
			this.trackLabel.AutoSize = true;
			this.trackLabel.Location = new System.Drawing.Point(19, 87);
			this.trackLabel.Name = "trackLabel";
			this.trackLabel.Size = new System.Drawing.Size(87, 32);
			this.trackLabel.TabIndex = 8;
			this.trackLabel.Text = "Trasa";
			// 
			// teamLabel
			// 
			this.teamLabel.AutoSize = true;
			this.teamLabel.Location = new System.Drawing.Point(17, 173);
			this.teamLabel.Name = "teamLabel";
			this.teamLabel.Size = new System.Drawing.Size(265, 32);
			this.teamLabel.TabIndex = 9;
			this.teamLabel.Text = "Grupa pracowników";
			// 
			// cycleLabel
			// 
			this.cycleLabel.AutoSize = true;
			this.cycleLabel.Location = new System.Drawing.Point(19, 329);
			this.cycleLabel.Name = "cycleLabel";
			this.cycleLabel.Size = new System.Drawing.Size(165, 32);
			this.cycleLabel.TabIndex = 10;
			this.cycleLabel.Text = "Cykliczność";
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(19, 21);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(101, 32);
			this.nameLabel.TabIndex = 12;
			this.nameLabel.Text = "Nazwa";
			// 
			// repeatedCheckBox
			// 
			this.repeatedCheckBox.AutoSize = true;
			this.repeatedCheckBox.Location = new System.Drawing.Point(237, 329);
			this.repeatedCheckBox.Name = "repeatedCheckBox";
			this.repeatedCheckBox.Size = new System.Drawing.Size(210, 36);
			this.repeatedCheckBox.TabIndex = 13;
			this.repeatedCheckBox.Text = "Powtarzalna";
			this.repeatedCheckBox.UseVisualStyleBackColor = true;
			this.repeatedCheckBox.CheckedChanged += new System.EventHandler(this.repeatedCheckBox_CheckedChanged);
			// 
			// shiftCheckBox
			// 
			this.shiftCheckBox.AutoSize = true;
			this.shiftCheckBox.Location = new System.Drawing.Point(362, 656);
			this.shiftCheckBox.Name = "shiftCheckBox";
			this.shiftCheckBox.Size = new System.Drawing.Size(34, 33);
			this.shiftCheckBox.TabIndex = 16;
			this.shiftCheckBox.UseVisualStyleBackColor = true;
			this.shiftCheckBox.CheckedChanged += new System.EventHandler(this.shiftCheckBox_CheckedChanged);
			// 
			// shiftLabel
			// 
			this.shiftLabel.AutoSize = true;
			this.shiftLabel.Location = new System.Drawing.Point(19, 656);
			this.shiftLabel.Name = "shiftLabel";
			this.shiftLabel.Size = new System.Drawing.Size(300, 32);
			this.shiftLabel.TabIndex = 15;
			this.shiftLabel.Text = "Przypisana do zmiany:";
			// 
			// shiftNumeric
			// 
			this.shiftNumeric.Location = new System.Drawing.Point(570, 657);
			this.shiftNumeric.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.shiftNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.shiftNumeric.Name = "shiftNumeric";
			this.shiftNumeric.Size = new System.Drawing.Size(120, 38);
			this.shiftNumeric.TabIndex = 14;
			this.shiftNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// shift2Label
			// 
			this.shift2Label.AutoSize = true;
			this.shift2Label.Location = new System.Drawing.Point(430, 657);
			this.shift2Label.Name = "shift2Label";
			this.shift2Label.Size = new System.Drawing.Size(110, 32);
			this.shift2Label.TabIndex = 17;
			this.shift2Label.Text = "Zmiana";
			// 
			// _64buttonUserControl1
			// 
			this._64buttonUserControl1.Location = new System.Drawing.Point(25, 401);
			this._64buttonUserControl1.Name = "_64buttonUserControl1";
			this._64buttonUserControl1.Size = new System.Drawing.Size(1796, 233);
			this._64buttonUserControl1.TabIndex = 11;
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(164, 15);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(989, 38);
			this.nameTextBox.TabIndex = 18;
			// 
			// cycleLengthLabel
			// 
			this.cycleLengthLabel.AutoSize = true;
			this.cycleLengthLabel.Location = new System.Drawing.Point(495, 329);
			this.cycleLengthLabel.Name = "cycleLengthLabel";
			this.cycleLengthLabel.Size = new System.Drawing.Size(190, 32);
			this.cycleLengthLabel.TabIndex = 19;
			this.cycleLengthLabel.Text = "Długość cyklu";
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(362, 734);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(314, 123);
			this.cancelButton.TabIndex = 20;
			this.cancelButton.Text = "Anuluj";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// RoutineUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.cycleLengthLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.shift2Label);
			this.Controls.Add(this.shiftCheckBox);
			this.Controls.Add(this.shiftLabel);
			this.Controls.Add(this.shiftNumeric);
			this.Controls.Add(this.repeatedCheckBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this._64buttonUserControl1);
			this.Controls.Add(this.cycleLabel);
			this.Controls.Add(this.teamLabel);
			this.Controls.Add(this.trackLabel);
			this.Controls.Add(this.cycleLengthNumeric);
			this.Controls.Add(this.teamComboBox);
			this.Controls.Add(this.trackComboBox);
			this.Controls.Add(this.saveRoutineButton);
			this.Controls.Add(this.dateLabel);
			this.Controls.Add(this.beginDateTime);
			this.Name = "RoutineUserControl";
			this.Size = new System.Drawing.Size(2041, 1138);
			((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.shiftNumeric)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker beginDateTime;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.Button saveRoutineButton;
		private System.Windows.Forms.ComboBox trackComboBox;
		private System.Windows.Forms.ComboBox teamComboBox;
		private System.Windows.Forms.NumericUpDown cycleLengthNumeric;
		private System.Windows.Forms.Label trackLabel;
		private System.Windows.Forms.Label teamLabel;
		private System.Windows.Forms.Label cycleLabel;
		private _64buttonUserControl _64buttonUserControl1;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.CheckBox repeatedCheckBox;
		private System.Windows.Forms.CheckBox shiftCheckBox;
		private System.Windows.Forms.Label shiftLabel;
		private System.Windows.Forms.NumericUpDown shiftNumeric;
		private System.Windows.Forms.Label shift2Label;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label cycleLengthLabel;
		private System.Windows.Forms.Button cancelButton;
	}
}
