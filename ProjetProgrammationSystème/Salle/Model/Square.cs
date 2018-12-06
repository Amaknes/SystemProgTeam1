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
        public int idSquare {
            get => this._idSquare;
            set => this._idSquare = value;
        }

        private List<LineInterface> _LineList;
        public List<LineInterface> LineList
        {
            get => this._LineList;
            set => this._LineList = value;
        }

        private HeadWaiterInterface _HeadWaiter;
        public HeadWaiterInterface HeadWaiter
        {
            get => this._HeadWaiter;
            set => this._HeadWaiter = value;
        }

        private List<WaiterInterface> _WaiterList;
        public List<WaiterInterface> WaiterList
        {
            get => this._WaiterList;
            set => this._WaiterList = value;
        }
    }
}
