namespace SteelWorks_Worker.View
{
    partial class DataRemoveOrLoadSelectionUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.individualReportButton = new System.Windows.Forms.Button();
            this.minimalReportButton = new System.Windows.Forms.Button();
            this.generalReportButton = new System.Windows.Forms.Button();
            this.fullReportButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(145, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(950, 40);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Witamy w programie do obsługi obchodów!";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(234, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wyczyść czytnik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(772, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 46);
            this.label2.TabIndex = 7;
            this.label2.Text = "Wyślij raport";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.koperta1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(659, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(436, 319);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.reader_image;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(145, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(436, 319);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(395, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(465, 46);
            this.label3.TabIndex = 8;
            this.label3.Text = "Podgląd dzisiejszego raportu";
            // 
            // individualReportButton
            // 
            this.individualReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.individualReportButton.Location = new System.Drawing.Point(771, 525);
            this.individualReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.individualReportButton.Name = "individualReportButton";
            this.individualReportButton.Size = new System.Drawing.Size(128, 48);
            this.individualReportButton.TabIndex = 20;
            this.individualReportButton.Text = "Indywidualne";
            this.individualReportButton.UseVisualStyleBackColor = true;
            this.individualReportButton.Click += new System.EventHandler(this.individualReportButton_Click);
            // 
            // minimalReportButton
            // 
            this.minimalReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minimalReportButton.Location = new System.Drawing.Point(628, 525);
            this.minimalReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.minimalReportButton.Name = "minimalReportButton";
            this.minimalReportButton.Size = new System.Drawing.Size(129, 48);
            this.minimalReportButton.TabIndex = 19;
            this.minimalReportButton.Text = "Minimalny";
            this.minimalReportButton.UseVisualStyleBackColor = true;
            this.minimalReportButton.Click += new System.EventHandler(this.minimalReportButton_Click);
            // 
            // generalReportButton
            // 
            this.generalReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generalReportButton.Location = new System.Drawing.Point(485, 525);
            this.generalReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.generalReportButton.Name = "generalReportButton";
            this.generalReportButton.Size = new System.Drawing.Size(129, 48);
            this.generalReportButton.TabIndex = 18;
            this.generalReportButton.Text = "Ogólny";
            this.generalReportButton.UseVisualStyleBackColor = true;
            this.generalReportButton.Click += new System.EventHandler(this.generalReportButton_Click);
            // 
            // fullReportButton
            // 
            this.fullReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fullReportButton.Location = new System.Drawing.Point(343, 525);
            this.fullReportButton.Margin = new System.Windows.Forms.Padding(1);
            this.fullReportButton.Name = "fullReportButton";
            this.fullReportButton.Size = new System.Drawing.Size(128, 48);
            this.fullReportButton.TabIndex = 17;
            this.fullReportButton.Text = "Pełny";
            this.fullReportButton.UseVisualStyleBackColor = true;
            this.fullReportButton.Click += new System.EventHandler(this.fullReportButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(339, 588);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "Error message";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // DataRemoveOrLoadSelectionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.individualReportButton);
            this.Controls.Add(this.minimalReportButton);
            this.Controls.Add(this.generalReportButton);
            this.Controls.Add(this.fullReportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "DataRemoveOrLoadSelectionUserControl";
            this.Size = new System.Drawing.Size(1240, 657);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button individualReportButton;
        private System.Windows.Forms.Button minimalReportButton;
        private System.Windows.Forms.Button generalReportButton;
        private System.Windows.Forms.Button fullReportButton;
        private System.Windows.Forms.Label label4;
    }
}
