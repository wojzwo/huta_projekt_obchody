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
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.wrongemailLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(945, 217);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(240, 79);
			this.button1.TabIndex = 0;
			this.button1.Text = "Dodaj/Zmień";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// maillListBox
			// 
			this.maillListBox.FormattingEnabled = true;
			this.maillListBox.ItemHeight = 31;
			this.maillListBox.Location = new System.Drawing.Point(21, 58);
			this.maillListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.maillListBox.Name = "maillListBox";
			this.maillListBox.Size = new System.Drawing.Size(897, 841);
			this.maillListBox.TabIndex = 1;
			this.maillListBox.SelectedIndexChanged += new System.EventHandler(this.maillListBox_SelectedIndexChanged);
			// 
			// mailtextBox
			// 
			this.mailtextBox.Location = new System.Drawing.Point(1138, 58);
			this.mailtextBox.Name = "mailtextBox";
			this.mailtextBox.Size = new System.Drawing.Size(506, 38);
			this.mailtextBox.TabIndex = 2;
			// 
			// fullCheckBox
			// 
			this.fullCheckBox.AutoSize = true;
			this.fullCheckBox.Location = new System.Drawing.Point(1138, 111);
			this.fullCheckBox.Name = "fullCheckBox";
			this.fullCheckBox.Size = new System.Drawing.Size(192, 36);
			this.fullCheckBox.TabIndex = 3;
			this.fullCheckBox.Text = "checkBox1";
			this.fullCheckBox.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(939, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 32);
			this.label1.TabIndex = 4;
			this.label1.Text = "Adres e-mail";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(939, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 32);
			this.label2.TabIndex = 5;
			this.label2.Text = "Pelny raport";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1263, 217);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(240, 79);
			this.button2.TabIndex = 6;
			this.button2.Text = "Usuń";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// wrongemailLabel
			// 
			this.wrongemailLabel.AutoSize = true;
			this.wrongemailLabel.ForeColor = System.Drawing.Color.Red;
			this.wrongemailLabel.Location = new System.Drawing.Point(968, 344);
			this.wrongemailLabel.Name = "wrongemailLabel";
			this.wrongemailLabel.Size = new System.Drawing.Size(304, 32);
			this.wrongemailLabel.TabIndex = 7;
			this.wrongemailLabel.Text = "Zła forma adresu email";
			this.wrongemailLabel.Visible = false;
			// 
			// MailUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.wrongemailLabel);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fullCheckBox);
			this.Controls.Add(this.mailtextBox);
			this.Controls.Add(this.maillListBox);
			this.Controls.Add(this.button1);
			this.Name = "MailUserControl";
			this.Size = new System.Drawing.Size(1822, 1093);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox maillListBox;
		private System.Windows.Forms.TextBox mailtextBox;
		private System.Windows.Forms.CheckBox fullCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label wrongemailLabel;
	}
}
