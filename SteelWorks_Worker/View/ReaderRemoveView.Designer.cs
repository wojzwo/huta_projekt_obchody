namespace SteelWorks_Worker.View
{
    partial class ReaderRemoveView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderRemoveView));
            this.dataRemoveSuccessUserControl_ = new SteelWorks_Worker.View.DataRemoveSuccessUserControl();
            this.dataRemoveUserControl_ = new SteelWorks_Worker.View.DataRemoveUserControl();
            this.SuspendLayout();
            // 
            // dataRemoveSuccessUserControl_
            // 
            this.dataRemoveSuccessUserControl_.BackColor = System.Drawing.SystemColors.Control;
            this.dataRemoveSuccessUserControl_.Location = new System.Drawing.Point(12, 12);
            this.dataRemoveSuccessUserControl_.Name = "dataRemoveSuccessUserControl_";
            this.dataRemoveSuccessUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.dataRemoveSuccessUserControl_.TabIndex = 0;
            this.dataRemoveSuccessUserControl_.Visible = false;
            this.dataRemoveSuccessUserControl_.Load += new System.EventHandler(this.dataRemoveSuccessUserControl__Load);
            // 
            // dataRemoveUserControl_
            // 
            this.dataRemoveUserControl_.BackColor = System.Drawing.SystemColors.Control;
            this.dataRemoveUserControl_.Location = new System.Drawing.Point(12, 12);
            this.dataRemoveUserControl_.Name = "dataRemoveUserControl_";
            this.dataRemoveUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.dataRemoveUserControl_.TabIndex = 1;
            // 
            // ReaderRemoveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataRemoveSuccessUserControl_);
            this.Controls.Add(this.dataRemoveUserControl_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReaderRemoveView";
            this.Text = "ReaderRemoveView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReaderRemoveView_FormClosed);
            this.Load += new System.EventHandler(this.ReaderRemoveView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataRemoveUserControl dataRemoveUserControl_;
        private DataRemoveSuccessUserControl dataRemoveSuccessUserControl_;
    }
}