using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelWorks_Admin.View
{
	public partial class addTrackUserControl : UserControl
	{
		public addTrackUserControl()
		{
			InitializeComponent();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}
	}
}
