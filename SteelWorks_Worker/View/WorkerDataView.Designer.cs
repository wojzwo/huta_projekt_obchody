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
            // 
            // WorkerDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataUserControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerDataView";
            this.Text = "Obchody - Pracownik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerDataView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private ProcessDataUserControl dataUserControl;
    }
}