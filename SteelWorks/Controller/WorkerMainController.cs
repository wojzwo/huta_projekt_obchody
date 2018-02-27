using Tomst;
using System.Drawing;
using System.Windows.Forms;
using System;
using SteelWorks.Model;
using SteelWorks.View;

namespace SteelWorks.Controller
{
    public class WorkerMainController
    {
        private Tengine engine_ = null;
        private WorkerMainView view_ = null;
        private Repository repo_ = null;

        public WorkerMainController(WorkerMainView view, Repository repo) {
            repo_ = repo;
            view_ = view;
            view_.InitController(this);
            engine_ = new Tengine();
        }

        ~WorkerMainController() {
            engine_.closedev();
        }

        public void TestConnect() {
            view_.AddDebug("Connected successfully to database", Color.GhostWhite);
            foreach (string s in repo_.GetTest()) {
                view_.AddDebug(s, Color.AliceBlue);
            }
        }

        public void btReadDevice_Click() {
            try {
                view_.ToggleButtons(false);

                bool bIsFlashlightRead = WaitForFlashlightTouch(out string chipId);
                if (!bIsFlashlightRead) {
                    view_.AddDebug("Couldn't read flashlight", Color.Red);
                    return;
                }

                view_.AddDebug("Flashlight Id:" + chipId, Color.White);

                // get number of events in p3 device
                if (!engine_.p3_eventcount(out int firstfree, out int bank)) {
                    view_.AddDebug("Couldn't get flashlight event count", Color.Red);
                    return;
                }

                if (firstfree == 0)
                    return;

                engine_.p3_reconnect();
                Application.DoEvents();

                engine_.OnStart = ParserStart;
                engine_.OnChipTouch = PrintChipTouch;
                engine_.OnAntivandal = PrintAntivandal;
                engine_.OnKeypadTouch = PrintKeypadTouch;
                if (engine_.p3_readsensor(firstfree))
                    engine_.p3_beep_ok();

                // set system time 
                engine_.p3_settime();
                // and delete sensor
                engine_.p3_deletesensor();
            } finally {
                view_.ToggleButtons(true);
                view_.AddDebug("----Read finished----", Color.White);
            }
        }

        public void btOpenAdapter_Click() {
            engine_.closedev();
            if (!engine_.opendev()) {
                view_.AddDebug("Cannot open TMD (adapter)", Color.Red);
                return;
            }

            // get adapter number
            string adapter;
            if (engine_.adapternumber(out adapter)) {
                string s = string.Format("Adapter number: {0}", adapter);
                view_.AddDebug(s, Color.White);
            }

            view_.ToggleButtons(true);
        }

        private void PrintKeypadTouch(Tengine.evstamp evs, int keyCode) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2} || [Keypad Code = {6:D2}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, keyCode);
            view_.AddDebug(ret, Color.LightYellow);
        }

        private void PrintAntivandal(Tengine.evstamp evs, Tengine.antivandal avl) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   [AVT:{6:D2} {7}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, avl.evtype, avl.description);
            view_.AddDebug(ret, Color.LightBlue);
        }

        private void PrintChipTouch(Tengine.evstamp evs, string chipId) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2} || [ChipID = {6:D2}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, chipId);
            view_.AddDebug(ret, Color.LightGreen);
        }

        private void ParserStart() {
            view_.AddDebug("Start parsing", Color.White);
        }

        private bool WaitForFlashlightTouch(out string chipId) {
            const uint MAX_LOOP_COUNT = 100;

            bool bIsDetected = false;
            bool bIsP3 = false;
            uint loopCounter = 0;

            do {
                bIsDetected = engine_.chip_touch(out chipId, out bIsP3);
                Application.DoEvents();
                loopCounter++;
            } while (!bIsDetected && !(loopCounter >= MAX_LOOP_COUNT));

            return (bIsDetected && bIsP3);
        }
    }
}