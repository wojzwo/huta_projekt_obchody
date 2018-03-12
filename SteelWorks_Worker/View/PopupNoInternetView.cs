using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelWorks_Worker.View
{
    public partial class PopupNoInternetView : Form
    {
        public PopupNoInternetView() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Application.Restart();
        }
    }
}
