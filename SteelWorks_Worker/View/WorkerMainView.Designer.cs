﻿namespace SteelWorks_Worker.View
{
    partial class WorkerMainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerMainView));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.startUserControl1 = new SteelWorks_Worker.View.StartUserControl();
            this.SuspendLayout();
            // 
            // startUserControl1
            // 
            this.startUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startUserControl1.Location = new System.Drawing.Point(12, 12);
            this.startUserControl1.Name = "startUserControl1";
            this.startUserControl1.Size = new System.Drawing.Size(1240, 657);
            this.startUserControl1.TabIndex = 0;
            // 
            // WorkerMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.startUserControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerMainView";
            this.Text = "Obchody - Pracownik";
            this.Load += new System.EventHandler(this.BeforeLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private StartUserControl startUserControl1;
    }
}

