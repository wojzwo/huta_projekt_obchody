using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelWorks_Utils.Model;

namespace SteelWorks_Admin.Model
{
    public class Chip
    {
        public String chipId;
        public EChipType chipType;
        public String chipString;

        public Chip() {
            chipId = null;
            chipType = 0;
            chipString = null;
        }
    }
}
