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
	public partial class RoutineListUserControl : UserControl
	{
		public class RoutineListboxItem
		{
			public string Text { get; set; }
			public DbRoutine Routine { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		private List<DbRoutine> routines = null;
		private RoutineUserControl routineUC = null;

		public RoutineListUserControl()
		{
			InitializeComponent();
			routineUC = new RoutineUserControl();
			routineUC.saveRoutineButton.Click += handler_hide_panel;
			routineUC.cancelButton.Click += handler_hide_panel;
			panel1.Controls.Add(routineUC);
			reloadfromDB();
		}

		private void reloadfromDB()
		{
			try
			{
				routines = Repository.routine.GetAll();

			}
			catch (Exception ex)
			{
				//TODO: Exception handling code

			}
			

			routineListBox.Items.Clear();

			foreach(DbRoutine routine in routines)
			{
				RoutineListboxItem item = new RoutineListboxItem();
                if (routine.name == "")
				    routine.name = routine.id.ToString();

				item.Text = routine.name;
				item.Routine = routine;
				routineListBox.Items.Add(item);
			}
			routineListBox.SelectedIndex = 0;
		}

		private void deleteRoutineButton_Click(object sender, EventArgs e)
		{
			try
			{
				Repository.routine.Delete((routineListBox.SelectedItem as RoutineListboxItem).Routine.id);

			}
			catch (Exception ex)
			{
				//TODO: Exception handling code
			}
			reloadfromDB();
		}

		private void addRoutineButton_Click(object sender, EventArgs e)
		{
			routineUC.set_routine(new DbRoutine()
			{
				id = -1,
				name = "",
				shift = 0,
				trackId = 0,
				cycleLength = 0,
				teamId = 0,
				cycleMask = 0,
				startDay = DateTime.Today
			});
			panel1.Visible = true;
		}

		private void editRoutineButton_Click(object sender, EventArgs e)
		{
			routineUC.set_routine((routineListBox.SelectedItem as RoutineListboxItem).Routine);
			panel1.Visible = true;
		}

		private void handler_hide_panel(object sender, EventArgs e)
		{
			panel1.Visible = false;
			reloadfromDB();
		}

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
