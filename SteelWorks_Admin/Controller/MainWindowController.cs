using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelWorks_Admin.View;
using SteelWorks_Utils;

namespace SteelWorks_Admin.Controller
{
    public class MainWindowController
    {
        private MainWindowView view_ = null;

        public void PrintLogToFile() {
            Debug.Log("Jakiś tam testowy log na kiju, zapisze się on tam gdzie plik .exe", LogType.Info);
        }

        public MainWindowController(MainWindowView view) {
            view_ = view;
            view_.InitController(this);
        }
    }
}
