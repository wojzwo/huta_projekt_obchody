using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils.Model;

namespace SteelWorks_Worker.View
{
    public partial class PopupView : Form
    {
        private ProcessDataUserControl view_;
        private DataItemUserControl control_ = null;
        private PopupSelectionType type_;

        public void OnSelectedPlace(int id, string name) {
            control_.OnSelectedPlace(this, id, name);
        }

        public void OnSelectedMark(int id, string name, bool requireComment) {
            control_.OnSelectedMark(this, id, name, requireComment);
        }

        public void OnSelectedEmployee(int id, string name) {
            view_.OnSelectedEmployee(this, id, name);
        }

        public void InitializeView(ProcessDataUserControl view) {
            view_ = view;
            type_ = PopupSelectionType.Employee;
            Fill();
        }

        public void InitializeControl(DataItemUserControl control, PopupSelectionType type) {
            control_ = control;
            type_ = type;
            Fill();
        }

        public PopupView() {
            InitializeComponent();
        }

        private void Fill() {
            if (type_ == PopupSelectionType.Place) {
                List<DB_Place> places = Repository.instance.GetAllPlaces();
                foreach (DB_Place place in places) {
                    SelectableButtonUserControl s = new SelectableButtonUserControl();
                    s.InitButton(this, type_, place.id, place.name);
                    tableLayoutPanel1.Controls.Add(s);
                }
            } else if (type_ == PopupSelectionType.Mark) {
                List<DB_Mark> marks = Repository.instance.GetAllMarks();
                foreach (DB_Mark mark in marks) {
                    SelectableButtonUserControl s = new SelectableButtonUserControl();
                    s.InitButton(this, type_, mark.id, mark.name, mark.bCommentRequired);
                    tableLayoutPanel1.Controls.Add(s);
                }
            } else if (type_ == PopupSelectionType.Employee) {
                List<DB_Employee> employees = Repository.instance.GetAllEmployees();
                foreach (DB_Employee employee in employees) {
                    SelectableButtonUserControl s = new SelectableButtonUserControl();
                    s.InitButton(this, type_, employee.id, employee.name);
                    tableLayoutPanel1.Controls.Add(s);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
