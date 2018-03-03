using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MakarovDev.ExpandCollapsePanel;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class DataItemUserControl : UserControl
    {
        public bool bIsValid = true;

        public const int COLLAPSED_HEIGHT = 42;
        public const int EXPANDED_HEIGHT = 200;

        private ProcessDataUserControl control_= null;

        public void Collapse() {
            Panel.IsExpanded = false;
        }

        public void SetParent(ProcessDataUserControl control) {
            control_ = control;
        }

        public void Init(ChipData chip, KeypadData keypad) {
            DateTime validTime = (chip.bIsValid) ? chip.date : keypad.date;
            Date.Text = validTime.ToString("g");

            if (chip.bIsValid) {
                Place.Text = chip.id.ToString();
                Place.BackColor = System.Drawing.Color.Green;
            } else {
                Place.Text = "???";
                Place.BackColor = System.Drawing.Color.Red;
                bIsValid = false;
            }

            if (keypad.bIsValid) {
                Mark.Text = keypad.value.ToString();
                Mark.BackColor = System.Drawing.Color.Green;
            } else {
                Mark.Text = "???";
                Mark.BackColor = System.Drawing.Color.Red;
                bIsValid = false;
            }

            Panel.Text = Place.Text + " [" + Mark.Text + "]";
            if (bIsValid) {
                Panel.BackColor = System.Drawing.Color.FromArgb(210, 220, 210);
            } else {
                Panel.BackColor = System.Drawing.Color.FromArgb(220, 210, 210);
            }
        }

        public DataItemUserControl() {
            InitializeComponent();
            Collapse();
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
    }
}
