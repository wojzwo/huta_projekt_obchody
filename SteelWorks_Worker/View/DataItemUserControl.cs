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
        ChangedMark
    }

    public partial class DataItemUserControl : UserControl
    {
        public bool bIsValid = true;
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

        public void OnSelectedMark(PopupView view, int id, string name, bool requireComment) {
            view.Close();
            Mark.Text = name;
            Mark.BackColor = System.Drawing.Color.GreenYellow;
            if (Place.Text != "???") {
                bIsValid = true;
            }

            bCommentRequired = requireComment;
            status = DataItemStatus.ChangedMark;
            ChangeItemHeader();
        }

        public void OnSelectedPlace(PopupView view, int id, string name) {
            view.Close();
            Place.Text = name;
            Place.BackColor = System.Drawing.Color.GreenYellow;
            if (Mark.Text != "???") {
                bIsValid = true;
            }

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

        public void Init(ChipData chip, KeypadData keypad) {
            DateTime validTime = (chip.bIsValid) ? chip.date : keypad.date;
            Date.Text = validTime.ToString("g");

            if (chip.bIsValid) {
                DB_Place place = Repository.instance.GetPlaceByChip(chip.id);
                if (place.id != -1) {
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
                DB_Mark mark = Repository.instance.GetMark(keypad.value);
                if (mark.id != -1) {
                    Mark.Text = mark.name;
                    bCommentRequired = mark.bCommentRequired;
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
            if (bIsValid && !bCommentRequired) {
                Panel.BackColor = System.Drawing.Color.FromArgb(190, 220, 190);
            } else if (bIsValid && bCommentRequired ) {
                Panel.BackColor = System.Drawing.Color.FromArgb(220, 190, 190);
            } else {
                Panel.BackColor = System.Drawing.Color.FromArgb(220, 190, 190);
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
            if (textBox1.Text.Length < 2 && bIsValid && bCommentRequired) {
                Panel.BackColor = System.Drawing.Color.FromArgb(220, 190, 190);
            } else if (textBox1.Text.Length >= 2 && bIsValid && bCommentRequired) {
                Panel.BackColor = System.Drawing.Color.FromArgb(220, 220, 190);
            }
        }

        private void Date_Click(object sender, EventArgs e) {

        }
    }
}
