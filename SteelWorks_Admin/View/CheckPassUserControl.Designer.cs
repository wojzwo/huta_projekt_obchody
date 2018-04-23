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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPassUserControl));
            this.Passlabel = new System.Windows.Forms.Label();
            this.PasstextBox = new System.Windows.Forms.TextBox();
            this.NoConnectionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BadPassLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Passlabel
            // 
            this.Passlabel.AutoSize = true;
            this.Passlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Passlabel.Location = new System.Drawing.Point(441, 184);
            this.Passlabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Passlabel.Name = "Passlabel";
            this.Passlabel.Size = new System.Drawing.Size(132, 26);
            this.Passlabel.TabIndex = 0;
            this.Passlabel.Text = "Podaj hasło:";
            // 
            // PasstextBox
            // 
            this.PasstextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasstextBox.Location = new System.Drawing.Point(446, 245);
            this.PasstextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.PasstextBox.Name = "PasstextBox";
            this.PasstextBox.PasswordChar = '*';
            this.PasstextBox.Size = new System.Drawing.Size(385, 32);
            this.PasstextBox.TabIndex = 1;
            this.PasstextBox.UseSystemPasswordChar = true;
            this.PasstextBox.TextChanged += new System.EventHandler(this.PasstextBox_TextChanged);
            // 
            // NoConnectionLabel
            // 
            this.NoConnectionLabel.AutoSize = true;
            this.NoConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NoConnectionLabel.ForeColor = System.Drawing.Color.Red;
            this.NoConnectionLabel.Location = new System.Drawing.Point(266, 423);
            this.NoConnectionLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NoConnectionLabel.Name = "NoConnectionLabel";
            this.NoConnectionLabel.Size = new System.Drawing.Size(740, 25);
            this.NoConnectionLabel.TabIndex = 2;
            this.NoConnectionLabel.Text = "Brak połączenia z bazą danych, sprawdź połączenie internetowe i zrestartuj progra" +
    "m\r\n";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(446, 322);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(385, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BadPassLabel
            // 
            this.BadPassLabel.AutoSize = true;
            this.BadPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BadPassLabel.ForeColor = System.Drawing.Color.Red;
            this.BadPassLabel.Location = new System.Drawing.Point(677, 184);
            this.BadPassLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.BadPassLabel.Name = "BadPassLabel";
            this.BadPassLabel.Size = new System.Drawing.Size(154, 26);
            this.BadPassLabel.TabIndex = 4;
            this.BadPassLabel.Text = "Błędne Hasło";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(140, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 80);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SteelWorks_Admin.Properties.Resources.acelor;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(20, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 79);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // CheckPassUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BadPassLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NoConnectionLabel);
            this.Controls.Add(this.PasstextBox);
            this.Controls.Add(this.Passlabel);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "CheckPassUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Passlabel;
		private System.Windows.Forms.TextBox PasstextBox;
		private System.Windows.Forms.Label NoConnectionLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label BadPassLabel;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
