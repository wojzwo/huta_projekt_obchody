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
		    EChipType chipType = EChipType.None;

            try {
		        chipType = Repository.instance.CheckChipType(chipIdText.Text);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
            }

            if (chipType == EChipType.Place)
			{
			    try {
			        Repository.instance.DeletePlace(chipIdText.Text);
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }
            }

			if (chipType == EChipType.Employee)
			{
			    try {
			        Repository.instance.DeleteEmployee(chipIdText.Text);
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }
            }
			chipIdText.Enabled = true ;
		}

		private void addToDb()
		{
			chipIdText.Enabled = false;
			chipStateComboBox.Enabled = false;
			if (chipStateComboBox.SelectedIndex == 1)
			{
			    try {
			        Repository.instance.InsertPlace(new DB_Place(chipIdText.Text, chipStringText.Text));
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }
            }
			if (chipStateComboBox.SelectedIndex == 2)
			{
			    try {
			        Repository.instance.InsertEmployee(new DB_Employee(chipIdText.Text, chipStringText.Text));
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }
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
		    try {
		        chip.chipType = Repository.instance.CheckChipType(chip.chipId);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
            }

            chipStateComboBox.SelectedIndex = 0;
			if (chip.chipType == EChipType.Place)
			{
				chipStateComboBox.SelectedIndex = 1;
			    try {
			        chip.chipString = Repository.instance.GetPlace(chip.chipId).name;
			    } catch (Exception ex) {
                    //TODO: Exception handling code
			    }
			}
			if (chip.chipType == EChipType.Employee)
			{
				chipStateComboBox.SelectedIndex = 2;
			    try {
			        chip.chipString = Repository.instance.GetEmployee(chip.chipId).name;
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }
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
