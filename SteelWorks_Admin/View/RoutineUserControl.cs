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

		public void set_routine(DbRoutine routN)
		{
			reloadDataFromDB();
			routine = routN;
			nameTextBox.Text = routine.name;
			trackComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int)cbi.Value == routine.trackId);
			if (routine.teamId == 0)
			{
				team0CheckBox.Checked = true;
			}
			else
			{
				teamComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int)cbi.Value == routine.teamId);
			}
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
			refresh_fields();
			if (routine.id == -1)
			{
				nameTextBox.Text = "Nowa";
				reloadDataFromDB();
			}
		}

		public RoutineUserControl()
		{
			InitializeComponent();
			nameTextBox.Text = "";
			reloadDataFromDB();
			
		}


		List<DbTrack> tracks = null;
		List<DbTeam> teams = null;
		public void reloadDataFromDB()
		{
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
			trackComboBox.SelectedIndex = 0;
			teamComboBox.SelectedIndex = 0;
		}

		private void refresh_fields()
		{
			_64buttonUserControl1.set_buttons_active((int)cycleLengthNumeric.Value);
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
			shift2Label.Visible = shiftCheckBox.Checked;
			shiftNumeric.Visible = shiftCheckBox.Checked;
			teamComboBox.Enabled = !team0CheckBox.Checked;
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
			if (routine == null)
			{
				return;
			}
			routine.name = nameTextBox.Text;
			routine.trackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
			if (team0CheckBox.Checked)
			{
				routine.teamId = 0;
			}
			else
			{
				routine.teamId = (System.Int32)((teamComboBox.SelectedItem as ComboboxItem).Value);
			}
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
			if (trackComboBox.SelectedItem == null)
			{
				return;
			}
			if (teamComboBox.SelectedItem == null)
			{
				return;
			}
			update_routine();


			if (routine.id == -1)
			{
				try
				{
					Repository.routine.Insert(routine);
				}
				catch (Exception ex)
				{
					//TODO: Exception handling code
				}
			}
			else
			{
				try
				{
					Repository.routine.Update(routine);
				}
				catch (Exception ex)
				{
					//TODO: Exception handling code
				}
			}
		}

		private void team0CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			teamComboBox.Enabled = !team0CheckBox.Checked;
		}
	}
}
