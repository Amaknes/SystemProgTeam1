using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class CLprocessus
    {
        private DataSet oDs;
        private CAD oCad;

        public CLprocessus()
        {
            this.oDs = new DataSet();
            this.oCad = new CAD();
        }

        public DataSet ODs { get => oDs; set => oDs = value; }
        public CAD OCad { get => oCad; set => oCad = value; }

        public DataSet GetListClients(string dataTableName, int IDStratégie)
        {
            ODs.Clear();

            string req = Rqt_SQL.ListeClients(IDStratégie);

            ODs = OCad.getRows(req, dataTableName);

            return ODs;
        }

        public DataSet GetListCommand(string dataTableName, int IDBooking)
        {
            ODs.Clear();

            string req = Rqt_SQL.Commandes(IDBooking);

            ODs = OCad.getRows(req, dataTableName);

            return ODs;
        }
    }
}