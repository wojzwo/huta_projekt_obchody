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
using SteelWorks_Utils.Model;

namespace SteelWorks_Admin.View
{
	public partial class CheckPassUserControl : UserControl
	{
		String pass;
		public CheckPassUserControl()
		{
			InitializeComponent();
			Passlabel.Visible = false;
			PasstextBox.Visible = false;
			BadPassLabel.Visible = false;
			button1.Visible = false;
			try
			{
				pass = Repository.GetAdminPanelPassword();
				NoConnectionLabel.Visible = false;
				Passlabel.Visible = true;
				PasstextBox.Visible = true;
				button1.Visible = true;
			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			checkPass();
		}

		private void checkPass()
		{
			String chk = PasstextBox.Text;
			if (chk == pass)
			{

			}
			else
			{
				BadPassLabel.Visible = true;
			}
		}
		private void PasstextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
