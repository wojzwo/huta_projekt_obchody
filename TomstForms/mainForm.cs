using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomstForms
{
    public partial class fMain : Form
    {
        private Tengine engine;

        public fMain() {
            InitializeComponent();
            engine = new TomstForms.Tengine();
        }

        private void btReadDevice_Click(object sender, EventArgs e) {

            try {
                btReadDevice.Enabled = false;
                btOpenAdapter.Enabled = false;

                bool ret;


                Splash sp = new Splash();
                sp.engine = engine;
                if (sp.ShowDialog(this) == DialogResult.OK)
                    listBox.Items.Add("id:" + sp.ChipID);
                if (!sp.IsP3) {
                    sp.Dispose();
                    return;
                }
                sp.Dispose();

                // get number of events in p3 device
                int firstfree = 0, bank = 0;
                if (!engine.p3_eventcount(out firstfree, out bank)) {
                    listBox.Items.Add("p3_eventcount failed");
                    return;
                }
                //listBox.Items.Add(String.Format("FirstFree={0}, bank={1}", firstfree, bank));
                if (firstfree == 0)
                    return;

                // required before reading the data
                engine.p3_reconnect();
                Application.DoEvents();

                // setup callback to the engine printing ordinary events (and antivandals)
                engine.OnStart = ParserStart;
                engine.OnChipTouch = PrintChipTouch;
                engine.OnAntivandal = PrintAntivandal;
                if (engine.p3_readsensor(firstfree))
                    engine.p3_beep_ok();

                // set system time 
                ret = engine.p3_settime();

                // and delete sensor
                ret = engine.p3_deletesensor();

                //engine.closedev();
            } finally {
                btReadDevice.Enabled = true;
                btOpenAdapter.Enabled = true;
                listBox.Items.Add("----Read finished----");
            }
        }

        public void PrintAntivandal(Tengine.evstamp evs, Tengine.antivandal avl) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   AVT:{6:D2} {7}",
                            evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, avl.evtype, avl.description);
            listBox.Items.Add(ret);
            Application.DoEvents();
        }

        public void PrintChipTouch(Tengine.evstamp evs, string chipId) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   {6:D2}",
                evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, chipId);
            listBox.Items.Add(ret);
            Application.DoEvents();
        }

        public void ParserStart() {
            listBox.Items.Add("Start parsing");
        }

        private void btOpenAdapter_Click(object sender, EventArgs e) {
            engine.closedev();
            listBox.Items.Clear();

            if (!engine.opendev()) {
                listBox.Items.Add("cannot open TMD");
                return;
            }

            // get adapter number
            string adapter;
            if (engine.adapternumber(out adapter)) {
                string s = string.Format("Adapter number: {0}", adapter);
                listBox.Items.Add(s);
                Application.DoEvents();
            }

            btReadDevice.Enabled = true;
        }

        private void btReadChip_Click(object sender, EventArgs e) {

        }

        private void fMain_Load(object sender, EventArgs e) {

        }
    }
}
