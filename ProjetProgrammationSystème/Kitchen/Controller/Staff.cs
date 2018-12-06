using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class Staff // : StaffInterface
    {
        private StaffInterface StaffInstance;
        /*private StaffInterface _Schedule;
        public StaffInterface Schedule;


        voir screen tanguy
    */

        public StaffInterface staffInstance()
        {
            if(StaffInstance == null)
            {
                StaffInstance = (StaffInterface) new Staff();
            }
            return this.StaffInstance;

        }

        
        private Staff()
        {
            Schedule = 0;
        }
        

    }
}
