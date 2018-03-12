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
	public partial class TeamUserControl : UserControl
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

		private List<DbPlace> placesOut = new List<DbPlace>();
		private List<DbPlace> placesIn = new List<DbPlace>();
		private List<DbTrack> tracks = new List<DbTrack>();


		public TeamUserControl()
		{
			InitializeComponent();
			addTrackUserControl1.addButton.Click += new System.EventHandler(addTrackButtonHandler);


			reloadTracksFromDB();

		}

		private void addTrackButtonHandler(object sender, EventArgs e) {
		    try {
		        DbTrack track = new DbTrack() {
		            name = addTrackUserControl1.TrackNameTextBox.Text,
		            creationDate = DateTime.Now
		        };
		        Repository.track.Insert(track);
		    } catch (Exception ex) {
                //TODO: Exception handling code
		    }

		    reloadTracksFromDB();
		}

		private void addTrackButton_Click(object sender, EventArgs e)
		{
			addTrackUserControl1.TrackNameTextBox.Text = "";
			addTrackUserControl1.Visible = true;
		}

		private void reloadTracksFromDB()
		{
		    try {
		        tracks = Repository.track.GetAll();
		    } catch (Exception ex) {
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

		}

		private void deletTrackButton_Click(object sender, EventArgs e)
		{
			if (trackComboBox.SelectedItem == null)
			{
				return;
			}

		    try {
		        Repository.track.Delete((System.Int32) ((trackComboBox.SelectedItem as ComboboxItem).Value));
		    } catch (Exception ex) {
		        //TODO: Exception handling code
		    }

            reloadTracksFromDB();
			trackComboBox.SelectedIndex = 0;
		}

		private void trackComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (trackComboBox.SelectedItem == null)
			{
				return;
			}
			int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);

		    try {
		        placesOut = Repository.place.GetAll();
		    } catch (Exception ex) {
		        //TODO: Exception handling code
		    }

            List<DbPlace> placesToAddIn = new List<DbPlace>();

		    try {
		        placesToAddIn = Repository.place.GetAllInTrack(selectedTrackId);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
		    }

            placesIn = new List<DbPlace>();

			trackNametextBox.Text = (trackComboBox.SelectedItem as ComboboxItem).Text.ToString();

			noTrackPlacesListBox.Items.Clear();
			trackPlacesListBox.Items.Clear();
			foreach (DbPlace place in placesOut)
			{
				if (placesToAddIn.Any(p => p.chipId == place.chipId))
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

			foreach (DbPlace place in placesIn)
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
			int selectedTrackId = (System.Int32)((trackComboBox.SelectedItem as ComboboxItem).Value);

		    try {
		        Repository.track.UpdateName(selectedTrackId, trackNametextBox.Text);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
		    }

            int selInd = trackComboBox.SelectedIndex;

		    try {
		        Repository.trackPlace.DeleteAllFromTrack(selectedTrackId);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
		    }

            DbTrackPlace dB_TrackPlace = new DbTrackPlace();
			foreach (ListboxItem trackitem in trackPlacesListBox.Items)
			{
				dB_TrackPlace.trackId = selectedTrackId;
				dB_TrackPlace.placeId = (System.String)(trackitem.Value);

			    try {
			        Repository.trackPlace.Insert(dB_TrackPlace);
			    } catch (Exception ex) {
			        //TODO: Exception handling code
			    }
            }

			reloadTracksFromDB();
			trackComboBox.SelectedIndex = selInd;
		}
	}
}
