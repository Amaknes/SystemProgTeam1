using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class SpecializedChefs
    {
            public SpecializedChefsInterface Strategy { get; set; }

            public void CallType()
            {
                Console.WriteLine(Strategy.Type());
            }
        
    }
}
