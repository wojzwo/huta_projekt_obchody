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
            this.label2 = new System.Windows.Forms.Label();
            this.generateAgainButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // routineListBox
            // 
            this.routineListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routineListBox.FormattingEnabled = true;
            this.routineListBox.ItemHeight = 20;
            this.routineListBox.Location = new System.Drawing.Point(40, 69);
            this.routineListBox.Margin = new System.Windows.Forms.Padding(1);
            this.routineListBox.Name = "routineListBox";
            this.routineListBox.Size = new System.Drawing.Size(591, 484);
            this.routineListBox.TabIndex = 0;
            this.routineListBox.SelectedIndexChanged += new System.EventHandler(this.routineListBox_SelectedIndexChanged);
            // 
            // addRoutineButton
            // 
            this.addRoutineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addRoutineButton.Location = new System.Drawing.Point(674, 105);
            this.addRoutineButton.Margin = new System.Windows.Forms.Padding(1);
            this.addRoutineButton.Name = "addRoutineButton";
            this.addRoutineButton.Size = new System.Drawing.Size(542, 72);
            this.addRoutineButton.TabIndex = 0;
            this.addRoutineButton.Text = "Nowa";
            this.addRoutineButton.UseVisualStyleBackColor = true;
            this.addRoutineButton.Click += new System.EventHandler(this.addRoutineButton_Click);
            // 
            // editRoutineButton
            // 
            this.editRoutineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editRoutineButton.Location = new System.Drawing.Point(674, 217);
            this.editRoutineButton.Margin = new System.Windows.Forms.Padding(1);
            this.editRoutineButton.Name = "editRoutineButton";
            this.editRoutineButton.Size = new System.Drawing.Size(542, 72);
            this.editRoutineButton.TabIndex = 0;
            this.editRoutineButton.Text = "Edytuj";
            this.editRoutineButton.UseVisualStyleBackColor = true;
            this.editRoutineButton.Click += new System.EventHandler(this.editRoutineButton_Click);
            // 
            // deleteRoutineButton
            // 
            this.deleteRoutineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteRoutineButton.Location = new System.Drawing.Point(674, 330);
            this.deleteRoutineButton.Margin = new System.Windows.Forms.Padding(1);
            this.deleteRoutineButton.Name = "deleteRoutineButton";
            this.deleteRoutineButton.Size = new System.Drawing.Size(542, 72);
            this.deleteRoutineButton.TabIndex = 0;
            this.deleteRoutineButton.Text = "Usuń";
            this.deleteRoutineButton.UseVisualStyleBackColor = true;
            this.deleteRoutineButton.Click += new System.EventHandler(this.deleteRoutineButton_Click);
            // 
            // routineLabel
            // 
            this.routineLabel.AutoSize = true;
            this.routineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.routineLabel.Location = new System.Drawing.Point(34, 27);
            this.routineLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.routineLabel.Name = "routineLabel";
            this.routineLabel.Size = new System.Drawing.Size(221, 31);
            this.routineLabel.TabIndex = 4;
            this.routineLabel.Text = "Aktualne Rutyny:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 599);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(709, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "PANEL EDYCJI >> RUTYNY";
            // 
            // generateAgainButton
            // 
            this.generateAgainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generateAgainButton.Location = new System.Drawing.Point(674, 443);
            this.generateAgainButton.Margin = new System.Windows.Forms.Padding(1);
            this.generateAgainButton.Name = "generateAgainButton";
            this.generateAgainButton.Size = new System.Drawing.Size(542, 72);
            this.generateAgainButton.TabIndex = 0;
            this.generateAgainButton.Text = "Wygeneruj ponownie";
            this.generateAgainButton.UseVisualStyleBackColor = true;
            this.generateAgainButton.Click += new System.EventHandler(this.generateAgainButton_Click);
            // 
            // RoutineListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.routineListBox);
            this.Controls.Add(this.routineLabel);
		    this.Controls.Add(this.deleteRoutineButton);
		    this.Controls.Add(this.addRoutineButton);
		    this.Controls.Add(this.generateAgainButton);
		    this.Controls.Add(this.editRoutineButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "RoutineListUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateAgainButton;
    }
}
