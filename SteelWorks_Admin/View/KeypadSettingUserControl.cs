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
	public partial class KeypadSettingUserControl : UserControl
	{
		int selectedNumber = -1;
		DbMark mark = new DbMark();


		public KeypadSettingUserControl()
		{
			InitializeComponent();
			uncolor_buttons();
		}

		private void reloadKeypadFromDB()
		{
		    try {
		        mark = Repository.mark.Get(selectedNumber);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
            }

            markStringTextBox.Text = mark.description;
			bCommentRequieredCheckBox.Checked = mark.requiresComment;
		}

		private void SaveToDBButton_Click(object sender, EventArgs e)
		{
			if(selectedNumber == -1)
			{
				noSelectionLabel.Visible = true;
				return;
			}
			mark.description = markStringTextBox.Text;
			mark.requiresComment = bCommentRequieredCheckBox.Checked;

		    try {
		        Repository.mark.Update(mark);
		    } catch (Exception ex) {
		        //TODO: Exception handling code
            }
        }


		private void uncolor_buttons()
		{
			noSelectionLabel.Visible = false;
			button1.BackColor = Color.WhiteSmoke;
			button2.BackColor = Color.WhiteSmoke;
			button3.BackColor = Color.WhiteSmoke;
			button4.BackColor = Color.WhiteSmoke;
			button5.BackColor = Color.WhiteSmoke;
			button6.BackColor = Color.WhiteSmoke;
			button7.BackColor = Color.WhiteSmoke;
			button8.BackColor = Color.WhiteSmoke;
			button9.BackColor = Color.WhiteSmoke;
			button10.BackColor = Color.WhiteSmoke;
			button11.BackColor = Color.WhiteSmoke;
			button12.BackColor = Color.WhiteSmoke;
			button1.Text = "1";
			button2.Text = "2";
			button3.Text = "3";
			button4.Text = "4";
			button5.Text = "5";
			button6.Text = "6";
			button7.Text = "7";
			button8.Text = "8";
			button9.Text = "9";
			button10.Text = "C";
			button11.Text = "0";
			button12.Text = "E";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = ""+selectedNumber;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Int32.TryParse(((System.Windows.Forms.Button)sender).Text, out selectedNumber); reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "" + selectedNumber;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			selectedNumber = 12; reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "C";
		}

		private void button11_Click(object sender, EventArgs e)
		{
			selectedNumber = 0; reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "0";
		}

		private void button12_Click(object sender, EventArgs e)
		{
			selectedNumber = 14; reloadKeypadFromDB();
			uncolor_buttons();
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightBlue;
			numberText.Text = "E";
		}


	}
}
