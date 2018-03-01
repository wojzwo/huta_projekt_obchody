using Tomst;
using System.Drawing;
using System.Windows.Forms;
using System;
using SteelWorks_Worker.Model;
using SteelWorks_Worker.Utilities;
using SteelWorks_Worker.View;
using SteelWorks_Utils;

namespace SteelWorks_Worker.Controller
{
    public class WorkerMainController
    {
        private Tengine engine_ = null;
        private WorkerMainView view_ = null;
        private Repository repo_ = null;

        public void OnStartApp() {
            OpenAdapter();
        }

        public WorkerMainController(WorkerMainView view, Repository repo) {
            repo_ = repo;
            view_ = view;
            view_.InitController(this);
            engine_ = new Tengine();
        }

        ~WorkerMainController() {
            engine_.closedev();
        }

        private bool ReadFlashlight() {
            try {
                bool bIsFlashlightRead = WaitForFlashlightTouch(out string chipId);
                if (!bIsFlashlightRead) {
                    Debug.Log("Couldn't read flashlight", LogType.Error);
                    return false;
                }

                Debug.Log("Flashlight Id:" + chipId, LogType.Info);

                // get number of events in p3 device
                if (!engine_.p3_eventcount(out int firstfree, out int bank)) {
                    Debug.Log("Couldn't get flashlight event count", LogType.Error);
                    return false;
                }

                if (firstfree == 0) {
                    Debug.Log("No data to be parsed in flashlight", LogType.Warning);
                    return false;
                }

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
            } catch (Exception ex) {
                Debug.Log("Exception while parsing flashlight || " + ex.ToString(), LogType.Error);
                return false;
            } finally {
                Debug.Log("Flashlight eead finished", LogType.Info);
            }

            return true;
        }

        private bool OpenAdapter() {
            engine_.closedev();
            if (!engine_.opendev()) {
                Debug.Log("Cannot open TMD (adapter)", LogType.Error);
                return false;
            }

            if (!engine_.adapternumber(out string adapter)) {
                Debug.Log("Cannot read adapter number", LogType.Error);
                return false;
            }

            Debug.Log("Opened adapter number = " + adapter, LogType.Info);
            return true;
        }

        private void PrintKeypadTouch(Tengine.evstamp evs, int keyCode) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2} || [Keypad Code = {6:D2}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, keyCode);
            Debug.Log("Parsed keypad || " + ret, LogType.Info);
        }

        private void PrintAntivandal(Tengine.evstamp evs, Tengine.antivandal avl) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   [AVT:{6:D2} {7}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, avl.evtype, avl.description);
            Debug.Log("Parsed antivandal || " + ret, LogType.Info);
        }

        private void PrintChipTouch(Tengine.evstamp evs, string chipId) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2} || [ChipID = {6:D2}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, chipId);
            Debug.Log("Parsed chip || " + ret, LogType.Info);
        }

        private void ParserStart() {
            Debug.Log("Start parsing flashlight", LogType.Info);
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