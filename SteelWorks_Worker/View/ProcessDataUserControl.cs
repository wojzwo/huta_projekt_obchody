﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class ProcessDataUserControl : UserControl
    {
        private DataItemUserControl currentExpanded_ = null;

        public void CollapsePrevious(DataItemUserControl newExpanded) {
            if (currentExpanded_ != newExpanded) {
                currentExpanded_?.Collapse();
            }

            currentExpanded_ = newExpanded;
        }

        public void AddEmployee(ChipData data) {
            if (data.bIsValid) {
                WorkerName.Text = "Pracownik: " + data.id;
                WorkerName.BackColor = Color.Green;
            } else {
                WorkerName.Text = "Pracownik: ???";
                WorkerName.BackColor = Color.Red;
            }
        }

        public void AddData(DataItemUserControl control) {
            control.SetParent(this);
            MainTable.RowCount++;
            MainTable.Controls.Add(control, 0, MainTable.RowCount - 1);
            MainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        public ProcessDataUserControl() {
            InitializeComponent();
        }

        private void ExpandError(DataItemUserControl toExpand) {
            toExpand.Expand();
        }

        private bool ValidatePanel() {
            foreach (DataItemUserControl c in MainTable.Controls) {
                if (!c.bIsValid) {
                    ExpandError(c);
                    return false;
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e) {
            bool isValid = ValidatePanel();
            if (!isValid) {
                ErrorBox.Visible = true;
                return;
            }

            DB_Chip c = new DB_Chip();
            c.chipId = "ART";
            c.bIsEmployee = true;
            Repository.instance.InsertChip(c);
        }
    }
}
