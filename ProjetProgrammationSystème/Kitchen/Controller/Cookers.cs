using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public class Cookers : SpecializedChefs
    {
        public override string Type()
        {
            return "Cookers";
        }
    }
}
