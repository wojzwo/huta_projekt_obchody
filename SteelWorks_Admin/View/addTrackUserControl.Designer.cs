namespace SteelWorks_Admin.View
{
	partial class addTrackUserControl
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
			this.TrackNameTextBox = new System.Windows.Forms.TextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(186, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nazwa Trasy:";
			// 
			// TrackNameTextBox
			// 
			this.TrackNameTextBox.Location = new System.Drawing.Point(41, 98);
			this.TrackNameTextBox.Name = "TrackNameTextBox";
			this.TrackNameTextBox.Size = new System.Drawing.Size(920, 38);
			this.TrackNameTextBox.TabIndex = 1;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(41, 297);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(449, 86);
			this.addButton.TabIndex = 2;
			this.addButton.Text = "Dodaj Trase";
			this.addButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(512, 297);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(449, 86);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Anuluj";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// addTrackUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.TrackNameTextBox);
			this.Controls.Add(this.label1);
			this.Name = "addTrackUserControl";
			this.Size = new System.Drawing.Size(1072, 427);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TrackNameTextBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button cancelButton;
	}
}
