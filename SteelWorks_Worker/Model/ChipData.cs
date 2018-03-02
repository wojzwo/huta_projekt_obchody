using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Worker.Model
{
    public class ChipData
    {
        public DateTime date;
        public string id;
        public bool bIsValid;

        public ChipData() {
            bIsValid = false;
        }

        public ChipData(DateTime date, string id) {
            this.date = date;
            this.id = id;
            bIsValid = true;
        }
    }
}
