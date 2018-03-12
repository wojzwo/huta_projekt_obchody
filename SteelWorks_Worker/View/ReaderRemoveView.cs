using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Worker.Controller;

namespace SteelWorks_Worker.View
{
    public partial class ReaderRemoveView : Form
    {
        public WorkerMainController controller;

        public void ChangeUserControlToDataRemoveSuccess() {
            dataRemoveUserControl_.Visible = false;

            dataRemoveSuccessUserControl_.Visible = true;
        }

        public ReaderRemoveView(Controller.WorkerMainController controller) {
            InitializeComponent();
            this.controller = controller;
        }

        private void ReaderRemoveView_Load(object sender, EventArgs e) {

        }

        private void ReaderRemoveView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void dataRemoveSuccessUserControl__Load(object sender, EventArgs e) {

        }
    }
}
