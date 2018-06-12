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
    public partial class ReportSendView : UserControl
    {
        public ReportSendView() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            WorkerDataView view = (WorkerDataView)this.ParentForm;
            if (view == null) {
                Debug.Log("Couldn't retrieve WorkerDataView", LogType.Error);
                return;
            }

            view.ChangeUserControlToDeleteReader();
        }
    }
}
