using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Utils.Model
{
    public class DB_Employee
    {
        /// <summary> This id is used for faster database lookup, THIS IS NOT CHIP ID </summary>
        public int id = -1;
        public string name;
        public string chipId;

		public DB_Employee() {  }

		public DB_Employee(string chipIDN, string nameN)
		{
			this.chipId = chipIDN;
			this.name = nameN;
		}
    }
}
