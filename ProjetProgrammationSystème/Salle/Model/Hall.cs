using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    class Hall : HallInterface
    {
        private static Hall HallInstance;

        private List<SquareInterface> _SquareList;
        public List<SquareInterface> SquareList
        {

            get { return this._SquareList; }

            set { this._SquareList = value; }

        }


        private Hall()
        {
            List<SquareInterface> newSquareList = new List<SquareInterface>();

            newSquareList.Add((SquareInterface)new Square());
            newSquareList.Add((SquareInterface)new Square());

            SquareList  = newSquareList;
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
