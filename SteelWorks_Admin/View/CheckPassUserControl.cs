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
			try
			{
				pass = Repository.GetAdminPanelPassword();
				NoConnectionLabel.Visible = false;
				Passlabel.Visible = true;
				PasstextBox.Visible = true;
			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}
			
		}
	}
}
