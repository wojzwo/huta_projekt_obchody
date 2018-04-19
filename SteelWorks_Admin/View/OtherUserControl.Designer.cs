namespace SteelWorks_Admin.View
{
	partial class OtherUserControl
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
            this.databaseBackupButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.archiveReportError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fullReportButton = new System.Windows.Forms.Button();
            this.generalReportButton = new System.Windows.Forms.Button();
            this.minimalReportButton = new System.Windows.Forms.Button();
            this.individualReportButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.errorBackupDatabase = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // databaseBackupButton
            // 
            this.databaseBackupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.databaseBackupButton.Location = new System.Drawing.Point(33, 276);
            this.databaseBackupButton.Margin = new System.Windows.Forms.Padding(1);
            this.databaseBackupButton.Name = "databaseBackupButton";
            this.databaseBackupButton.Size = new System.Drawing.Size(556, 44);
            this.databaseBackupButton.TabIndex = 0;
            this.databaseBackupButton.Text = "Zapisz obecny stan bazy";
            this.databaseBackupButton.UseVisualStyleBackColor = true;
            this.databaseBackupButton.Click += new System.EventHandler(this.databaseBackupButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generuj archiwalne raporty";
            // 
            // archiveReportError
            // 
            this.archiveReportError.AutoSize = true;
            this.archiveReportError.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.archiveReportError.ForeColor = System.Drawing.Color.Red;
            this.archiveReportError.Location = new System.Drawing.Point(27, 156);
            this.archiveReportError.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.archiveReportError.Name = "archiveReportError";
            this.archiveReportError.Size = new System.Drawing.Size(289, 31);
            this.archiveReportError.TabIndex = 7;
            this.archiveReportError.Text = "Zła forma adresu email";
            this.archiveReportError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(709, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "PANEL EDYCJI >> INNE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.Location = new System.Drawing.Point(33, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(556, 32);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.Value = new System.DateTime(2018, 4, 16, 0, 0, 0, 0);
            // 
            // fullReportButton
            // 
            this.fullReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fullReportButton.Location = new System.Drawing.Point(33, 101);
            this.fullReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.fullReportButton.Name = "fullReportButton";
            this.fullReportButton.Size = new System.Drawing.Size(128, 48);
            this.fullReportButton.TabIndex = 13;
            this.fullReportButton.Text = "Pełny";
            this.fullReportButton.UseVisualStyleBackColor = true;
            this.fullReportButton.Click += new System.EventHandler(this.fullReportButton_Click);
            // 
            // generalReportButton
            // 
            this.generalReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generalReportButton.Location = new System.Drawing.Point(175, 101);
            this.generalReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.generalReportButton.Name = "generalReportButton";
            this.generalReportButton.Size = new System.Drawing.Size(129, 48);
            this.generalReportButton.TabIndex = 14;
            this.generalReportButton.Text = "Ogólny";
            this.generalReportButton.UseVisualStyleBackColor = true;
            this.generalReportButton.Click += new System.EventHandler(this.generalReportButton_Click);
            // 
            // minimalReportButton
            // 
            this.minimalReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minimalReportButton.Location = new System.Drawing.Point(318, 101);
            this.minimalReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.minimalReportButton.Name = "minimalReportButton";
            this.minimalReportButton.Size = new System.Drawing.Size(129, 48);
            this.minimalReportButton.TabIndex = 15;
            this.minimalReportButton.Text = "Minimalny";
            this.minimalReportButton.UseVisualStyleBackColor = true;
            this.minimalReportButton.Click += new System.EventHandler(this.minimalReportButton_Click);
            // 
            // individualReportButton
            // 
            this.individualReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.individualReportButton.Location = new System.Drawing.Point(461, 101);
            this.individualReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.individualReportButton.Name = "individualReportButton";
            this.individualReportButton.Size = new System.Drawing.Size(128, 48);
            this.individualReportButton.TabIndex = 16;
            this.individualReportButton.Text = "Indywidualne";
            this.individualReportButton.UseVisualStyleBackColor = true;
            this.individualReportButton.Click += new System.EventHandler(this.individualReportButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(28, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kopia bazy danych";
            // 
            // errorBackupDatabase
            // 
            this.errorBackupDatabase.AutoSize = true;
            this.errorBackupDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorBackupDatabase.ForeColor = System.Drawing.Color.Red;
            this.errorBackupDatabase.Location = new System.Drawing.Point(27, 339);
            this.errorBackupDatabase.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.errorBackupDatabase.Name = "errorBackupDatabase";
            this.errorBackupDatabase.Size = new System.Drawing.Size(289, 31);
            this.errorBackupDatabase.TabIndex = 18;
            this.errorBackupDatabase.Text = "Zła forma adresu email";
            this.errorBackupDatabase.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(43, 321);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(537, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Zaleca się robić codziennie. Trzymać w niedostępnym dla pracowników miejscu!";
            // 
            // OtherUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.errorBackupDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.individualReportButton);
            this.Controls.Add(this.minimalReportButton);
            this.Controls.Add(this.generalReportButton);
            this.Controls.Add(this.fullReportButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.archiveReportError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databaseBackupButton);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "OtherUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.Load += new System.EventHandler(this.OtherUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button databaseBackupButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label archiveReportError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button fullReportButton;
        private System.Windows.Forms.Button generalReportButton;
        private System.Windows.Forms.Button minimalReportButton;
        private System.Windows.Forms.Button individualReportButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorBackupDatabase;
        private System.Windows.Forms.Label label4;
    }
}
