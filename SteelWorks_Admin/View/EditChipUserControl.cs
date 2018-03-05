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
	public partial class EditChipUserControl : UserControl
	{
		public class Chip
		{
			public String chipId;
			public String chipType;
			public String chipString;

			public Chip()
			{
				chipId = null;
				chipType = null;
				chipString = null;
			}
		}
		public EditChipUserControl()
		{
			InitializeComponent();
		}

		private void chipStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			refreshChipStateName();
		}

		private void refreshChipStateName()
		{
			if (chipStateComboBox.SelectedIndex == 1)
			{
				chipStringName.Text = "Nazwa miejsca";
				return;
			}
			if (chipStateComboBox.SelectedIndex == 2)
			{
				chipStringName.Text = "Imię i nazwisko";
				return;
			}
			chipStringName.Text = "Nazwa";
		}

		private void addChangeButton_Click(object sender, EventArgs e)
		{
			/*remove -> add*/
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{

		}

		private void ReloadChipFromDBButton_Click(object sender, EventArgs e)
		{
			reloadFromDb();
		}

		private void reloadFromDb()
		{
			String queriedId = chipIdText.Text;
			Chip chip = new Chip();
			/*Chip chip = QueryFromDb(queriedId)*/
			chipStateComboBox.SelectedIndex = 0;
			if (chip.chipType == "place")
			{
				chipStateComboBox.SelectedIndex = 1;
			}
			if (chip.chipType == "worker")
			{
				chipStateComboBox.SelectedIndex = 2;
			}
			refreshChipStateName();
			if(chip.chipString == null)
			{
				chipStringText.Text = "";
			}
			else
			{
				chipStringText.Text = chip.chipString;
			}
		}

		public void updateChip(String chipId)
		{
			chipIdText.Text = chipId;
			reloadFromDb();
		}
	}
}
