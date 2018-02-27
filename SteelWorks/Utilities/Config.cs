using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks.Utilities
{
    public static class Config
    {

        static Config() {
            string configPath = "Config.works";
            using (FileStream stream = new FileStream(configPath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
