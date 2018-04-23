namespace SteelWorks_Admin.View
{
	partial class CheckPassUserControl
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
			this.Passlabel = new System.Windows.Forms.Label();
			this.PasstextBox = new System.Windows.Forms.TextBox();
			this.NoConnectionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Passlabel
			// 
			this.Passlabel.AutoSize = true;
			this.Passlabel.Location = new System.Drawing.Point(50, 68);
			this.Passlabel.Name = "Passlabel";
			this.Passlabel.Size = new System.Drawing.Size(173, 32);
			this.Passlabel.TabIndex = 0;
			this.Passlabel.Text = "Podaj hasło:";
			// 
			// PasstextBox
			// 
			this.PasstextBox.Location = new System.Drawing.Point(56, 150);
			this.PasstextBox.Name = "PasstextBox";
			this.PasstextBox.Size = new System.Drawing.Size(630, 38);
			this.PasstextBox.TabIndex = 1;
			// 
			// NoConnectionLabel
			// 
			this.NoConnectionLabel.AutoSize = true;
			this.NoConnectionLabel.Location = new System.Drawing.Point(302, 378);
			this.NoConnectionLabel.Name = "NoConnectionLabel";
			this.NoConnectionLabel.Size = new System.Drawing.Size(827, 32);
			this.NoConnectionLabel.TabIndex = 2;
			this.NoConnectionLabel.Text = "Brak połączenia z bazą danych, sprawdź połączenie internetowe";
			// 
			// CheckPassUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.NoConnectionLabel);
			this.Controls.Add(this.PasstextBox);
			this.Controls.Add(this.Passlabel);
			this.Name = "CheckPassUserControl";
			this.Size = new System.Drawing.Size(1559, 857);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Passlabel;
		private System.Windows.Forms.TextBox PasstextBox;
		private System.Windows.Forms.Label NoConnectionLabel;
	}
}
