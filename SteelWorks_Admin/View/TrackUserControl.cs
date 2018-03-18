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
		public class ListboxItem
		{
			public string Text { get; set; }
			public object Value { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		private List<DB_Place> placesOut = null;
		private List<DB_Place> placesIn = null;
		private List<DB_Track> tracks = null;

		private ComboboxItem addComboBoxItem = new ComboboxItem()
		{
			Text = "<Nowy>",
			Value = -1
		};


		public TrackUserControl()
		{
			InitializeComponent();
			addTrackUserControl1.addButton.Click += new System.EventHandler(addTrackButtonHandler);


			reloadTracksFromDB();
			
		}

		private void addTrackButtonHandler(object sender, EventArgs e)
		{
			Repository.instance.InsertTrack(new DB_Track(addTrackUserControl1.TrackNameTextBox.Text, DateTime.Now));
			reloadTracksFromDB();
		}

		private void addTrackButton_Click(object sender, EventArgs e)
		{
			addTrackUserControl1.TrackNameTextBox.Text = "";
			addTrackUserControl1.Visible = true;
		}

		private void reloadTracksFromDB()
		{
			tracks = Repository.instance.GetAllTracks();


			trackComboBox.Items.Clear();
			trackComboBox.Items.Add(addComboBoxItem);
			foreach (DB_Track track in tracks)
			{
				ComboboxItem item = new ComboboxItem();
				item.Text = track.name;
				item.Value = track.id;
				trackComboBox.Items.Add(item);
			}

		}

		private void deletTrackButton_Click(object sender, EventArgs e)
		{
			if(trackComboBox.SelectedItem == null)
			{
				return;
			}
			Repository.instance.DeleteTrack((System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value));
			reloadTracksFromDB();
			trackComboBox.SelectedIndex = 0;
			/**/
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
			int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);


			placesOut = Repository.instance.GetAllPlaces();

			List<DB_Place> placesToAddIn = Repository.instance.GetAllPlacesInTrack(selectedTrackId);
			placesIn = new List<DB_Place>();

			trackNametextBox.Text = (trackComboBox.SelectedItem as ComboboxItem).Text.ToString();

			noTrackPlacesListBox.Items.Clear();
			trackPlacesListBox.Items.Clear();
			foreach (DB_Place place in placesOut)
			{
				if (placesToAddIn.Any(p => p.chipId==place.chipId))
				{
					placesIn.Add(place);
				}
				else
				{
					ListboxItem item = new ListboxItem();
					item.Text = place.name;
					item.Value = place.chipId;
					noTrackPlacesListBox.Items.Add(item);
				}
			}

			foreach (DB_Place place in placesIn)
			{
				placesOut.Remove(place);
				ListboxItem item = new ListboxItem();
				item.Text = place.name;
				item.Value = place.chipId;
				trackPlacesListBox.Items.Add(item);
			}
		}

		private void toTrackButton_Click(object sender, EventArgs e)
		{
			ListboxItem item = (ListboxItem) noTrackPlacesListBox.SelectedItem;
			if(item == null) { return; }
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
			if(trackComboBox.SelectedItem == addComboBoxItem)
			{
				DateTime nowTime = DateTime.Now;
				Repository.instance.InsertTrack(new DB_Track(trackNametextBox.Text, nowTime));
				reloadTracksFromDB();
				trackComboBox.SelectedIndex = -1;
				return;
			}
			int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
			Repository.instance.UpdateTrackName(selectedTrackId, trackNametextBox.Text);
			int selInd = trackComboBox.SelectedIndex;


			Repository.instance.DeleteAllTrackPlacesFromTrack(selectedTrackId);

			DB_TrackPlace dB_TrackPlace = new DB_TrackPlace();
			foreach(ListboxItem trackitem in trackPlacesListBox.Items)
			{
				dB_TrackPlace.trackId = selectedTrackId;
				dB_TrackPlace.placeId = (System.String) (trackitem.Value);
				Repository.instance.InsertTrackPlace(dB_TrackPlace);
			}

			reloadTracksFromDB();
			trackComboBox.SelectedIndex = selInd;
		}
	}
}
