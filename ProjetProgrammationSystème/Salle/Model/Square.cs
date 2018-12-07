using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controller;

namespace Salle.Model
{
    public class Square : SquareInterface
    {
        private int _idSquare;
        public int IdSquare {
            get => this._idSquare;
            set => this._idSquare = value;
        }

        private List<LineInterface> _LineList;
        public List<LineInterface> LineList
        {
            get => this._LineList;
            set => this._LineList = value;
        }

        private HeadWaiterInterface _headWaiter;
        public HeadWaiterInterface headWaiter
        {
            get => this._headWaiter;
            set => this._headWaiter = value;
        }

        private List<WaiterInterface> _WaiterList;
        public List<WaiterInterface> WaiterList
        {
            get => this._WaiterList;
            set => this._WaiterList = value;
        }


        public Square(int idSquare)
        {
            this.IdSquare = idSquare;
            if(idSquare == 1)
            {
                this.headWaiter = new HeadWaiter(1);
                this.LineList.Add(new Line(1));
                this.LineList.Add(new Line(2));
                this.WaiterList.Add((WaiterInterface)new Waiter(1));
                this.WaiterList.Add((WaiterInterface)new Waiter(2));
            }
            else
            {
                this.headWaiter = new HeadWaiter(2);
                this.LineList.Add(new Line(3));
                this.LineList.Add(new Line(4));
                this.WaiterList.Add((WaiterInterface)new Waiter(3));
                this.WaiterList.Add((WaiterInterface)new Waiter(4));
            }
        }
    }
}
