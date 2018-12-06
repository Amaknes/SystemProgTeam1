using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public class Staff : StaffInterface
    {
        private static Staff _StaffInstance;
        private int _schedule;

        public int Schedule {
            get { return _schedule; }
            set { _schedule = value; }
        }


        public static Staff StaffInstance()
        {
            if (_StaffInstance == null)
            {
                _StaffInstance = new Staff();
                return _StaffInstance;
            }
            else return _StaffInstance;
        }
    }
}