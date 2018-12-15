using Salle.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class Hall : HallInterface
    {
        private static HallInterface HallInstance;

        private List<SquareInterface> _SquareList;
        public List<SquareInterface> SquareList
        {

            get
            {
                return this._SquareList;
            }

            set
            {
                this._SquareList = value;
            }

        }


        private Hall()
        {
            List<SquareInterface> newSquareList = new List<SquareInterface>();


            newSquareList.Add((SquareInterface)new Square(1));
            newSquareList.Add((SquareInterface)new Square(2));

            MaîtreHôtel MHotel = MaîtreHôtel.maîtreHôtelInstance();
            SquareList = newSquareList;
            MHotel.ListSquare = (List<SquareInterface>)newSquareList;
        }

        public static HallInterface hallInstance()
        {
            if (HallInstance == null)
            {
                HallInstance = (HallInterface)new Hall();
            }

            return HallInstance;
        }

        public SquareInterface FindSquareByTableId(int IdTable)
        {
            SquareInterface res = SquareList[0];
            if (IdTable >= 17)
            {
                res = SquareList[1];
            }

            return res;
        }

        public TableInterface FindTableById(int IdTable)
        {
            TableInterface res = null;
            if (IdTable < 7)
            {
                res = VerifTableById(0, 0, IdTable);
            }
            else if (IdTable < 17)
            {
                res = VerifTableById(0, 1, IdTable);
            }
            else if (IdTable < 25)
            {
                res = VerifTableById(1, 0, IdTable);
            }
            else if (IdTable < 32)
            {
                res = VerifTableById(1, 1, IdTable);
            }

            return res;
        }

        public TableInterface VerifTableById(int idSquare, int idLine, int idTable)
        {
            TableInterface res = null;
            int i = 0;
            while (i < SquareList[idSquare].LineList[idLine].ListTable.Count)
            {
                if (idTable == SquareList[idSquare].LineList[idLine].ListTable[i].IdTable)
                {
                    res = SquareList[idSquare].LineList[idLine].ListTable[i];
                }
                i++;
            }

            return res;
        }
    }
}
