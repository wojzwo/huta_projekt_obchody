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
            this.Place = new System.Windows.Forms.Button();
            this.Mark = new System.Windows.Forms.Button();
            this.Comment = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Place
            // 
            this.Place.FlatAppearance.BorderSize = 2;
            this.Place.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Place.Location = new System.Drawing.Point(152, 4);
            this.Place.Name = "Place";
            this.Place.Size = new System.Drawing.Size(298, 33);
            this.Place.TabIndex = 1;
            this.Place.Text = "Miejsce";
            this.Place.UseVisualStyleBackColor = true;
            // 
            // Mark
            // 
            this.Mark.FlatAppearance.BorderSize = 2;
            this.Mark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mark.Location = new System.Drawing.Point(456, 4);
            this.Mark.Name = "Mark";
            this.Mark.Size = new System.Drawing.Size(266, 33);
            this.Mark.TabIndex = 2;
            this.Mark.Text = "Ocena";
            this.Mark.UseVisualStyleBackColor = true;
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.Color.White;
            this.Comment.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Comment.FlatAppearance.BorderSize = 2;
            this.Comment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Comment.Location = new System.Drawing.Point(728, 4);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(465, 33);
            this.Comment.TabIndex = 3;
            this.Comment.Text = "Komentarz";
            this.Comment.UseVisualStyleBackColor = false;
            // 
            // Date
            // 
            this.Date.BackColor = System.Drawing.Color.LightGray;
            this.Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Date.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Date.Location = new System.Drawing.Point(4, 4);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(142, 33);
            this.Date.TabIndex = 4;
            this.Date.Text = "02/04/2018 13:58";
            this.Date.UseVisualStyleBackColor = false;
            // 
            // DataItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.Mark);
            this.Controls.Add(this.Place);
            this.Name = "DataItemUserControl";
            this.Size = new System.Drawing.Size(1196, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Place;
        private System.Windows.Forms.Button Mark;
        private System.Windows.Forms.Button Comment;
        private System.Windows.Forms.Button Date;
    }
}
