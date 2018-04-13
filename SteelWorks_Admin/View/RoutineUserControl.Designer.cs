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
            this.cycleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.repeatedCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftNumeric = new System.Windows.Forms.NumericUpDown();
            this.shift2Label = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.cycleLengthLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.team0CheckBox = new System.Windows.Forms.CheckBox();
            this._64buttonUserControl1 = new SteelWorks_Admin.View._64buttonUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // beginDateTime
            // 
            this.beginDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.beginDateTime.Location = new System.Drawing.Point(210, 156);
            this.beginDateTime.Margin = new System.Windows.Forms.Padding(1);
            this.beginDateTime.Name = "beginDateTime";
            this.beginDateTime.Size = new System.Drawing.Size(504, 32);
            this.beginDateTime.TabIndex = 0;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateLabel.Location = new System.Drawing.Point(28, 159);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(180, 26);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Data rozpoczecia";
            // 
            // saveRoutineButton
            // 
            this.saveRoutineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveRoutineButton.Location = new System.Drawing.Point(33, 515);
            this.saveRoutineButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveRoutineButton.Name = "saveRoutineButton";
            this.saveRoutineButton.Size = new System.Drawing.Size(681, 52);
            this.saveRoutineButton.TabIndex = 2;
            this.saveRoutineButton.Text = "Zapisz/Dodaj";
            this.saveRoutineButton.UseVisualStyleBackColor = true;
            this.saveRoutineButton.Click += new System.EventHandler(this.saveRoutineButton_Click);
            // 
            // trackComboBox
            // 
            this.trackComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackComboBox.FormattingEnabled = true;
            this.trackComboBox.Location = new System.Drawing.Point(96, 111);
            this.trackComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.trackComboBox.Name = "trackComboBox";
            this.trackComboBox.Size = new System.Drawing.Size(618, 33);
            this.trackComboBox.TabIndex = 3;
            // 
            // teamComboBox
            // 
            this.teamComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.teamComboBox.FormattingEnabled = true;
            this.teamComboBox.Location = new System.Drawing.Point(242, 259);
            this.teamComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.teamComboBox.Name = "teamComboBox";
            this.teamComboBox.Size = new System.Drawing.Size(472, 33);
            this.teamComboBox.TabIndex = 4;
            // 
            // cycleLengthNumeric
            // 
            this.cycleLengthNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cycleLengthNumeric.Location = new System.Drawing.Point(599, 358);
            this.cycleLengthNumeric.Margin = new System.Windows.Forms.Padding(1);
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
            this.cycleLengthNumeric.Size = new System.Drawing.Size(115, 32);
            this.cycleLengthNumeric.TabIndex = 7;
            this.cycleLengthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.trackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trackLabel.Location = new System.Drawing.Point(28, 114);
            this.trackLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(66, 26);
            this.trackLabel.TabIndex = 8;
            this.trackLabel.Text = "Trasa";
            // 
            // cycleLabel
            // 
            this.cycleLabel.AutoSize = true;
            this.cycleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cycleLabel.Location = new System.Drawing.Point(27, 326);
            this.cycleLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cycleLabel.Name = "cycleLabel";
            this.cycleLabel.Size = new System.Drawing.Size(180, 31);
            this.cycleLabel.TabIndex = 10;
            this.cycleLabel.Text = "Cykliczność:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(27, 71);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(79, 26);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Nazwa";
            // 
            // repeatedCheckBox
            // 
            this.repeatedCheckBox.AutoSize = true;
            this.repeatedCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.repeatedCheckBox.Location = new System.Drawing.Point(33, 358);
            this.repeatedCheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.repeatedCheckBox.Name = "repeatedCheckBox";
            this.repeatedCheckBox.Size = new System.Drawing.Size(151, 30);
            this.repeatedCheckBox.TabIndex = 13;
            this.repeatedCheckBox.Text = "Powtarzalna";
            this.repeatedCheckBox.UseVisualStyleBackColor = true;
            this.repeatedCheckBox.CheckedChanged += new System.EventHandler(this.repeatedCheckBox_CheckedChanged);
            // 
            // shiftCheckBox
            // 
            this.shiftCheckBox.AutoSize = true;
            this.shiftCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shiftCheckBox.Location = new System.Drawing.Point(33, 464);
            this.shiftCheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.shiftCheckBox.Name = "shiftCheckBox";
            this.shiftCheckBox.Size = new System.Drawing.Size(245, 30);
            this.shiftCheckBox.TabIndex = 16;
            this.shiftCheckBox.Text = "Przypisana do zmiany";
            this.shiftCheckBox.UseVisualStyleBackColor = true;
            this.shiftCheckBox.CheckedChanged += new System.EventHandler(this.shiftCheckBox_CheckedChanged);
            // 
            // shiftNumeric
            // 
            this.shiftNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shiftNumeric.Location = new System.Drawing.Point(641, 462);
            this.shiftNumeric.Margin = new System.Windows.Forms.Padding(1);
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
            this.shiftNumeric.Size = new System.Drawing.Size(73, 32);
            this.shiftNumeric.TabIndex = 14;
            this.shiftNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.shiftNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shift2Label
            // 
            this.shift2Label.AutoSize = true;
            this.shift2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shift2Label.Location = new System.Drawing.Point(554, 464);
            this.shift2Label.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.shift2Label.Name = "shift2Label";
            this.shift2Label.Size = new System.Drawing.Size(85, 26);
            this.shift2Label.TabIndex = 17;
            this.shift2Label.Text = "Zmiana";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameTextBox.Location = new System.Drawing.Point(109, 68);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(605, 32);
            this.nameTextBox.TabIndex = 18;
            // 
            // cycleLengthLabel
            // 
            this.cycleLengthLabel.AutoSize = true;
            this.cycleLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cycleLengthLabel.Location = new System.Drawing.Point(450, 360);
            this.cycleLengthLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.cycleLengthLabel.Name = "cycleLengthLabel";
            this.cycleLengthLabel.Size = new System.Drawing.Size(147, 26);
            this.cycleLengthLabel.TabIndex = 19;
            this.cycleLengthLabel.Text = "Długość cyklu";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelButton.Location = new System.Drawing.Point(746, 515);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(473, 52);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // team0CheckBox
            // 
            this.team0CheckBox.AutoSize = true;
            this.team0CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.team0CheckBox.Location = new System.Drawing.Point(31, 260);
            this.team0CheckBox.Margin = new System.Windows.Forms.Padding(1);
            this.team0CheckBox.Name = "team0CheckBox";
            this.team0CheckBox.Size = new System.Drawing.Size(175, 30);
            this.team0CheckBox.TabIndex = 21;
            this.team0CheckBox.Text = "Dla wszystkich";
            this.team0CheckBox.UseVisualStyleBackColor = true;
            this.team0CheckBox.CheckedChanged += new System.EventHandler(this.team0CheckBox_CheckedChanged);
            // 
            // _64buttonUserControl1
            // 
            this._64buttonUserControl1.Location = new System.Drawing.Point(746, 27);
            this._64buttonUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this._64buttonUserControl1.Name = "_64buttonUserControl1";
            this._64buttonUserControl1.Size = new System.Drawing.Size(473, 467);
            this._64buttonUserControl1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 432);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 22;
            this.label1.Text = "Zmianowość:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(26, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Grupa pracowników:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "Podstawowe informacje:";
            // 
            // RoutineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.team0CheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cycleLengthLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.shift2Label);
            this.Controls.Add(this.shiftCheckBox);
            this.Controls.Add(this.shiftNumeric);
            this.Controls.Add(this.repeatedCheckBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this._64buttonUserControl1);
            this.Controls.Add(this.cycleLabel);
            this.Controls.Add(this.trackLabel);
            this.Controls.Add(this.cycleLengthNumeric);
            this.Controls.Add(this.teamComboBox);
            this.Controls.Add(this.trackComboBox);
            this.Controls.Add(this.saveRoutineButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.beginDateTime);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "RoutineUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.Load += new System.EventHandler(this.RoutineUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cycleLengthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker beginDateTime;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.ComboBox trackComboBox;
		private System.Windows.Forms.ComboBox teamComboBox;
		private System.Windows.Forms.NumericUpDown cycleLengthNumeric;
		private System.Windows.Forms.Label trackLabel;
		private System.Windows.Forms.Label cycleLabel;
		private _64buttonUserControl _64buttonUserControl1;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.CheckBox repeatedCheckBox;
		private System.Windows.Forms.CheckBox shiftCheckBox;
		private System.Windows.Forms.NumericUpDown shiftNumeric;
		private System.Windows.Forms.Label shift2Label;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label cycleLengthLabel;
		public System.Windows.Forms.Button saveRoutineButton;
		public System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.CheckBox team0CheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
