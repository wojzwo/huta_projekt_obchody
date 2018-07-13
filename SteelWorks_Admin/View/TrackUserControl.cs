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

		private List<DbPlace> placesOut = null;
		private List<DbPlace> placesIn = null;
		private List<DbTrack> tracks = null;

		private ComboboxItem addComboBoxItem = new ComboboxItem()
		{
			Text = "<Nowy>",
			Value = -1
		};


		public TrackUserControl()
		{
			InitializeComponent();
			reloadTracksFromDB();
			
		}


		private void reloadTracksFromDB()
		{
			try
			{
				tracks = Repository.track.GetAll();

			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}


			trackComboBox.Items.Clear();
			trackComboBox.Items.Add(addComboBoxItem);
			foreach (DbTrack track in tracks)
			{
				ComboboxItem item = new ComboboxItem();
				item.Text = track.name;
				item.Value = track.id;
				trackComboBox.Items.Add(item);
			}

		}

		private void deletTrackButton_Click(object sender, EventArgs e)
		{
			if(trackComboBox.SelectedItem == null || trackComboBox.SelectedItem== addComboBoxItem)
			{
				return;
			}
			Repository.track.Delete((System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value));
			reloadTracksFromDB();
			trackComboBox.SelectedIndex = 0;
			/**/
		}

		//private void trackComboBox_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	if (trackComboBox.SelectedItem == null)
		//	{
		//		noTrackPlacesListBox.Items.Clear();
		//		trackPlacesListBox.Items.Clear();
		//		trackNametextBox.Text = "";
		//		return;
		//	}

		//	if (trackComboBox.SelectedItem == addComboBoxItem)
		//	{
		//		trackNametextBox.Text = "Nowa";
		//		placesOut = Repository.place.GetAll();
		//		placesIn = null;
		//	}
		//	else
		//	{
		//		int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
		//		placesOut = Repository.place.GetAllNotInTrack(selectedTrackId);
		//		placesIn = Repository.place.GetAllInTrack(selectedTrackId);
		//		trackNametextBox.Text = (trackComboBox.SelectedItem as ComboboxItem).Text.ToString();
		//	}

		//	noTrackPlacesListBox.Items.Clear();
		//	trackPlacesListBox.Items.Clear();
		//	foreach (DbPlace place in placesOut)
		//	{
		//		ListboxItem item = new ListboxItem();
		//		item.Text = place.name;
		//		item.Value = place.chipId;
		//		noTrackPlacesListBox.Items.Add(item);
		//	}

		//	if(placesIn != null)
		//	{
		//		foreach (DbPlace place in placesIn)
		//		{
		//			ListboxItem item = new ListboxItem();
		//			item.Text = place.name;
		//			item.Value = place.chipId;
		//			trackPlacesListBox.Items.Add(item);
		//		}
		//	}
		//}

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

			int selectedTrackId;

			if (trackComboBox.SelectedItem == addComboBoxItem)
			{
				DateTime nowTime = DateTime.Now;
				selectedTrackId = Repository.track.Insert(new DbTrack()
				{
					name = trackNametextBox.Text,
					creationDate = nowTime
				}
				);
			}
			else
			{
				selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
				Repository.trackPlace.DeleteAllFromTrack(selectedTrackId);
				Repository.track.UpdateName(selectedTrackId, trackNametextBox.Text);
			}

			DbTrackPlace dB_TrackPlace = new DbTrackPlace();
			foreach (ListboxItem trackitem in trackPlacesListBox.Items)
			{
				dB_TrackPlace.trackId = selectedTrackId;
				dB_TrackPlace.placeId = (System.String)(trackitem.Value);
				Repository.trackPlace.Insert(dB_TrackPlace);
			}

			reloadTracksFromDB();
			trackComboBox.SelectedIndex = trackComboBox.Items.Cast<ComboboxItem>().ToList().FindIndex(cbi => (int) cbi.Value == selectedTrackId);

		}

        private void trackComboBox_SelectedIndexChanged_1(object sender, EventArgs e) {
            if (trackComboBox.SelectedItem == null) {
                noTrackPlacesListBox.Items.Clear();
                trackPlacesListBox.Items.Clear();
                trackNametextBox.Text = "";
                return;
            }

            if (trackComboBox.SelectedItem == addComboBoxItem) {
                trackNametextBox.Text = "Nowa";
                placesOut = Repository.place.GetAll();
                placesIn = null;
            } else {
                int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);
                placesOut = Repository.place.GetAllNotInTrack(selectedTrackId);
                placesIn = Repository.place.GetAllInTrack(selectedTrackId);
                trackNametextBox.Text = (trackComboBox.SelectedItem as ComboboxItem).Text.ToString();
            }

            placesOut.Sort((x, y) => x.name.CompareTo(y.name));
            placesIn?.Sort((x,y) => x.name.CompareTo(y.name));

            noTrackPlacesListBox.Items.Clear();
            trackPlacesListBox.Items.Clear();
            foreach (DbPlace place in placesOut) {
                ListboxItem item = new ListboxItem();
                item.Text = place.name;
                item.Value = place.chipId;
                noTrackPlacesListBox.Items.Add(item);
            }

            if (placesIn != null) {
                foreach (DbPlace place in placesIn) {
                    ListboxItem item = new ListboxItem();
                    item.Text = place.name;
                    item.Value = place.chipId;
                    trackPlacesListBox.Items.Add(item);
                }
            }
        }

        private void noTrackPlacesListBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
