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
            this.dataRemoveOrLoadSelectionUserControl = new SteelWorks_Worker.View.DataRemoveOrLoadSelectionUserControl();
            this.loadReaderUserControl = new SteelWorks_Worker.View.LoadReaderUserControl();
            this.startUserControl = new SteelWorks_Worker.View.StartUserControl();
            this.dataRemoveUserControl_ = new SteelWorks_Worker.View.DataRemoveUserControl();
            this.dataRemoveSuccessUserControl_ = new SteelWorks_Worker.View.DataRemoveSuccessUserControl();
            this.SuspendLayout();
            // 
            // dataRemoveOrLoadSelectionUserControl
            // 
            this.dataRemoveOrLoadSelectionUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataRemoveOrLoadSelectionUserControl.BackColor = System.Drawing.SystemColors.Control;
            this.dataRemoveOrLoadSelectionUserControl.Location = new System.Drawing.Point(12, 12);
            this.dataRemoveOrLoadSelectionUserControl.Name = "dataRemoveOrLoadSelectionUserControl";
            this.dataRemoveOrLoadSelectionUserControl.Size = new System.Drawing.Size(1240, 657);
            this.dataRemoveOrLoadSelectionUserControl.TabIndex = 1;
            this.dataRemoveOrLoadSelectionUserControl.Visible = false;
            this.dataRemoveOrLoadSelectionUserControl.Load += new System.EventHandler(this.dataRemoveOrLoadSelectionUserControl_Load);
            // 
            // loadReaderUserControl
            // 
            this.loadReaderUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadReaderUserControl.BackColor = System.Drawing.SystemColors.Control;
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
            this.startUserControl.BackColor = System.Drawing.SystemColors.Control;
            this.startUserControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.startUserControl.Location = new System.Drawing.Point(12, 12);
            this.startUserControl.Name = "startUserControl";
            this.startUserControl.Size = new System.Drawing.Size(1240, 657);
            this.startUserControl.TabIndex = 0;
            this.startUserControl.Load += new System.EventHandler(this.startUserControl1_Load_1);
            // 
            // dataRemoveUserControl_
            // 
            this.dataRemoveUserControl_.BackColor = System.Drawing.SystemColors.Control;
            this.dataRemoveUserControl_.Location = new System.Drawing.Point(12, 12);
            this.dataRemoveUserControl_.Name = "dataRemoveUserControl_";
            this.dataRemoveUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.dataRemoveUserControl_.TabIndex = 2;
            this.dataRemoveUserControl_.Visible = false;
            // 
            // dataRemoveSuccessUserControl_
            // 
            this.dataRemoveSuccessUserControl_.BackColor = System.Drawing.SystemColors.Control;
            this.dataRemoveSuccessUserControl_.Location = new System.Drawing.Point(12, 12);
            this.dataRemoveSuccessUserControl_.Name = "dataRemoveSuccessUserControl_";
            this.dataRemoveSuccessUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.dataRemoveSuccessUserControl_.TabIndex = 3;
            this.dataRemoveSuccessUserControl_.Visible = false;
            // 
            // WorkerMainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataRemoveOrLoadSelectionUserControl);
            this.Controls.Add(this.loadReaderUserControl);
            this.Controls.Add(this.startUserControl);
            this.Controls.Add(this.dataRemoveUserControl_);
            this.Controls.Add(this.dataRemoveSuccessUserControl_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerMainView";
            this.Text = "Obchody - Pracownik";
            this.Load += new System.EventHandler(this.BeforeLoad);
            this.ResumeLayout(false);

        }

        #endregion
        private StartUserControl startUserControl;
        private LoadReaderUserControl loadReaderUserControl;
        private DataRemoveOrLoadSelectionUserControl dataRemoveOrLoadSelectionUserControl;
        private DataRemoveUserControl dataRemoveUserControl_;
        private DataRemoveSuccessUserControl dataRemoveSuccessUserControl_;
    }
}

