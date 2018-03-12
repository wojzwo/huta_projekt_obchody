using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MakarovDev.ExpandCollapsePanel;
using SteelWorks_Utils.Model;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public enum PopupSelectionType
    {
        Place,
        Employee,
        Mark
    }

    public enum DataItemStatus
    {
        ProperlyLoaded,
        ChangedPlace,
        ChangedMark,
        NotVisited
    }

    public partial class DataItemUserControl : UserControl
    {
        public bool bIsValid = true;
        public bool bNotVisited = false;
        public bool bCommentRequired = false;

        public const int COLLAPSED_HEIGHT = 42;
        public const int EXPANDED_HEIGHT = 200;

        private ProcessDataUserControl control_= null;
        private DataItemStatus status = DataItemStatus.ProperlyLoaded;

        public ReportDataItem GetReportInfo() {
            return new ReportDataItem() {
                placeName = Place.Text,
                placeComment = textBox1.Text,
                placeMark = Mark.Text,
                placeStatus = status,
                placeVisitDate = DateTime.Parse(Date.Text)
            };
        }

        public string GetComment() {
            return textBox1.Text;
        }

        public void OnSelectedMark(PopupView view, string name, bool requireComment) {
            view.Close();
            Mark.Text = name;
            Mark.BackColor = System.Drawing.Color.GreenYellow;
            if (Place.Text != "???") {
                bIsValid = true;
            }

            bCommentRequired = requireComment;
            if (status == DataItemStatus.ProperlyLoaded)
                status = DataItemStatus.ChangedMark;
            ChangeItemHeader();
        }

        public void OnSelectedPlace(PopupView view, string name) {
            view.Close();
            Place.Text = name;
            Place.BackColor = System.Drawing.Color.GreenYellow;
            if (Mark.Text != "???") {
                bIsValid = true;
            }

            if (status == DataItemStatus.ProperlyLoaded)
                status = DataItemStatus.ChangedPlace;
            ChangeItemHeader();
        }

        public void Expand() {
            control_.CollapsePrevious(this);
            Panel.IsExpanded = true;
            Size = new Size(Size.Width, EXPANDED_HEIGHT);
        }

        public void Collapse() {
            Panel.IsExpanded = false;
            Size = new Size(Size.Width, COLLAPSED_HEIGHT);
        }

        public void SetParent(ProcessDataUserControl control) {
            control_ = control;
        }

        public void Init(DbPlace place) {
            Date.Text = DateTime.Now.ToString("g");
            Place.Text = place.name;
            Place.BackColor = System.Drawing.Color.Green;
            Place.Enabled = false;

            Mark.Text = "???";
            Mark.BackColor = System.Drawing.Color.Red;
            Mark.Enabled = true;
            bIsValid = false;
            bNotVisited = true;
            status = DataItemStatus.NotVisited;

            ChangeItemHeader();
        }

        public void Init(ChipData chip, KeypadData keypad) {
            DateTime validTime = (chip.bIsValid) ? chip.date : keypad.date;
            Date.Text = validTime.ToString("g");

            if (chip.bIsValid) {
                DbPlace place = null;
                try {
                    place = Repository.place.Get(chip.id);
                } catch (Exception ex) {
                    //TODO: Exception handling code
                }

                if (place != null) {
                    Place.Text = place.name;
                    Place.BackColor = System.Drawing.Color.Green;
                    Place.Enabled = false;
                } else {
                    Place.Text = "--Chip pracownika--";
                    Place.BackColor = System.Drawing.Color.Red;
                    Place.Enabled = true;
                    bIsValid = false;
                }
            } else {
                Place.Text = "???";
                Place.BackColor = System.Drawing.Color.Red;
                Place.Enabled = true;
                bIsValid = false;
            }

            if (keypad.bIsValid) {
                DbMark mark = null;
                try {
                    mark = Repository.mark.Get(keypad.value);
                } catch (Exception ex) {
                    //TODO: Exception handling code
                }

                if (mark != null) {
                    Mark.Text = mark.description;
                    bCommentRequired = mark.requiresComment;
                } else {
                    Mark.Text = keypad.value.ToString();
                }

                Mark.BackColor = System.Drawing.Color.Green;
                Mark.Enabled = false;
            } else {
                Mark.Text = "???";
                Mark.BackColor = System.Drawing.Color.Red;
                Mark.Enabled = true;
                bIsValid = false;
            }

            ChangeItemHeader();
        }

        public DataItemUserControl() {
            InitializeComponent();
            Collapse();
        }

        private void ChangeItemHeader() {
            Panel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            Panel.Text = Place.Text + " [" + Mark.Text + "]                                                               " +
                         "                                                                                             " +
                         "                                                                                             ";
            SetProperBackgroundColor();
        }

        private void SetProperBackgroundColor() {
            System.Drawing.Color red = System.Drawing.Color.FromArgb(220, 190, 190);
            System.Drawing.Color yellow = System.Drawing.Color.FromArgb(220, 220, 190);
            System.Drawing.Color green = System.Drawing.Color.FromArgb(190, 220, 190);

            if (!bIsValid) {
                Panel.BackColor = red;
            } else {
                if (textBox1.Text.Length < 2) {
                    if (bCommentRequired || bNotVisited) {
                        Panel.BackColor = red;
                    } else {
                        if (status == DataItemStatus.ProperlyLoaded)
                            Panel.BackColor = green;
                        else {
                            Panel.BackColor = yellow;
                        }
                    }
                } else {
                    if (status == DataItemStatus.ProperlyLoaded)
                        Panel.BackColor = green;
                    else {
                        Panel.BackColor = yellow;
                    }
                }
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e) {

        }

        private void Panel_ExpandCollapse(object sender, MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs e) {
            if (e.IsExpanded) {
                control_.CollapsePrevious(this);
                Panel.IsExpanded = true;
                Size = new Size(Size.Width, EXPANDED_HEIGHT);
            } else {
                Size = new Size(Size.Width, COLLAPSED_HEIGHT);
            }
        }

        private void Place_Click(object sender, EventArgs e) {
            PopupView popup = new PopupView();
            popup.InitializeControl(this, PopupSelectionType.Place);
            popup.Show();
        }

        private void Mark_Click(object sender, EventArgs e) {
            PopupView popup = new PopupView();
            popup.InitializeControl(this, PopupSelectionType.Mark);
            popup.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            SetProperBackgroundColor();
        }

        private void Date_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            control_.DeleteDataItem(this);
        }
    }
}
