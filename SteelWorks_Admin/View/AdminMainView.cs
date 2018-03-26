using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils;
using SteelWorks_Utils.Controller;



namespace SteelWorks_Admin.View
{
    public partial class AdminMainView : Form
    {
		UserControl LoadChipUC = null;

		public AdminMainView()
        {
            InitializeComponent();
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new WelcomeUserControl());
		}


		private void LoadChipButton_Click(object sender, EventArgs e)
		{
			if (LoadChipUC == null)
			{
				LoadChipUC = new LoadChipUserControl();
				LoadChipUC.Dock = DockStyle.Fill;
			}
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(LoadChipUC);
		}


		private void chipListButton_Click(object sender, EventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new ChipListUserControl());
		}

		private void keyPadSettingButton_Click(object sender, EventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new KeypadSettingUserControl());
		}

		private void trackButton_Click(object sender, EventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new TrackUserControl());
		}

		private void teamButton_Click(object sender, EventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new TeamsUserControl());
		}

		private void routineButton_Click(object sender, EventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(new RoutineListUserControl());
		}
	}
}
