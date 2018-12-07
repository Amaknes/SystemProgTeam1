using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class MaîtreHôtel : MaîtreHôtelInterface
    {
        
        private static MaîtreHôtel MaîtreHôtelInstance;

        private int[] _ListHeadWaiter;
        public int[] ListHeadWaiter {
            get => this._ListHeadWaiter;
            set => this._ListHeadWaiter = value;
        }

        public void AssignTable(int IdTable)
        {
            throw new NotImplementedException();
        }

        public void CallHeadWaiter(int IdHeadWaiter)
        {
            throw new NotImplementedException();
        }

        public void getHeadWaiterDisposable(int[] getListeHeadWaiter)
        {
            throw new NotImplementedException();
        }

        public HeadWaiterInterface GetHeadWaiterDisposable()
        {
            throw new NotImplementedException();
        }

        public static MaîtreHôtel maîtreHôtelInstance()
        {

            if (MaîtreHôtelInstance == null)
            {
                MaîtreHôtelInstance = new MaîtreHôtel();
            }

            return MaîtreHôtelInstance;
        } 


    }
}
