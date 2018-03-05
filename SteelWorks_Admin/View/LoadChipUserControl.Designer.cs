namespace SteelWorks_Admin.View
{
	partial class LoadChipUserControl
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
			this.ReconnectAdapterButton = new System.Windows.Forms.Button();
			this.AdapterStateLabel = new System.Windows.Forms.Label();
			this.AdapterStateText = new System.Windows.Forms.Label();
			this.ReadReaderButton = new System.Windows.Forms.Button();
			this.EraseReaderButton = new System.Windows.Forms.Button();
			this.ChipListBox = new System.Windows.Forms.ListBox();
			this.editChipUserControl1 = new SteelWorks_Admin.View.EditChipUserControl();
			this.SuspendLayout();
			// 
			// ReconnectAdapterButton
			// 
			this.ReconnectAdapterButton.Location = new System.Drawing.Point(481, 33);
			this.ReconnectAdapterButton.Name = "ReconnectAdapterButton";
			this.ReconnectAdapterButton.Size = new System.Drawing.Size(228, 62);
			this.ReconnectAdapterButton.TabIndex = 8;
			this.ReconnectAdapterButton.Text = "Ponów próbę";
			this.ReconnectAdapterButton.UseVisualStyleBackColor = true;
			this.ReconnectAdapterButton.Click += new System.EventHandler(this.ReconnectAdapterButton_Click_1);
			// 
			// AdapterStateLabel
			// 
			this.AdapterStateLabel.AutoSize = true;
			this.AdapterStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.AdapterStateLabel.ForeColor = System.Drawing.Color.Red;
			this.AdapterStateLabel.Location = new System.Drawing.Point(230, 63);
			this.AdapterStateLabel.Name = "AdapterStateLabel";
			this.AdapterStateLabel.Size = new System.Drawing.Size(224, 32);
			this.AdapterStateLabel.TabIndex = 7;
			this.AdapterStateLabel.Text = "Nie podłączony";
			// 
			// AdapterStateText
			// 
			this.AdapterStateText.AutoSize = true;
			this.AdapterStateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.AdapterStateText.Location = new System.Drawing.Point(19, 63);
			this.AdapterStateText.Name = "AdapterStateText";
			this.AdapterStateText.Size = new System.Drawing.Size(205, 32);
			this.AdapterStateText.TabIndex = 6;
			this.AdapterStateText.Text = "Stan Adaptera:";
			// 
			// ReadReaderButton
			// 
			this.ReadReaderButton.Enabled = false;
			this.ReadReaderButton.Location = new System.Drawing.Point(25, 120);
			this.ReadReaderButton.Name = "ReadReaderButton";
			this.ReadReaderButton.Size = new System.Drawing.Size(400, 80);
			this.ReadReaderButton.TabIndex = 9;
			this.ReadReaderButton.Text = "Zczytaj Chipy";
			this.ReadReaderButton.UseVisualStyleBackColor = true;
			this.ReadReaderButton.Click += new System.EventHandler(this.ReadReaderButton_Click);
			// 
			// EraseReaderButton
			// 
			this.EraseReaderButton.Enabled = false;
			this.EraseReaderButton.Location = new System.Drawing.Point(431, 120);
			this.EraseReaderButton.Name = "EraseReaderButton";
			this.EraseReaderButton.Size = new System.Drawing.Size(400, 80);
			this.EraseReaderButton.TabIndex = 10;
			this.EraseReaderButton.Text = "Wyczyść Pamięć Czytnika";
			this.EraseReaderButton.UseVisualStyleBackColor = true;
			this.EraseReaderButton.Click += new System.EventHandler(this.EraseReaderButton_Click);
			// 
			// ChipListBox
			// 
			this.ChipListBox.FormattingEnabled = true;
			this.ChipListBox.ItemHeight = 31;
			this.ChipListBox.Location = new System.Drawing.Point(25, 206);
			this.ChipListBox.Name = "ChipListBox";
			this.ChipListBox.Size = new System.Drawing.Size(237, 748);
			this.ChipListBox.TabIndex = 11;
			this.ChipListBox.SelectedIndexChanged += new System.EventHandler(this.ChipListBox_SelectedIndexChanged);
			// 
			// editChipUserControl1
			// 
			this.editChipUserControl1.Location = new System.Drawing.Point(277, 206);
			this.editChipUserControl1.Name = "editChipUserControl1";
			this.editChipUserControl1.Size = new System.Drawing.Size(835, 344);
			this.editChipUserControl1.TabIndex = 12;
			this.editChipUserControl1.Load += new System.EventHandler(this.editChipUserControl1_Load);
			// 
			// LoadChipUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.editChipUserControl1);
			this.Controls.Add(this.ChipListBox);
			this.Controls.Add(this.EraseReaderButton);
			this.Controls.Add(this.ReadReaderButton);
			this.Controls.Add(this.ReconnectAdapterButton);
			this.Controls.Add(this.AdapterStateLabel);
			this.Controls.Add(this.AdapterStateText);
			this.Name = "LoadChipUserControl";
			this.Size = new System.Drawing.Size(1131, 1013);
			this.Load += new System.EventHandler(this.LoadChipUserControl_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ReconnectAdapterButton;
		private System.Windows.Forms.Label AdapterStateLabel;
		private System.Windows.Forms.Label AdapterStateText;
		private System.Windows.Forms.Button ReadReaderButton;
		private System.Windows.Forms.Button EraseReaderButton;
		private System.Windows.Forms.ListBox ChipListBox;
		private EditChipUserControl editChipUserControl1;
	}
}
