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
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class DataItemUserControl : UserControl
    {
        public bool bIsValid = true;

        public void Init(ChipData chip, KeypadData keypad) {
            DateTime validTime = (chip.bIsValid) ? chip.date : keypad.date;
            Date.Text = validTime.ToString("g");

            if (chip.bIsValid) {
                Place.Text = chip.id.ToString();
                Place.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            } else {
                Place.Text = "???";
                Place.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                bIsValid = false;
            }

            if (keypad.bIsValid) {
                Mark.Text = keypad.value.ToString();
                Mark.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            } else {
                Mark.Text = "???";
                Mark.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                bIsValid = false;
            }
        }

        public DataItemUserControl() {
            InitializeComponent();
        }
    }
}
