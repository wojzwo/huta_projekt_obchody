using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Place
    {
        public string chipId;
        public string name;

        public DB_Place() {
        }

        public DB_Place(string chipId, string name) {
            this.chipId = chipId;
            this.name = name;
        }
    }
}
