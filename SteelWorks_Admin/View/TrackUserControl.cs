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

namespace SteelWorks_Admin.View
{


	public partial class TrackUserControl : UserControl
	{
		public class ComboboxItem
		{
			public string Text { get; set; }
			public object Value { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		private List<DB_Place> places = null;

		public TrackUserControl()
		{
			InitializeComponent();

			ComboboxItem item = new ComboboxItem();

			item.Text = "xD";
			item.Value = 1;

			trackComboBox.Items.Add(item);
		}

		private void addTrackButton_Click(object sender, EventArgs e)
		{

		}

		private void deletTrackButton_Click(object sender, EventArgs e)
		{

			/**/
		}
	}
}
