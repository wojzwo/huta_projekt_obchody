using Tomst;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Threading;
using SteelWorks_Worker.Model;
using SteelWorks_Worker.View;
using SteelWorks_Utils;
using SteelWorks_Utils.Model;

namespace SteelWorks_Worker.Controller
{
    public enum FlashlightLoadState
    {
        EmptySet,
        LoadingError,
        Success
    }

    public class WorkerMainController
    {
        private ChipData employee_ = null;
        private List<ChipData> chips_ = new List<ChipData>();
        private List<KeypadData> keypads_ = new List<KeypadData>();
        private bool bLastParsedChip = false;
        private bool bFirstParse = true;

        private Tengine engine_ = null;
        private WorkerMainView view_ = null;
        private WorkerDataController workerDataController_ = null;

        public void ChangeToDataMode() {
            workerDataController_.Activate(view_, this);
            workerDataController_.InitData(employee_, chips_, keypads_);
            view_.Hide();
        }

        public bool EraseReader() {
            try {
                // set system time 
                engine_.p3_settime();
                // and delete sensor
                bool success = engine_.p3_deletesensor();
                if (success) {
                    engine_.p3_beep_ok();
                    return true;
                }
            } catch (Exception ex) {
                Debug.Log("Error while erasing data\n" + ex.ToString(), LogType.TomstError);
            }

            return false;
        }

        public bool OnStartApp() {
            return OpenAdapter();
        }

        public FlashlightLoadState OnLoadReader() {
            return ReadFlashlight();
        }

        public WorkerMainController(WorkerMainView view, WorkerDataController workerDataController) {
            workerDataController_ = workerDataController;
            view_ = view;
            view_.InitController(this);
            engine_ = new Tengine();
        }

        ~WorkerMainController() {
            engine_.closedev();
        }

        private FlashlightLoadState ReadFlashlight() {
            try {
                bool bIsFlashlightRead = WaitForFlashlightTouch(out string chipId);
                if (!bIsFlashlightRead) {
                    Debug.Log("Couldn't read flashlight", LogType.Error);
                    return FlashlightLoadState.LoadingError;
                }

                Debug.Log("Flashlight Id:" + chipId, LogType.Info);

                // get number of events in p3 device
                if (!engine_.p3_eventcount(out int firstfree, out int bank)) {
                    Debug.Log("Couldn't get flashlight event count", LogType.Error);
                    return FlashlightLoadState.LoadingError;
                }

                if (firstfree == 0) {
                    Debug.Log("No data to be parsed in flashlight", LogType.Warning);
                    return FlashlightLoadState.EmptySet;
                }

                engine_.p3_reconnect();
                Application.DoEvents();

                engine_.OnStart = ParserStart;
                engine_.OnChipTouch = PrintChipTouch;
                engine_.OnAntivandal = PrintAntivandal;
                engine_.OnKeypadTouch = PrintKeypadTouch;
                if (!engine_.p3_readsensor(firstfree)) {
                    Debug.Log("Couldn't read flashlight device", LogType.Error);
                    return FlashlightLoadState.LoadingError;
                }

                // beep
                engine_.p3_beep_ok();
            } catch (Exception ex) {
                Debug.Log("Exception while parsing flashlight || " + ex.ToString(), LogType.Error);
                return FlashlightLoadState.LoadingError;
            } finally {
                Debug.Log("Flashlight read finished", LogType.Info);
            }

            return FlashlightLoadState.Success;
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
            DateTime date = evs.ToDateTime();
            string log = String.Format(date.ToString("G") + " || [Keypad Code = " + keyCode.ToString() + "]");
            Debug.Log("Parsed keypad || " + log, LogType.Info);

            keypads_.Add(new KeypadData(date, keyCode));
            if (!bLastParsedChip) {
                chips_.Add(new ChipData());
            }

            bLastParsedChip = false;
        }

        private void PrintAntivandal(Tengine.evstamp evs, Tengine.antivandal avl) {
            string ret = String.Format("{0:D4}.{1:D2}.{2:D2} {3:D2}.{4:D2}.{5:D2}   [AVT:{6:D2} {7}]", evs.year, evs.month, evs.day, evs.hour, evs.minute, evs.second, avl.evtype, avl.description);
            Debug.Log("Parsed antivandal || " + ret, LogType.Info);
        }

        private void PrintChipTouch(Tengine.evstamp evs, string chipId) {
            DateTime date = evs.ToDateTime();
            string log = String.Format(date.ToString("G") + " || [Chip id = " + chipId + "]");
            Debug.Log("Parsed chip || " + log, LogType.Info);

            bool bChipEmployee = false;
            Repository.RepeatQueryWhileNoConnection<PopupNoInternetView>(null, 1000, () => {
                EChipType type = Repository.chip.CheckType(chipId);
                if (type == EChipType.Employee) {
                    employee_ = new ChipData(date, chipId);
                    bChipEmployee = true;
                }
            });

            if (bChipEmployee)
                return;

            chips_.Add(new ChipData(date, chipId));
            if (bLastParsedChip) {
                keypads_.Add(new KeypadData());
            }

            bLastParsedChip = true;
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