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

        public void OnSelectedPlace(string name) {
            control_.OnSelectedPlace(this, name);
        }

        public void OnSelectedMark(string name, bool requireComment) {
            control_.OnSelectedMark(this, name, requireComment);
        }

        public void OnSelectedEmployee(string name) {
            view_.OnSelectedEmployee(this, name);
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
                List<DbPlace> places = new List<DbPlace>();
                try {
                    places = Repository.place.GetAll();
                } catch (Exception ex) {
                    //TODO: Exception handling code
                }

                Dictionary<string, List<DbPlace>> placeByDepartment = new Dictionary<string, List<DbPlace>>();
                foreach (DbPlace p in places) {
                    if (!placeByDepartment.ContainsKey(p.department))
                        placeByDepartment.Add(p.department, new List<DbPlace>());
                    placeByDepartment[p.department].Add(p);
                }

                foreach (KeyValuePair<string, List<DbPlace>> pair in placeByDepartment) {
                    Label dep = new Label();
                    dep.Text = pair.Key;
                    dep.BackColor = Color.DarkSlateGray;
                    dep.ForeColor = Color.White;
                    dep.Font = new Font(FontFamily.GenericMonospace, 15.0f, FontStyle.Bold);
                    dep.Width = 405;
                    dep.TextAlign = ContentAlignment.MiddleLeft;
                    dep.Height = 34;
                    tableLayoutPanel1.Controls.Add(dep);

                    foreach (DbPlace p in pair.Value) {
                        SelectableButtonUserControl s = new SelectableButtonUserControl();
                        s.InitButton(this, type_, p.name);
                        tableLayoutPanel1.Controls.Add(s);
                    }
                }
            } else if (type_ == PopupSelectionType.Mark) {
                List<DbMark> marks = new List<DbMark>();
                try {
                    marks = Repository.mark.GetAll();
                } catch (Exception ex) {
                    //TODO: Exception handling code
                }

                foreach (DbMark mark in marks) {
                    SelectableButtonUserControl s = new SelectableButtonUserControl();
                    s.InitButton(this, type_, mark.description, mark.requiresComment);
                    tableLayoutPanel1.Controls.Add(s);
                }
            } else if (type_ == PopupSelectionType.Employee) {
                List<DbEmployee> employees = new List<DbEmployee>();
                try {
                    employees = Repository.employee.GetAll();
                } catch (Exception ex) {
                    //TODO: Exception handling code
                }

                foreach (DbEmployee employee in employees) {
                    SelectableButtonUserControl s = new SelectableButtonUserControl();
                    s.InitButton(this, type_, employee.name);
                    tableLayoutPanel1.Controls.Add(s);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
