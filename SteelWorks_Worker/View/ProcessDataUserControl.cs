﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class ProcessDataUserControl : UserControl
    {
        public bool bCorrectionMode = false;

        private bool bIsEmployeeValid_;
        private DataItemUserControl currentExpanded_ = null;

        public void DeleteAllDataItems() {
            MainTable.Controls.Clear();
        }

        public void DeleteDataItem(DataItemUserControl c) {
            MainTable.Controls.Remove(c);
        }

        public ReportProcessData GetReportInfo() {
            List<ReportDataItem> items = new List<ReportDataItem>();
            foreach (DataItemUserControl c in MainTable.Controls) {
                items.Add(c.GetReportInfo());
            }

            return new ReportProcessData() {
                employeeName = WorkerName.Text.Substring(11),
                items = items
            };
        }

        public void OnSelectedEmployee(PopupView popupView, string name) {
            popupView.Close();
            WorkerName.Text = name;
            WorkerName.BackColor = Color.GreenYellow;
            bIsEmployeeValid_ = true;
        }

        public void CollapsePrevious(DataItemUserControl newExpanded) {
            if (currentExpanded_ != newExpanded) {
                currentExpanded_?.Collapse();
            }

            currentExpanded_ = newExpanded;
        }

        public void AddEmployee(string employeeName) {
            WorkerName.Text = "Pracownik: " + employeeName;
            WorkerName.BackColor = Color.Green;
            WorkerName.Enabled = false;
            bIsEmployeeValid_ = true;

            textBox1.Text = "Nieodwiedzone miejsca";
            SendButton.Text = "Wyślij raport...";
        }

        public void AddEmployee(ChipData data) {
            if (data.bIsValid) {
                DbEmployee employee = null;

                Repository.RepeatQueryWhileNoConnection<PopupNoInternetView>(this, 1000, () => {
                    employee = Repository.employee.Get(data.id);
                });

                if (employee != null) {
                    WorkerName.Text = "Pracownik: " + employee.name;
                    WorkerName.BackColor = Color.Green;
                    WorkerName.Enabled = false;
                    bIsEmployeeValid_ = true;
                    return;
                }

                Debug.Log("Employee from chip couldn't be loaded", LogType.Warning);
            }

            WorkerName.Text = "Pracownik: ???";
            WorkerName.BackColor = Color.Red;
            bIsEmployeeValid_ = false;
        }

        public void AddData(DbPlace place) {
            DataItemUserControl control = new DataItemUserControl();
            control.Init(place);

            control.SetParent(this);
            MainTable.RowCount++;
            MainTable.Controls.Add(control, 0, MainTable.RowCount - 1);
            MainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        public void AddData(ChipData chip, KeypadData mark) {
            DataItemUserControl control = new DataItemUserControl();
            control.Init(chip, mark);

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
            if (!bIsEmployeeValid_)
                return false;

            foreach (DataItemUserControl c in MainTable.Controls) {
                if (!c.bIsValid) {
                    ExpandError(c);
                    ErrorBox.Text = "Nie poprawiono wszystkich błędów w wyborze miejsc i ocen; Naciśnij na oznaczone czerwoną ramką pola i wybierz poprawne wartości";
                    return false;
                }
            }

            foreach (DataItemUserControl c in MainTable.Controls) {
                if ((c.bCommentRequired || c.bNotVisited) && c.GetComment().Length < 2) {
                    ExpandError(c);
                    ErrorBox.Text = "Nie wszystkie miejsca z negatywną oceną mają komentarz; Naciśnij na oznaczone żółtą ramką pola i dopisz komentarze";
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

            ErrorBox.Visible = false;
            WorkerDataView view = (WorkerDataView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerDataView", LogType.Error);
                return;
            }

            if (!bCorrectionMode)
                view.ChangeUserControlToTrackSelection();
            else 
                view.ChangeUserControlToSendReport();
        }

        private void WorkerName_Click(object sender, EventArgs e) {
            PopupView popup = new PopupView();
            popup.InitializeView(this);
            popup.Show();
        }

        private void ProcessDataUserControl_Load(object sender, EventArgs e) {

        }

        private void MainTable_Paint(object sender, PaintEventArgs e) {

        }
    }
}
