using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tomst;

namespace TomstForms
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            _labelMessage = "created";
        }

        private bool _stopLoop = false;
        private bool _IsP3 = false;

        public bool IsP3
        {
            get {return _IsP3;}
            set { _IsP3 = value; }
        }

        private Tengine _engine;
        public  Tengine engine
        {
            get { return _engine; }
            set { _engine = value; }
        }

        private string _labelMessage;
        public string labelMessage
        {
            get { return _labelMessage; }
            set { _labelMessage = value;
                labMsg.Text = value;
                }
        }

        private string _ChipID;
        public string ChipID
        {
            get { return _ChipID; }
            set { _ChipID = value; }
        }

        private bool waitfortouch()
        {
            bool ret = false;
           // int start = Environment.TickCount;

            _stopLoop = false;
            do
            {
                ret = _engine.chip_touch(out _ChipID, out _IsP3);
                Application.DoEvents();

            } while ((!ret) && (!_stopLoop));
            return (ret);
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            // waiting for medium 
            if (waitfortouch())
                this.DialogResult = DialogResult.OK;
            Close();
        }

        private void Splash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                _stopLoop = true;
        }
    }
}
