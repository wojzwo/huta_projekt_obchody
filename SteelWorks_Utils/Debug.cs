using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils
{
    public enum LogType
    {
        Debug,
        Info,
        Warning,
        Error,
        TomstError
    }

    public static class Debug
    {
        public static void Log(string message, LogType type = LogType.Debug) {
            try {
                using (FileStream stream = new FileStream(FILE_PATH, FileMode.Append, FileAccess.Write, FileShare.None)) {
                    using (StreamWriter writer = new StreamWriter(stream)) {
                        writer.WriteLine("<" + type.ToString() + "> [" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "] " + message);
                    }
                }
            } catch (Exception ex) {

            }
        }

        static Debug() {
            using (FileStream stream = File.Create(FILE_PATH)) {

            }
        }

        private const string FILE_PATH = "Log.hlog";
    }
}
