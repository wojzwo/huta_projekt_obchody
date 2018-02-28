using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Admin.Controller;

namespace SteelWorks_Admin.View
{
    public partial class MainWindowView : Form
    {
        private MainWindowController controller_ = null;

        public void InitController(MainWindowController controller) {
            controller_ = controller;
        }

        public MainWindowView() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            controller_.PrintLogToFile();
        }
    }
}
