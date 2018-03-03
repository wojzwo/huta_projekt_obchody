using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Chip
    {
        public string chipId;
        public bool bIsEmployee;

        public string Serialize() {
            string ret = "";
            ret += chipId + "#";
            ret += bIsEmployee.ToString();
            return ret;
        }

        public static DB_Chip Deserialize(string data) {
            DB_Chip c = new DB_Chip();
            string[] parts = data.Split('#');
            c.chipId = parts[0];
            c.bIsEmployee = Boolean.Parse(parts[1]);
            return c;
        }
    }
}
