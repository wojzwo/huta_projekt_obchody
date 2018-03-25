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
	public partial class RoutineUserControl : UserControl
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


		public RoutineUserControl()
		{
			InitializeComponent();
		}

		private void saveRoutineButton_Click(object sender, EventArgs e)
		{
			reloadDataFromDB();
		}

		private void reloadDataFromDB()
		{
			List<DbTrack> tracks = null;
			List<DbTeam> teams = null;


			try
			{
				tracks = Repository.track.GetAll();
				teams = Repository.team.GetAll();
			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}

			trackComboBox.Items.Clear();
			foreach (DbTrack track in tracks)
			{
				ComboboxItem item = new ComboboxItem();
				item.Text = track.name;
				item.Value = track.id;
				trackComboBox.Items.Add(item);
			}

			teamComboBox.Items.Clear();
			foreach (DbTeam team in teams)
			{
				ComboboxItem item = new ComboboxItem();
				item.Text = team.name;
				item.Value = team.id;
				teamComboBox.Items.Add(item);
			}

		}

		private void oneTimeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			cycleLengthNumeric.Enabled = false;
		}

		private void repeatedRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			cycleLengthNumeric.Enabled = true;
		}
	}
}
