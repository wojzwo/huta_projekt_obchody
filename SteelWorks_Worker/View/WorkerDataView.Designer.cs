namespace SteelWorks_Worker.View
{
    partial class WorkerDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerDataView));
            this.dataUserControl = new SteelWorks_Worker.View.ProcessDataUserControl();
            this.sendReportUserControl_ = new SteelWorks_Worker.View.SendReportUserControl();
            this.trackSelectionUserControl_ = new SteelWorks_Worker.View.TrackSelectionUserControl();
            this.SuspendLayout();
            // 
            // dataUserControl
            // 
            this.dataUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataUserControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataUserControl.Location = new System.Drawing.Point(12, 12);
            this.dataUserControl.Name = "dataUserControl";
            this.dataUserControl.Size = new System.Drawing.Size(1240, 657);
            this.dataUserControl.TabIndex = 0;
            this.dataUserControl.Load += new System.EventHandler(this.dataUserControl_Load);
            // 
            // sendReportUserControl_
            // 
            this.sendReportUserControl_.BackColor = System.Drawing.SystemColors.Control;
            this.sendReportUserControl_.Location = new System.Drawing.Point(12, 12);
            this.sendReportUserControl_.Name = "sendReportUserControl_";
            this.sendReportUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.sendReportUserControl_.TabIndex = 1;
            this.sendReportUserControl_.Visible = false;
            // 
            // trackSelectionUserControl_
            // 
            this.trackSelectionUserControl_.Location = new System.Drawing.Point(12, 12);
            this.trackSelectionUserControl_.Name = "trackSelectionUserControl_";
            this.trackSelectionUserControl_.Size = new System.Drawing.Size(1240, 657);
            this.trackSelectionUserControl_.TabIndex = 2;
            this.trackSelectionUserControl_.Visible = false;
            // 
            // WorkerDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataUserControl);
            this.Controls.Add(this.sendReportUserControl_);
            this.Controls.Add(this.trackSelectionUserControl_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerDataView";
            this.Text = "Obchody - Pracownik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerDataView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private ProcessDataUserControl dataUserControl;
        private SendReportUserControl sendReportUserControl_;
        private TrackSelectionUserControl trackSelectionUserControl_;
    }
}