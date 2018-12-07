using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class Table : TableInterface
    {
        public int IdTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NbPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ClientsInterface Clients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Table(int idTable, int nbPlace)
        {
            this.IdTable = idTable;
            this.NbPlace = nbPlace;
            this.Clients = null;
        }
    }
}
