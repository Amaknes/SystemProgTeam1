using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class Table : TableInterface
    {
        private int _IdTable;
        public int IdTable {
            get => this._IdTable;
            set
            {
                if (value > 0) {
                    this._IdTable = value;
                }
            }
        }

        private int _NbPlace;
        public int NbPlace {
            get => this._NbPlace;
            set
            {
                if (value > 0)
                {
                    this._NbPlace = value;
                }
            }
        }

        private ClientsInterface _Clients;
        public ClientsInterface Clients {
            get => this._Clients;
            set => this._Clients = value;
        }

        public Table(int idTable, int nbPlace)
        {
            IdTable = idTable;
            NbPlace = nbPlace;
            Clients = null;
        }
    }
}
