using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class Staff : StaffInterface
    {
        private static Staff _StaffInstance;
        private long _schedule;

        public long Schedule
        {
            get { return _schedule; }
            set { _schedule = value; }
        }


        public static Staff StaffInstance()
        {
            if (_StaffInstance == null)
            {
                _StaffInstance = new Staff();
            }
            return _StaffInstance;
        }

        private Staff()
        { 
            Schedule = DateTime.Now.Ticks;
        }
    }
}
