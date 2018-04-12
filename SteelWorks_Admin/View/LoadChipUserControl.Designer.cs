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
            this.ReconnectAdapterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReconnectAdapterButton.Location = new System.Drawing.Point(42, 75);
            this.ReconnectAdapterButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ReconnectAdapterButton.Name = "ReconnectAdapterButton";
            this.ReconnectAdapterButton.Size = new System.Drawing.Size(503, 38);
            this.ReconnectAdapterButton.TabIndex = 8;
            this.ReconnectAdapterButton.Text = "Ponów próbę";
            this.ReconnectAdapterButton.UseVisualStyleBackColor = true;
            this.ReconnectAdapterButton.Click += new System.EventHandler(this.ReconnectAdapterButton_Click_1);
            // 
            // AdapterStateLabel
            // 
            this.AdapterStateLabel.AutoSize = true;
            this.AdapterStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdapterStateLabel.ForeColor = System.Drawing.Color.Red;
            this.AdapterStateLabel.Location = new System.Drawing.Point(207, 27);
            this.AdapterStateLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.AdapterStateLabel.Name = "AdapterStateLabel";
            this.AdapterStateLabel.Size = new System.Drawing.Size(175, 26);
            this.AdapterStateLabel.TabIndex = 7;
            this.AdapterStateLabel.Text = "Nie podłączony";
            // 
            // AdapterStateText
            // 
            this.AdapterStateText.AutoSize = true;
            this.AdapterStateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdapterStateText.Location = new System.Drawing.Point(37, 27);
            this.AdapterStateText.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.AdapterStateText.Name = "AdapterStateText";
            this.AdapterStateText.Size = new System.Drawing.Size(157, 26);
            this.AdapterStateText.TabIndex = 6;
            this.AdapterStateText.Text = "Stan Adaptera:";
            // 
            // ReadReaderButton
            // 
            this.ReadReaderButton.Enabled = false;
            this.ReadReaderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReadReaderButton.Location = new System.Drawing.Point(395, 138);
            this.ReadReaderButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ReadReaderButton.Name = "ReadReaderButton";
            this.ReadReaderButton.Size = new System.Drawing.Size(150, 115);
            this.ReadReaderButton.TabIndex = 9;
            this.ReadReaderButton.Text = "Zczytaj Chipy";
            this.ReadReaderButton.UseVisualStyleBackColor = true;
            this.ReadReaderButton.Click += new System.EventHandler(this.ReadReaderButton_Click);
            // 
            // EraseReaderButton
            // 
            this.EraseReaderButton.Enabled = false;
            this.EraseReaderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EraseReaderButton.Location = new System.Drawing.Point(395, 446);
            this.EraseReaderButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.EraseReaderButton.Name = "EraseReaderButton";
            this.EraseReaderButton.Size = new System.Drawing.Size(150, 116);
            this.EraseReaderButton.TabIndex = 10;
            this.EraseReaderButton.Text = "Wyczyść Pamięć Czytnika";
            this.EraseReaderButton.UseVisualStyleBackColor = true;
            this.EraseReaderButton.Click += new System.EventHandler(this.EraseReaderButton_Click);
            // 
            // ChipListBox
            // 
            this.ChipListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipListBox.FormattingEnabled = true;
            this.ChipListBox.ItemHeight = 20;
            this.ChipListBox.Location = new System.Drawing.Point(42, 138);
            this.ChipListBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ChipListBox.Name = "ChipListBox";
            this.ChipListBox.Size = new System.Drawing.Size(324, 424);
            this.ChipListBox.TabIndex = 11;
            this.ChipListBox.SelectedIndexChanged += new System.EventHandler(this.ChipListBox_SelectedIndexChanged);
            // 
            // editChipUserControl1
            // 
            this.editChipUserControl1.Location = new System.Drawing.Point(606, 18);
            this.editChipUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.editChipUserControl1.Name = "editChipUserControl1";
            this.editChipUserControl1.Size = new System.Drawing.Size(634, 559);
            this.editChipUserControl1.TabIndex = 12;
            this.editChipUserControl1.Load += new System.EventHandler(this.editChipUserControl1_Load);
            // 
            // LoadChipUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editChipUserControl1);
            this.Controls.Add(this.ChipListBox);
            this.Controls.Add(this.EraseReaderButton);
            this.Controls.Add(this.ReadReaderButton);
            this.Controls.Add(this.ReconnectAdapterButton);
            this.Controls.Add(this.AdapterStateLabel);
            this.Controls.Add(this.AdapterStateText);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "LoadChipUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
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
