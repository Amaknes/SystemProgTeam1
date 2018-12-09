using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class Line : LineInterface
    {
        private int _IdLine;
        public int IdLine
        {
            get => this._IdLine;
            set
            {
                if (value > 0)
                {
                    this._IdLine = value;
                }
            }
        }

        private int _NbClients;
        public int NbClients
        {
            get => this._NbClients;
            set
            {
                if (value >= 0)
                {
                    this._NbClients = value;
                }
            }
        }

        private List<TableInterface> _ListTable;
        public List<TableInterface> ListTable {
            get => this._ListTable;
            set => this._ListTable = value;
        }

        public Line(int idLine)
        {
            this.IdLine = idLine;
            this.NbClients = 0;
            this.ListTable = new List<TableInterface>();

            initialiseTable(idLine);
        }

        private void initialiseTable(int idLine)
        {
            switch (idLine)
            {
                case 1:
                    ListTable.Add(new Table(1, 10));
                    ListTable.Add(new Table(2, 8));
                    ListTable.Add(new Table(3, 2));
                    ListTable.Add(new Table(4, 6));
                    ListTable.Add(new Table(5, 4));
                    ListTable.Add(new Table(6, 4));
                    ListTable.Add(new Table(7, 4));
                    break;

                case 2:
                    ListTable.Add(new Table(8, 4));
                    ListTable.Add(new Table(9, 8));
                    ListTable.Add(new Table(10, 4));
                    ListTable.Add(new Table(11, 6));
                    ListTable.Add(new Table(12, 2));
                    ListTable.Add(new Table(13, 4));
                    ListTable.Add(new Table(14, 2));
                    ListTable.Add(new Table(15, 2));
                    ListTable.Add(new Table(16, 2));
                    ListTable.Add(new Table(17, 2));
                    break;

                case 3:
                    ListTable.Add(new Table(18, 8));
                    ListTable.Add(new Table(19, 8));
                    ListTable.Add(new Table(20, 6));
                    ListTable.Add(new Table(21, 4));
                    ListTable.Add(new Table(22, 2));
                    ListTable.Add(new Table(23, 2));
                    ListTable.Add(new Table(24, 2));
                    ListTable.Add(new Table(25, 6));
                    break;

                default:
                    ListTable.Add(new Table(26, 8));
                    ListTable.Add(new Table(27, 10));
                    ListTable.Add(new Table(28, 2));
                    ListTable.Add(new Table(29, 6));
                    ListTable.Add(new Table(30, 4));
                    ListTable.Add(new Table(31, 4));
                    ListTable.Add(new Table(32, 4));
                    break;
            }
        }
    }
}
