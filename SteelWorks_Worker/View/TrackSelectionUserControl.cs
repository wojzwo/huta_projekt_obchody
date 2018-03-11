using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils.Model;

namespace SteelWorks_Worker.View
{
    public partial class TrackSelectionUserControl : UserControl
    {
        private Dictionary<string, int> trackIdByListName_ = new Dictionary<string, int>();
        private string currentItem_ = "";

        public void GetTracks() {
            try {
                //Repository.instance.Get
            } catch (Exception ex) {

            }
        }

        public TrackSelectionUserControl() {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (currentItem_ == "")
                return;
        }
    }
}
