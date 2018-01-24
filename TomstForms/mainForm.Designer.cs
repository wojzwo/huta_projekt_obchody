namespace TomstForms
{
    partial class fMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btReadDevice = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btOpenAdapter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btReadDevice
            // 
            this.btReadDevice.Enabled = false;
            this.btReadDevice.Location = new System.Drawing.Point(134, 12);
            this.btReadDevice.Name = "btReadDevice";
            this.btReadDevice.Size = new System.Drawing.Size(247, 23);
            this.btReadDevice.TabIndex = 0;
            this.btReadDevice.Text = "readDevice";
            this.btReadDevice.UseVisualStyleBackColor = true;
            this.btReadDevice.Click += new System.EventHandler(this.btReadDevice_Click);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 41);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(369, 290);
            this.listBox.TabIndex = 2;
            // 
            // btOpenAdapter
            // 
            this.btOpenAdapter.Location = new System.Drawing.Point(12, 12);
            this.btOpenAdapter.Name = "btOpenAdapter";
            this.btOpenAdapter.Size = new System.Drawing.Size(116, 23);
            this.btOpenAdapter.TabIndex = 3;
            this.btOpenAdapter.Text = "Open adapter";
            this.btOpenAdapter.UseVisualStyleBackColor = true;
            this.btOpenAdapter.Click += new System.EventHandler(this.btOpenAdapter_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 346);
            this.Controls.Add(this.btOpenAdapter);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btReadDevice);
            this.Name = "fMain";
            this.Text = "TOMST (c) PES 3 development console";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btReadDevice;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btOpenAdapter;
    }
}

