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
		UserControl ChipListUC = null;
		UserControl KeypadSettingUC = null;
		UserControl WelcomeUC = null;


		public AdminMainView()
        {
            InitializeComponent();
			if (WelcomeUC == null)
			{
				WelcomeUC = new WelcomeUserControl();
				WelcomeUC.Dock = DockStyle.Fill;
			}
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(WelcomeUC);
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
			if (ChipListUC == null)
			{
				ChipListUC = new ChipListUserControl();
				ChipListUC.Dock = DockStyle.Fill;
			}
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(ChipListUC);
		}

		private void keyPadSettingButton_Click(object sender, EventArgs e)
		{
			if (KeypadSettingUC == null)
			{
				KeypadSettingUC = new KeypadSettingUserControl();
				KeypadSettingUC.Dock = DockStyle.Fill;
			}
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(KeypadSettingUC);
		}
	}
}
