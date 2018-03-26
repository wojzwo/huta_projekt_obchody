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

		DbRoutine routine = null;

		public void load_routine(DbRoutine routN)
		{
			reloadDataFromDB();
			routine = routN;
			nameTextBox.Text = routine.name;
			trackComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int)cbi.Value == routine.trackId);
			teamComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int)cbi.Value == routine.teamId);
			beginDateTime.Value = routine.startDay;
			if (routine.cycleLength == 0)
			{
				repeatedCheckBox.Checked = false;
			}
			else
			{
				repeatedCheckBox.Checked = true;
				cycleLengthNumeric.Value = routine.cycleLength;
			}
			_64buttonUserControl1.set_mask(routine.cycleMask);
			if (routine.shift == 0)
			{
				shiftCheckBox.Checked = false;
			}
			else
			{
				shiftCheckBox.Checked = true;
				shiftNumeric.Value = routine.shift;
			}
		}

		public RoutineUserControl()
		{
			InitializeComponent();
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



		private void cycleLengthNumeric_ValueChanged(object sender, EventArgs e)
		{
			_64buttonUserControl1.set_buttons_active((int) cycleLengthNumeric.Value);
		}

		private void repeatedCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (repeatedCheckBox.Checked == true)
			{
				cycleLengthNumeric.Enabled = true;
				_64buttonUserControl1.set_buttons_active((int)cycleLengthNumeric.Value);
			}
			else
			{
				cycleLengthNumeric.Enabled = false;
				_64buttonUserControl1.set_buttons_active(0);
			}
		}

		private void shiftCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			shift2Label.Visible = shiftCheckBox.Checked;
			shiftNumeric.Visible = shiftCheckBox.Checked;
		}

		private void update_routine()
		{
			routine.name = nameTextBox.Text;
			routine.trackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
			routine.teamId = (System.Int32)((teamComboBox.SelectedItem as ComboboxItem).Value);
			routine.startDay = beginDateTime.Value;
			if (repeatedCheckBox.Checked)
			{
				routine.cycleLength = (int) cycleLengthNumeric.Value;
				routine.cycleMask = _64buttonUserControl1.get_mask();
			}
			else
			{
				routine.cycleLength = 0;
			}
			if (shiftCheckBox.Checked)
			{
				routine.shift = (int)shiftNumeric.Value;
			}
			else
			{
				routine.shift = 0;
			}
		}

		private void saveRoutineButton_Click(object sender, EventArgs e)
		{
			update_routine();
			//Todo DB comunication
		}
	}
}
