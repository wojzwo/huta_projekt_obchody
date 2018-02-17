namespace works
{
    partial class Splash
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
            this.labMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labMsg
            // 
            this.labMsg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labMsg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labMsg.Location = new System.Drawing.Point(12, 9);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(314, 61);
            this.labMsg.TabIndex = 0;
            this.labMsg.Text = "Messages from outside world";
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labMsg.Click += new System.EventHandler(this.labMsg_Click);
            // 
            // Splash
            // 
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(338, 79);
            this.Controls.Add(this.labMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter (Esc) to close dialog";
            this.Shown += new System.EventHandler(this.Splash_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Splash_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion


       // private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labMsg;
    }
}