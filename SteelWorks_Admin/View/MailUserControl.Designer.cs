namespace SteelWorks_Admin.View
{
	partial class MailUserControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.maillListBox = new System.Windows.Forms.ListBox();
            this.mailtextBox = new System.Windows.Forms.TextBox();
            this.fullCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.wrongemailLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(582, 364);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dodaj/Zmień";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maillListBox
            // 
            this.maillListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maillListBox.FormattingEnabled = true;
            this.maillListBox.ItemHeight = 20;
            this.maillListBox.Location = new System.Drawing.Point(36, 24);
            this.maillListBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.maillListBox.Name = "maillListBox";
            this.maillListBox.Size = new System.Drawing.Size(487, 544);
            this.maillListBox.TabIndex = 1;
            this.maillListBox.SelectedIndexChanged += new System.EventHandler(this.maillListBox_SelectedIndexChanged);
            // 
            // mailtextBox
            // 
            this.mailtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mailtextBox.Location = new System.Drawing.Point(742, 157);
            this.mailtextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.mailtextBox.Name = "mailtextBox";
            this.mailtextBox.Size = new System.Drawing.Size(425, 32);
            this.mailtextBox.TabIndex = 2;
            // 
            // fullCheckBox
            // 
            this.fullCheckBox.AutoSize = true;
            this.fullCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fullCheckBox.Location = new System.Drawing.Point(667, 242);
            this.fullCheckBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.fullCheckBox.Name = "fullCheckBox";
            this.fullCheckBox.Size = new System.Drawing.Size(459, 30);
            this.fullCheckBox.TabIndex = 3;
            this.fullCheckBox.Text = "Otrzymuj raport z dodatkowymi szczegółami";
            this.fullCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(577, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adres e-mail";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(1010, 364);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wrongemailLabel
            // 
            this.wrongemailLabel.AutoSize = true;
            this.wrongemailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wrongemailLabel.ForeColor = System.Drawing.Color.Red;
            this.wrongemailLabel.Location = new System.Drawing.Point(736, 455);
            this.wrongemailLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.wrongemailLabel.Name = "wrongemailLabel";
            this.wrongemailLabel.Size = new System.Drawing.Size(289, 31);
            this.wrongemailLabel.TabIndex = 7;
            this.wrongemailLabel.Text = "Zła forma adresu email";
            this.wrongemailLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(709, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "PANEL EDYCJI >> E-MAIL";
            // 
            // MailUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wrongemailLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullCheckBox);
            this.Controls.Add(this.mailtextBox);
            this.Controls.Add(this.maillListBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "MailUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox maillListBox;
		private System.Windows.Forms.TextBox mailtextBox;
		private System.Windows.Forms.CheckBox fullCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label wrongemailLabel;
        private System.Windows.Forms.Label label2;
    }
}
