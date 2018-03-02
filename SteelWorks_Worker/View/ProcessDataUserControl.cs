using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelWorks_Worker.Model;

namespace SteelWorks_Worker.View
{
    public partial class ProcessDataUserControl : UserControl
    {
        public void AddEmployee(ChipData data) {
            if (data.bIsValid) {
                WorkerName.Text = "Pracownik: " + data.id;
                WorkerName.FlatAppearance.BorderColor = Color.Green;
            } else {
                WorkerName.Text = "Pracownik: ???";
                WorkerName.FlatAppearance.BorderColor = Color.Red;
            }
        }

        public void AddData(DataItemUserControl control) {
            MainTable.RowCount++;
            MainTable.Controls.Add(control, 0, MainTable.RowCount - 1);
            MainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        public ProcessDataUserControl() {
            InitializeComponent();
        }


    }
}
