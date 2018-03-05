using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomst;
using SteelWorks_Utils;
using TomstForms;
using System.Windows.Forms;
using static Tomst.Tengine;

namespace SteelWorks_Utils.Controller
{
	public class ChipController
	{

		private Tengine engine_ = null;

		public ChipController()
		{
			engine_ = new Tengine();
		}

		~ChipController(){
			engine_.closedev();
		}

		public bool OpenAdapter()
		{
			engine_.closedev();
			if (!engine_.opendev())
			{
				Debug.Log("Cannot open TMD (adapter)", LogType.Error);
				return false;
			}

			if (!engine_.adapternumber(out string adapter))
			{
				Debug.Log("Cannot read adapter number", LogType.Error);
				return false;
			}

			Debug.Log("Opened adapter number = " + adapter, LogType.Info);
			return true;
		}

		public bool ReadReader(Form form, TOnStartParsing onStartFunc, TOnChipTouch onChipFunc, TOnKeypadTouch onKeypadFunc, TOnAntivandal onVandalFunc)
		{
			try
			{
				if (!GenerateSplash(form))
				{
					return false;
				}

				// get number of events in p3 device
				if (!engine_.p3_eventcount(out int firstfree, out int bank))
				{
					Debug.Log("Couldn't get flashlight event count", LogType.Error);
					return false;
				}

				if (firstfree == 0)
				{
					Debug.Log("No data to be parsed in flashlight", LogType.Warning);
					engine_.p3_beep_ok();
					return false;
				}
				engine_.p3_reconnect();
				Application.DoEvents();

				engine_.OnStart = onStartFunc;
				engine_.OnChipTouch = onChipFunc;
				engine_.OnKeypadTouch = onKeypadFunc;
				engine_.OnAntivandal = onVandalFunc;


				if (!engine_.p3_readsensor(firstfree))
				{
					Debug.Log("Couldn't read flashlight device", LogType.Error);
					return false;
				}

				// beep
				engine_.p3_beep_ok();
			}
			catch (Exception ex)
			{
				Debug.Log("Exception while parsing flashlight || " + ex.ToString(), LogType.Error);
				return false;
			}
			finally
			{
				Debug.Log("Flashlight read finished", LogType.Info);
			}
			return true;
		}


		public bool EraseReader(Form form)
		{
			try
			{
				if (!GenerateSplash(form))
				{
					return false;
				}

				// set system time 
				engine_.p3_settime();
				// and delete sensor
				bool success = engine_.p3_deletesensor();
				if (success)
				{
					engine_.p3_beep_ok();
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Error while erasing data\n" + ex.ToString(), LogType.TomstError);
			}

			return false;
		}

		public bool GenerateSplash(Form form)
		{
			Splash sp = new Splash();
			sp.engine = engine_;
			if (sp.ShowDialog(form) == DialogResult.OK)
				Debug.Log("Flashlight Id:" + sp.ChipID, LogType.Info);
			if (!sp.IsP3)
				{
					sp.Dispose();
					return false;
				}
			sp.Dispose();
			return true;
		}
	}
}
