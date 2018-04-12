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
	public partial class MailUserControl : UserControl
	{
		public class MailListboxItem
		{
			public string Text { get; set; }
			public DbMail Mail { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		MailListboxItem addnewListBoxItem = new MailListboxItem()
		{
			Text = "<Nowy>",
			Mail = null
		};

		private List<DbMail> mails = null;

		public MailUserControl()
		{
			InitializeComponent();
			reload_from_DB();
		}

		private void reload_from_DB()
		{
			try
			{
				mails = Repository.mail.GetAll();

			}
			catch (Exception ex)
			{
				//TODO: Exception handling code

			}

			maillListBox.Items.Clear();

			maillListBox.Items.Add(addnewListBoxItem);
			foreach (DbMail mail in mails)
			{
				MailListboxItem item = new MailListboxItem();
				if (mail.address == "")
				{
					mail.address = mail.id.ToString();
				}
				item.Text = mail.address;
				item.Mail = mail;

				maillListBox.Items.Add(item);

			}
			wrongemailLabel.Visible = false;
			maillListBox.SelectedIndex = 0;
		}

		bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!IsValidEmail(mailtextBox.Text))
			{
				wrongemailLabel.Visible = true;
				return;
			}
			if(maillListBox.SelectedItem == addnewListBoxItem)
			{
				try
				{
					Repository.mail.Insert(new DbMail()
					{
						address = mailtextBox.Text,
						isFullReport = fullCheckBox.Checked
					});
				}
				catch (Exception ex)
				{
					//TODO: Exception handling code

				}
			}
			else
			{
				((MailListboxItem)maillListBox.SelectedItem).Mail.address = mailtextBox.Text;
				((MailListboxItem)maillListBox.SelectedItem).Mail.isFullReport = fullCheckBox.Checked;
				try
				{
					Repository.mail.Update(((MailListboxItem)maillListBox.SelectedItem).Mail);
				}
				catch (Exception ex)
				{
					//TODO: Exception handling code

				}
			}
			reload_from_DB();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(maillListBox.SelectedItem!= null && ((MailListboxItem)maillListBox.SelectedItem).Mail != null)
			{
				try
				{
					Repository.mail.Delete(((MailListboxItem)maillListBox.SelectedItem).Mail.id);
				}
				catch (Exception ex)
				{
					//TODO: Exception handling code

				}
			}
			reload_from_DB();
		}

		private void maillListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (maillListBox.SelectedItem == addnewListBoxItem)
			{
				mailtextBox.Text = maillListBox.SelectedItem.ToString();
				fullCheckBox.Checked = false;
			}
			else
			{
				mailtextBox.Text = maillListBox.SelectedItem.ToString();
				fullCheckBox.Checked = ((MailListboxItem)maillListBox.SelectedItem).Mail.isFullReport;
			}

		}
	}
}
