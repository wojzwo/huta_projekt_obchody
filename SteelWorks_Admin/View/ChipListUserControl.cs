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
	public partial class ChipListUserControl : UserControl
	{
		public ChipListUserControl()
		{
			InitializeComponent();
			chipStateComboBox.SelectedIndex = 0;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*editChipUserControl1.updateChip(listView1.SelectedItems[0]);*/
		}
	}
}
