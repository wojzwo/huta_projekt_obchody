namespace SteelWorks_Admin.View
{
	partial class RoutineListUserControl
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
			this.routineListBox = new System.Windows.Forms.ListBox();
			this.addRoutineButton = new System.Windows.Forms.Button();
			this.editRoutineButton = new System.Windows.Forms.Button();
			this.deleteRoutineButton = new System.Windows.Forms.Button();
			this.routineLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// routineListBox
			// 
			this.routineListBox.FormattingEnabled = true;
			this.routineListBox.ItemHeight = 31;
			this.routineListBox.Location = new System.Drawing.Point(37, 105);
			this.routineListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.routineListBox.Name = "routineListBox";
			this.routineListBox.Size = new System.Drawing.Size(897, 841);
			this.routineListBox.TabIndex = 0;
			// 
			// addRoutineButton
			// 
			this.addRoutineButton.Location = new System.Drawing.Point(979, 105);
			this.addRoutineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.addRoutineButton.Name = "addRoutineButton";
			this.addRoutineButton.Size = new System.Drawing.Size(371, 112);
			this.addRoutineButton.TabIndex = 1;
			this.addRoutineButton.Text = "Nowa";
			this.addRoutineButton.UseVisualStyleBackColor = true;
			this.addRoutineButton.Click += new System.EventHandler(this.addRoutineButton_Click);
			// 
			// editRoutineButton
			// 
			this.editRoutineButton.Location = new System.Drawing.Point(979, 241);
			this.editRoutineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.editRoutineButton.Name = "editRoutineButton";
			this.editRoutineButton.Size = new System.Drawing.Size(371, 112);
			this.editRoutineButton.TabIndex = 2;
			this.editRoutineButton.Text = "Edytuj";
			this.editRoutineButton.UseVisualStyleBackColor = true;
			this.editRoutineButton.Click += new System.EventHandler(this.editRoutineButton_Click);
			// 
			// deleteRoutineButton
			// 
			this.deleteRoutineButton.Location = new System.Drawing.Point(979, 377);
			this.deleteRoutineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.deleteRoutineButton.Name = "deleteRoutineButton";
			this.deleteRoutineButton.Size = new System.Drawing.Size(371, 112);
			this.deleteRoutineButton.TabIndex = 3;
			this.deleteRoutineButton.Text = "Usuń";
			this.deleteRoutineButton.UseVisualStyleBackColor = true;
			this.deleteRoutineButton.Click += new System.EventHandler(this.deleteRoutineButton_Click);
			// 
			// routineLabel
			// 
			this.routineLabel.AutoSize = true;
			this.routineLabel.Location = new System.Drawing.Point(37, 33);
			this.routineLabel.Name = "routineLabel";
			this.routineLabel.Size = new System.Drawing.Size(103, 32);
			this.routineLabel.TabIndex = 4;
			this.routineLabel.Text = "Rutyny";
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(3, 19);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1797, 944);
			this.panel1.TabIndex = 5;
			this.panel1.Visible = false;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// RoutineListUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.routineLabel);
			this.Controls.Add(this.deleteRoutineButton);
			this.Controls.Add(this.editRoutineButton);
			this.Controls.Add(this.addRoutineButton);
			this.Controls.Add(this.routineListBox);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "RoutineListUserControl";
			this.Size = new System.Drawing.Size(1800, 1099);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox routineListBox;
		private System.Windows.Forms.Button addRoutineButton;
		private System.Windows.Forms.Button editRoutineButton;
		private System.Windows.Forms.Button deleteRoutineButton;
		private System.Windows.Forms.Label routineLabel;
		private System.Windows.Forms.Panel panel1;
	}
}
