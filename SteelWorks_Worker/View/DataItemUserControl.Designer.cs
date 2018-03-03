using MakarovDev.ExpandCollapsePanel;

namespace SteelWorks_Worker.View
{
    partial class DataItemUserControl
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
            this.Panel = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Mark = new System.Windows.Forms.Button();
            this.Place = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Panel.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.Panel.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Triangle;
            this.Panel.Controls.Add(this.textBox1);
            this.Panel.Controls.Add(this.Date);
            this.Panel.Controls.Add(this.label4);
            this.Panel.Controls.Add(this.label3);
            this.Panel.Controls.Add(this.label2);
            this.Panel.Controls.Add(this.label1);
            this.Panel.Controls.Add(this.Mark);
            this.Panel.Controls.Add(this.Place);
            this.Panel.ExpandedHeight = 103;
            //            this.Panel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Panel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Panel.IsExpanded = true;
            this.Panel.Location = new System.Drawing.Point(4, 3);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1189, 200);
            this.Panel.TabIndex = 0;
            this.Panel.Text = "Miejsce [Ocena]";
            this.Panel.UseAnimation = false;
            this.Panel.ExpandCollapse += new System.EventHandler<MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs>(this.Panel_ExpandCollapse);
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(608, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(568, 138);
            this.textBox1.TabIndex = 10;
            // 
            // Date
            // 
            this.Date.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Date.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.Button;
            this.Date.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Date.Enabled = false;
            this.Date.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Date.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.Date.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Date.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.ForeColor = System.Drawing.Color.Black;
            this.Date.Location = new System.Drawing.Point(131, 44);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(338, 33);
            this.Date.TabIndex = 9;
            this.Date.Text = "Data";
            this.Date.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(508, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Komentarz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ocena";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Miejsce";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data i godzina";
            // 
            // Mark
            // 
            this.Mark.BackColor = System.Drawing.Color.White;
            this.Mark.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.Button;
            this.Mark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Mark.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.Mark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Mark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mark.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mark.ForeColor = System.Drawing.Color.Black;
            this.Mark.Location = new System.Drawing.Point(131, 149);
            this.Mark.Name = "Mark";
            this.Mark.Size = new System.Drawing.Size(338, 33);
            this.Mark.TabIndex = 4;
            this.Mark.Text = "Ocena";
            this.Mark.UseVisualStyleBackColor = false;
            // 
            // Place
            // 
            this.Place.BackColor = System.Drawing.Color.White;
            this.Place.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.Button;
            this.Place.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Place.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Place.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.Place.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Place.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Place.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Place.ForeColor = System.Drawing.Color.Black;
            this.Place.Location = new System.Drawing.Point(131, 96);
            this.Place.Name = "Place";
            this.Place.Size = new System.Drawing.Size(338, 33);
            this.Place.TabIndex = 1;
            this.Place.Text = "Miejsce";
            this.Place.UseVisualStyleBackColor = false;
            // 
            // DataItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.Panel);
            this.Name = "DataItemUserControl";
            this.Size = new System.Drawing.Size(1196, 200);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Place;
        private ExpandCollapsePanel Panel;
        private System.Windows.Forms.Button Mark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
