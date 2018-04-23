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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.logo_hw;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(14, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 52);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.acelor;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(1117, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(133, 52);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // WorkerDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dataUserControl);
            this.Controls.Add(this.sendReportUserControl_);
            this.Controls.Add(this.trackSelectionUserControl_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerDataView";
            this.Text = "Obchody - Pracownik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerDataView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProcessDataUserControl dataUserControl;
        private SendReportUserControl sendReportUserControl_;
        private TrackSelectionUserControl trackSelectionUserControl_;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}