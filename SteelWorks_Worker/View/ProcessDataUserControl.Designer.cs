﻿using MakarovDev.ExpandCollapsePanel;

namespace SteelWorks_Worker.View
{
    partial class ProcessDataUserControl
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
            this.WorkerName = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.ErrorBox = new System.Windows.Forms.TextBox();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // WorkerName
            // 
            this.WorkerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkerName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.WorkerName.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.Button;
            this.WorkerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WorkerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WorkerName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorkerName.Location = new System.Drawing.Point(15, 13);
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.Size = new System.Drawing.Size(1202, 31);
            this.WorkerName.TabIndex = 4;
            this.WorkerName.Text = "Pracownik: ";
            this.WorkerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WorkerName.UseVisualStyleBackColor = false;
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SendButton.BackgroundImage = global::SteelWorks_Worker.Properties.Resources.Button;
            this.SendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SendButton.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SendButton.Location = new System.Drawing.Point(15, 604);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(1202, 40);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Wyślij raport";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorBox
            // 
            this.ErrorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ErrorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ErrorBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ErrorBox.ForeColor = System.Drawing.Color.Red;
            this.ErrorBox.Location = new System.Drawing.Point(15, 574);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.ReadOnly = true;
            this.ErrorBox.Size = new System.Drawing.Size(1202, 24);
            this.ErrorBox.TabIndex = 9;
            this.ErrorBox.Text = "Wykonana trasa odbiega od zakładanej; Naciśnij na oznaczone czerwoną ramką pola i" +
    " wybierz poprawne wartości";
            this.ErrorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ErrorBox.Visible = false;
            // 
            // MainTable
            // 
            this.MainTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTable.AutoScroll = true;
            this.MainTable.ColumnCount = 1;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTable.Location = new System.Drawing.Point(15, 50);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 1;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTable.Size = new System.Drawing.Size(1202, 518);
            this.MainTable.TabIndex = 10;
            // 
            // ProcessDataUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.WorkerName);
            this.Name = "ProcessDataUserControl";
            this.Size = new System.Drawing.Size(1240, 657);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button WorkerName;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox ErrorBox;
        private System.Windows.Forms.TableLayoutPanel MainTable;
    }
}
