namespace SteelWorks_Admin.View
{
	partial class ChipListUserControl
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
            this.chipStateComboBox = new System.Windows.Forms.ComboBox();
            this.chipTypeName = new System.Windows.Forms.Label();
            this.ReloadChipFromDBButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editChipUserControl1 = new SteelWorks_Admin.View.EditChipUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chipStateComboBox
            // 
            this.chipStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chipStateComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chipStateComboBox.FormattingEnabled = true;
            this.chipStateComboBox.ItemHeight = 18;
            this.chipStateComboBox.Items.AddRange(new object[] {
            "Miejsce",
            "Pracownik"});
            this.chipStateComboBox.Location = new System.Drawing.Point(75, 22);
            this.chipStateComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.chipStateComboBox.Name = "chipStateComboBox";
            this.chipStateComboBox.Size = new System.Drawing.Size(239, 26);
            this.chipStateComboBox.TabIndex = 5;
            this.chipStateComboBox.SelectedIndexChanged += new System.EventHandler(this.chipStateComboBox_SelectedIndexChanged);
            // 
            // chipTypeName
            // 
            this.chipTypeName.AutoSize = true;
            this.chipTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chipTypeName.Location = new System.Drawing.Point(18, 20);
            this.chipTypeName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.chipTypeName.Name = "chipTypeName";
            this.chipTypeName.Size = new System.Drawing.Size(46, 25);
            this.chipTypeName.TabIndex = 6;
            this.chipTypeName.Text = "Typ";
            // 
            // ReloadChipFromDBButton
            // 
            this.ReloadChipFromDBButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReloadChipFromDBButton.Location = new System.Drawing.Point(336, 20);
            this.ReloadChipFromDBButton.Margin = new System.Windows.Forms.Padding(1);
            this.ReloadChipFromDBButton.Name = "ReloadChipFromDBButton";
            this.ReloadChipFromDBButton.Size = new System.Drawing.Size(243, 28);
            this.ReloadChipFromDBButton.TabIndex = 7;
            this.ReloadChipFromDBButton.Text = "Wczytaj Dane z Bazy";
            this.ReloadChipFromDBButton.UseVisualStyleBackColor = true;
            this.ReloadChipFromDBButton.Click += new System.EventHandler(this.ReloadChipFromDBButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(23, 67);
            this.listView1.Margin = new System.Windows.Forms.Padding(1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(556, 510);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ChipID";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nazwa";
            this.columnHeader2.Width = 440;
            // 
            // editChipUserControl1
            // 
            this.editChipUserControl1.Location = new System.Drawing.Point(606, 18);
            this.editChipUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.editChipUserControl1.Name = "editChipUserControl1";
            this.editChipUserControl1.Size = new System.Drawing.Size(634, 559);
            this.editChipUserControl1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(709, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "PANEL EDYCJI >> CHIPY";
            // 
            // ChipListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editChipUserControl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ReloadChipFromDBButton);
            this.Controls.Add(this.chipTypeName);
            this.Controls.Add(this.chipStateComboBox);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ChipListUserControl";
            this.Size = new System.Drawing.Size(1263, 599);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox chipStateComboBox;
		private System.Windows.Forms.Label chipTypeName;
		private System.Windows.Forms.Button ReloadChipFromDBButton;
		private System.Windows.Forms.ListView listView1;
		private EditChipUserControl editChipUserControl1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
    }
}
