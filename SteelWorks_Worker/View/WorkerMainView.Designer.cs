namespace SteelWorks_Worker.View
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
            this.loadReaderUserControl = new SteelWorks_Worker.View.LoadReaderUserControl();
            this.startUserControl = new SteelWorks_Worker.View.StartUserControl();
            this.SuspendLayout();
            // 
            // loadReaderUserControl
            // 
            this.loadReaderUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadReaderUserControl.BackColor = System.Drawing.Color.White;
            this.loadReaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.loadReaderUserControl.Location = new System.Drawing.Point(12, 12);
            this.loadReaderUserControl.Name = "loadReaderUserControl";
            this.loadReaderUserControl.Size = new System.Drawing.Size(1240, 657);
            this.loadReaderUserControl.TabIndex = 0;
            this.loadReaderUserControl.Visible = false;
            this.loadReaderUserControl.Load += new System.EventHandler(this.loadReaderUserControl_Load);
            // 
            // startUserControl
            // 
            this.startUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startUserControl.BackColor = System.Drawing.Color.White;
            this.startUserControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.startUserControl.Location = new System.Drawing.Point(12, 12);
            this.startUserControl.Name = "startUserControl";
            this.startUserControl.Size = new System.Drawing.Size(1240, 657);
            this.startUserControl.TabIndex = 0;
            this.startUserControl.Load += new System.EventHandler(this.startUserControl1_Load_1);
            // 
            // WorkerMainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.loadReaderUserControl);
            this.Controls.Add(this.startUserControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerMainView";
            this.Text = "Obchody - Pracownik";
            this.Load += new System.EventHandler(this.BeforeLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private StartUserControl startUserControl;
        private LoadReaderUserControl loadReaderUserControl;
    }
}

