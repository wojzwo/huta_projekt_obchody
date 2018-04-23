using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;

namespace SteelWorks_Worker.View
{
    public partial class DataRemoveSuccessUserControl : UserControl
    {
        public DataRemoveSuccessUserControl() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            } catch (Exception ex) {
                Debug.Log("Couldn't start new instance of program:\n" + ex.ToString(), LogType.Error);
            }

            Application.Exit();
        }
    }
}
