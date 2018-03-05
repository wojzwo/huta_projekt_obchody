using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Utils.Controller;
using Tomst;
using SteelWorks_Utils;

namespace SteelWorks_Admin.View
{
	public partial class LoadChipUserControl : UserControl
	{
		private ChipController chipController = null;


		public LoadChipUserControl()
		{
			InitializeComponent();
			
		}

		private void LoadChipUserControl_Load(object sender, EventArgs e)
		{
			chipController = new ChipController();
			ConnectAndInitUI();
		}


		private void ConnectAndInitUI()
		{
			
			bool bAdapterConnected = chipController.OpenAdapter();
			if (bAdapterConnected)
			{
				AdapterStateLabel.ForeColor = System.Drawing.Color.Green;
				AdapterStateLabel.Text = "Podłączony";
				ReadReaderButton.Enabled = true;
				EraseReaderButton.Enabled = true;
			}
			else
			{
				AdapterStateLabel.ForeColor = System.Drawing.Color.Red;
				AdapterStateLabel.Text = "Niepodłączony";
				ReadReaderButton.Enabled = false;
				EraseReaderButton.Enabled = false;
			}
		}

		private void EraseReaderButton_Click(object sender, EventArgs e)
		{
			chipController.EraseReader(ParentForm);
		}

		private void ReconnectAdapterButton_Click_1(object sender, EventArgs e)
		{
			ConnectAndInitUI();
		}

		private void ReadReaderButton_Click(object sender, EventArgs e)
		{
			if(!chipController.ReadReader(ParentForm, clrChipList, addChipToList, LogKeypad, LogAntivandal))
			{
				clrChipList();
			}
		}

		public void clrChipList()
		{
			ChipListBox.Items.Clear();
		}

		private void addChipToList(Tengine.evstamp evs, string chipId)
		{
			DateTime date = evs.ToDateTime();
			string log = String.Format(date.ToString("G") + " || [Chip id = " + chipId + "]");
			Debug.Log("Parsed chip || " + log, LogType.Info);

			ChipListBox.Items.Add(chipId);
		}

		private void LogKeypad(Tengine.evstamp evs, int keyCode)
		{
			DateTime date = evs.ToDateTime();
			string log = String.Format(date.ToString("G") + " || [Keypad Code = " + keyCode.ToString() + "]");
			Debug.Log("Parsed keypad || " + log, LogType.Info);
		}

		private void LogAntivandal(Tengine.evstamp evs, Tengine.antivandal avl)
		{
			string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   [AVT:{6:D2} {7}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, avl.evtype, avl.description);
			Debug.Log("Parsed antivandal || " + ret, LogType.Info);
		}

		private void ChipListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			editChipUserControl1.updateChip((String) ChipListBox.SelectedItem);
		}

		private void editChipUserControl1_Load(object sender, EventArgs e)
		{

		}
	}
}
