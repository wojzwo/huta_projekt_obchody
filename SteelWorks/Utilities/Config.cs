using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks.Utilities
{
    public static class Config
    {
        public static string databaseServerIp;
        public static string databaseName;
        public static string databaseUsername;
        public static string databasePassword;

        static Config() {
            string configPath = "Config.works";
            using (FileStream stream = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    databaseServerIp = GetNextValue(reader);
                    databaseName = GetNextValue(reader);
                    databaseUsername = GetNextValue(reader);
                    databasePassword = GetNextValue(reader);
                }
            }
        }

        private static string GetNextValue(StreamReader reader) {
            string line = reader.ReadLine();
            string[] parts = line.Split('=');
            return parts[1];
        }
    }
}
