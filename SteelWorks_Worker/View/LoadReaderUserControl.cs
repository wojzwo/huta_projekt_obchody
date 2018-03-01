using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;

namespace SteelWorks_Worker.View
{
    public partial class LoadReaderUserControl : UserControl
    {
        public LoadReaderUserControl() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void StartButton_Click(object sender, EventArgs e) {
            WorkerMainView view = (WorkerMainView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerMainView", LogType.Error);
                return;
            }

            bool bSuccess = view.controller.OnLoadReader();
            if (bSuccess) {
                StartButton.Text = "[pH] Read success - check logs";
            } else {
                StartButton.Text = "[pH] Read failure - check logs";
            }
        }
    }
}
