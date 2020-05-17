using System;
using Microsoft.Win32.TaskScheduler;

namespace SteelWorks_Scheduler
{
	class Program
	{
		static void Main(string[] args)
		{

            DateTime start_of_day = new DateTime(2020, 5, 1);
			String serverPath = AppDomain.CurrentDomain.BaseDirectory + "\\Server\\SteelWorks_Server.exe";

			String finishDayName = "SteelWorks_Inspection Finish Day";
			ExecAction finishDayEA = new ExecAction(serverPath, null, AppDomain.CurrentDomain.BaseDirectory + "\\Server\\");
			DateTime finishDayTime = new DateTime(2020, 5, 1, 6, 00, 0);

			String Shift1Name = "SteelWorks_Inspection Finish Shift 1";
			ExecAction Shift1EA = new ExecAction(serverPath, null, AppDomain.CurrentDomain.BaseDirectory + "\\Server\\");
			DateTime Shift1Time = new DateTime(2020, 5, 1, 14, 00, 0);

			String Shift2Name = "SteelWorks_Inspection Finish Shift 2";
			ExecAction Shift2EA = new ExecAction(serverPath, null, AppDomain.CurrentDomain.BaseDirectory + "\\Server\\");
			DateTime Shift2Time = new DateTime(2020, 5, 1, 22, 00, 0);

			String Shift3Name = "SteelWorks_Inspection Finish Shift 3";
			ExecAction Shift3EA = new ExecAction(serverPath, null, AppDomain.CurrentDomain.BaseDirectory + "\\Server\\");
			DateTime Shift3Time = new DateTime(2020, 5, 1, 5, 58, 0);


			TaskService.Instance.AddTask(finishDayName, new DailyTrigger { DaysInterval = 1, StartBoundary=finishDayTime }, finishDayEA);
			TaskService.Instance.AddTask(Shift1Name, new DailyTrigger { DaysInterval = 1, StartBoundary = Shift1Time }, Shift1EA);
			TaskService.Instance.AddTask(Shift2Name, new DailyTrigger { DaysInterval = 1, StartBoundary = Shift2Time }, Shift2EA);
			TaskService.Instance.AddTask(Shift3Name, new DailyTrigger { DaysInterval = 1, StartBoundary = Shift3Time }, Shift3EA);


			if (args.Length == 1)
			{
				if (args[0] == "-U")
				{
					TaskService.Instance.RootFolder.DeleteTask(finishDayName);
					TaskService.Instance.RootFolder.DeleteTask(Shift1Name);
					TaskService.Instance.RootFolder.DeleteTask(Shift2Name);
					TaskService.Instance.RootFolder.DeleteTask(Shift3Name);
					return;
				}
			}

		}
    }
}
