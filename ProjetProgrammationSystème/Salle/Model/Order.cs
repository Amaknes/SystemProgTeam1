using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class Order : OrderInterface
    {
        private int _IdTable;
        public int IdTable
        {
            get => this._IdTable;
            set
            {
                if (value >= 0)
                {
                    this._IdTable = value;
                }
            }
        }

        private List<int> _ListEntries;
        public List<int> ListEntries
        {
            get => this._ListEntries;
            set => this._ListEntries = value;
        }

        private List<int> _ListPlats;
        public List<int> ListPlats
        {
            get => this._ListPlats;
            set => this._ListPlats = value;
        }

        private List<int> _ListDesserts;
        public List<int> ListDesserts
        {
            get => this._ListDesserts;
            set => this._ListDesserts = value;
        }


        public Order(int IdTable)
        {
            this.IdTable = IdTable;
            this.ListDesserts = new List<int>();
            this.ListPlats = new List<int>();
            this.ListEntries = new List<int>();
        }
    }
}
