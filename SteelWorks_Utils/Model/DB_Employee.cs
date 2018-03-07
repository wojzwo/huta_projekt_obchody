using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Employee
    {
        public string chipId;
        public string name;

        public DB_Employee() {
        }

        public DB_Employee(string chipId, string name) {
            this.chipId = chipId;
            this.name = name;
        }
    }
}
