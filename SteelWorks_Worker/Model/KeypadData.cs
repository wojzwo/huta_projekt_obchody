using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelWorks_Worker.Model
{
    public class KeypadData
    {
        public DateTime date;
        public int value;
        public bool bIsValid;

        public KeypadData() {
            bIsValid = false;
        }

        public KeypadData(DateTime date, int value) {
            this.date = date;
            this.value = value;
            bIsValid = true;
        }
    }
}
