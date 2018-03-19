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
	public partial class TeamsUserControl : UserControl
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
		public class ListboxItem
		{
			public string Text { get; set; }
			public object Value { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		private List<DbEmployee> placesOut = null;
		private List<DbEmployee> placesIn = null;
		private List<DbTeam> tracks = null;

		private ComboboxItem addComboBoxItem = new ComboboxItem()
		{
			Text = "<Nowy>",
			Value = -1
		};

		public TeamsUserControl()
		{
			InitializeComponent();
			reloadTracksFromDB();
		}

		private void reloadTracksFromDB()
		{
			try
			{
				tracks = Repository.team.GetAll();
			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}


			trackComboBox.Items.Clear();
			trackComboBox.Items.Add(addComboBoxItem);
			foreach (DbTeam track in tracks)
			{
				ComboboxItem item = new ComboboxItem();
				item.Text = track.name;
				item.Value = track.id;
				trackComboBox.Items.Add(item);
			}

		}

		private void deletTrackButton_Click(object sender, EventArgs e)
		{
			if (trackComboBox.SelectedItem == null || trackComboBox.SelectedItem == addComboBoxItem)
			{
				return;
			}
			Repository.team.Delete((System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value));
			reloadTracksFromDB();
			trackComboBox.SelectedIndex = 0;
		}

		private void trackComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (trackComboBox.SelectedItem == null)
			{
				noTrackPlacesListBox.Items.Clear();
				trackPlacesListBox.Items.Clear();
				trackNametextBox.Text = "";
				return;
			}

			if (trackComboBox.SelectedItem == addComboBoxItem)
			{
				trackNametextBox.Text = "Nowa";
				placesOut = Repository.employee.GetAll();
				placesIn = null;
			}
			else
			{
				int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
				placesOut = Repository.employee.GetAllNotInTeam(selectedTrackId);
				placesIn = Repository.employee.GetAllInTeam(selectedTrackId);
				trackNametextBox.Text = (trackComboBox.SelectedItem as ComboboxItem).Text.ToString();
			}

			noTrackPlacesListBox.Items.Clear();
			trackPlacesListBox.Items.Clear();
			foreach (DbEmployee place in placesOut)
			{
				ListboxItem item = new ListboxItem();
				item.Text = place.name;
				item.Value = place.chipId;
				noTrackPlacesListBox.Items.Add(item);
			}

			if (placesIn != null)
			{
				foreach (DbEmployee place in placesIn)
				{
					ListboxItem item = new ListboxItem();
					item.Text = place.name;
					item.Value = place.chipId;
					trackPlacesListBox.Items.Add(item);
				}
			}
		}

		private void toTrackButton_Click(object sender, EventArgs e)
		{
			ListboxItem item = (ListboxItem)noTrackPlacesListBox.SelectedItem;
			if (item == null) { return; }
			noTrackPlacesListBox.Items.Remove(item);
			trackPlacesListBox.Items.Add(item);
		}

		private void fromTrackButton_Click(object sender, EventArgs e)
		{
			ListboxItem item = (ListboxItem)trackPlacesListBox.SelectedItem;
			if (item == null) { return; }
			trackPlacesListBox.Items.Remove(item);
			noTrackPlacesListBox.Items.Add(item);
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (trackComboBox.SelectedItem == null)
			{
				return;
			}

			int selectedTrackId;

			if (trackComboBox.SelectedItem == addComboBoxItem)
			{
				selectedTrackId = Repository.team.Insert(new DbTeam()
				{
					name = trackNametextBox.Text
				}
				);
			}
			else
			{
				selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
				Repository.teamEmployee.DeleteAllFromTeam(selectedTrackId);
				Repository.team.UpdateName(selectedTrackId, trackNametextBox.Text);
			}

			DbTeamEmployee dB_TrackPlace = new DbTeamEmployee();
			foreach (ListboxItem trackitem in trackPlacesListBox.Items)
			{
				dB_TrackPlace.teamId = selectedTrackId;
				dB_TrackPlace.employeeId = (System.String)(trackitem.Value);
				Repository.teamEmployee.Insert(dB_TrackPlace);
			}

			reloadTracksFromDB();
			trackComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int)cbi.Value == selectedTrackId);

		}
	}
}
