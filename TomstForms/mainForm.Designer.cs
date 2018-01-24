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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.btReadDevice = new System.Windows.Forms.Button();
            this.btOpenAdapter = new System.Windows.Forms.Button();
            this.DebugView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btReadDevice
            // 
            this.btReadDevice.Enabled = false;
            this.btReadDevice.Location = new System.Drawing.Point(134, 12);
            this.btReadDevice.Name = "btReadDevice";
            this.btReadDevice.Size = new System.Drawing.Size(557, 23);
            this.btReadDevice.TabIndex = 0;
            this.btReadDevice.Text = "readDevice";
            this.btReadDevice.UseVisualStyleBackColor = true;
            this.btReadDevice.Click += new System.EventHandler(this.btReadDevice_Click);
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
            // DebugView
            // 
            this.DebugView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DebugView.GridLines = true;
            this.DebugView.Location = new System.Drawing.Point(13, 42);
            this.DebugView.Name = "DebugView";
            this.DebugView.Size = new System.Drawing.Size(678, 394);
            this.DebugView.TabIndex = 4;
            this.DebugView.UseCompatibleStateImageBehavior = false;
            this.DebugView.View = System.Windows.Forms.View.List;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 448);
            this.Controls.Add(this.DebugView);
            this.Controls.Add(this.btOpenAdapter);
            this.Controls.Add(this.btReadDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "Anonimowi Alkoholicy App";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btReadDevice;
        private System.Windows.Forms.Button btOpenAdapter;
        private System.Windows.Forms.ListView DebugView;
    }
}

