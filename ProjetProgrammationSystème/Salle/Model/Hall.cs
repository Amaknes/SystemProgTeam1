using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    class Hall
    {
        private static Hall HallInstance;

        private Hall()
        {

        }

        public Hall hallInstance()
        {
            if(HallInstance == null)
            {
                HallInstance = new Hall();
            }

            return HallInstance;
        }
    }
}
