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
	public partial class ChipListUserControl : UserControl
	{

		private List<DB_Employee>  employees = new List<DB_Employee>();
		private List<DB_Place> places = new List<DB_Place>();
		public ChipListUserControl()
		{
			InitializeComponent();
			chipStateComboBox.SelectedIndex = 0;
			this.editChipUserControl1.RemoveButton.Click += new System.EventHandler(ReloadChipFromDBButton_Click);
			this.editChipUserControl1.addChangeButton.Click += new System.EventHandler(ReloadChipFromDBButton_Click);
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 1)
			{
				editChipUserControl1.updateChip(listView1.SelectedItems[0].SubItems[0].Text);
			}
		}

		private void chipStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			reloadListFromDB();
		}

		private void ReloadChipFromDBButton_Click(object sender, EventArgs e)
		{
			reloadListFromDB();

		}

		private void reloadListFromDB()
		{
			listView1.Items.Clear();
			string[] row = { "", "" };
			if (chipStateComboBox.SelectedIndex == 0)
			{
			    try {
			        places = Repository.instance.GetAllPlaces();
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }

                foreach (DB_Place place in places)
				{
					row[0] = place.chipId;
					row[1] = place.name;
					listView1.Items.Add(new ListViewItem(row));
				}
			}

			if (chipStateComboBox.SelectedIndex == 1)
			{
			    try {
			        employees = Repository.instance.GetAllEmployees();
			    } catch (Exception ex) {
			        //TODO: Exception handling code
                }

                foreach (DB_Employee emp in employees)
				{
					row[0] = emp.chipId;
					row[1] = emp.name;
					listView1.Items.Add(new ListViewItem(row));
				}
			}
		}
	}
}
