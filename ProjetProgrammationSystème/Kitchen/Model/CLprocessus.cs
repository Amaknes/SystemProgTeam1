using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class CLprocessus
    {
        private DataSet oDs;
        private Rqt_SQL oMap;
        private CAD oCad;
        private string rq_sql;

        public CLprocessus(DataSet oDs, Rqt_SQL oMap, CAD oCad, string rq_sql)
        {
            this.oDs = oDs;
            this.oMap = oMap;
            this.oCad = oCad;
            this.rq_sql = rq_sql;
        }

        public DataSet ODs { get => oDs; set => oDs = value; }
        public Rqt_SQL OMap { get => oMap; set => oMap = value; }
        public CAD OCad { get => oCad; set => oCad = value; }
        public string Rq_sql { get => rq_sql; set => rq_sql = value; }

        public DataSet GetListCommand(string dataTableName, int idCommand)
        {
            ODs.Clear();

            string req = Rqt_SQL.ListeEtapeCommande(idCommand);
            ODs = OCad.getRows(req, dataTableName);

            return ODs;
        }

        public DataSet GetLieuxIngredients(string dataTableName, int idCommand)
        {
            ODs.Clear();

            string req = Rqt_SQL.LieuDeStockageIngredient(idCommand);
            ODs = OCad.getRows(req, dataTableName);

            return ODs;
        }
    }
}