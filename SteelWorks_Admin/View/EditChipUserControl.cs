using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Admin.Model;
using SteelWorks_Utils.Model;

namespace SteelWorks_Admin.View
{
	public partial class EditChipUserControl : UserControl
	{

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
			removeFromDb();
			addToDb();
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			removeFromDb();
		}

		private void ReloadChipFromDBButton_Click(object sender, EventArgs e)
		{
			reloadFromDb();
		}

		private void removeFromDb()
		{
			chipIdText.Enabled = false;
			EChipType chipType= Repository.instance.CheckChipType(chipIdText.Text);
			if(chipType == EChipType.Place)
			{
				Repository.instance.DeletePlace(chipIdText.Text);
			}

			if (chipType == EChipType.Employee)
			{
				Repository.instance.DeleteEmployee(chipIdText.Text);
			}
			chipIdText.Enabled = true ;
		}

		private void addToDb()
		{
			chipIdText.Enabled = false;
			chipStateComboBox.Enabled = false;
			if (chipStateComboBox.SelectedIndex == 1)
			{
				Repository.instance.InsertPlace(new DB_Place(chipIdText.Text, chipStringText.Text));
			}
			if (chipStateComboBox.SelectedIndex == 2)
			{
				Repository.instance.InsertEmployee(new DB_Employee(chipIdText.Text, chipStringText.Text));
			}
			chipStateComboBox.Enabled = true;
			chipIdText.Enabled = true;
		}


		private void reloadFromDb()
		{
			chipIdText.Enabled = false;
			Chip chip = new Chip();
			chip.chipId= chipIdText.Text;
			/*Chip chip = QueryFromDb(queriedId)*/
			chip.chipType= Repository.instance.CheckChipType(chip.chipId);
			chipStateComboBox.SelectedIndex = 0;
			if (chip.chipType == EChipType.Place)
			{
				chipStateComboBox.SelectedIndex = 1;
				chip.chipString = Repository.instance.GetPlaceByChip(chip.chipId).name;
			}
			if (chip.chipType == EChipType.Employee)
			{
				chipStateComboBox.SelectedIndex = 2;
				chip.chipString = Repository.instance.GetEmployeeByChip(chip.chipId).name;
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

			chipIdText.Enabled = true;
		}

		public void updateChip(String chipId)
		{
			chipIdText.Text = chipId;
			reloadFromDb();
		}
	}
}
