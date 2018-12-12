using CAD;
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
        private CLmapTB_A2_WS2 oMap;
        private CL_Connexion oCad;
        private string rq_sql;

        public CLprocessus(DataSet oDs, CLmapTB_A2_WS2 oMap, CL_Connexion oCad, string rq_sql)
        {
            this.oDs = oDs;
            this.oMap = oMap;
            this.oCad = oCad;
            this.rq_sql = rq_sql;
        }

        public DataSet ODs { get => oDs; set => oDs = value; }
        public CLmapTB_A2_WS2 OMap { get => oMap; set => oMap = value; }
        public CL_Connexion OCad { get => oCad; set => oCad = value; }
        public string Rq_sql { get => rq_sql; set => rq_sql = value; }

        public DataSet afficher(string dataTableName)
        {
            ODs.Clear();
            string req = CLmapTB_A2_WS2.selectAll();
            ODs = OCad.getRows(req, dataTableName);

            return ODs;
        }

        DataSet rechercherNom(string dataTableName, string nom)
        {
            ODs.Clear();
            string req = CLmapTB_A2_WS2.selectByName(nom);
            ODs = OCad.getRows(req, dataTableName);
            return ODs;
        }

        void deleteById(int id)
        {
            CLmapTB_A2_WS2.delete(id);
        }

        void insert_update(int id, string nom, string prenom, char methode)
        {
            ODs.Clear();
            OMap.Id = id;
            OMap.Nom = nom;
            OMap.Prénom = prenom;

            if (methode == 'i')
            {
                CLmapTB_A2_WS2.insert(OMap.Nom, OMap.Prénom);
            }
            else if (methode == 'u')
            {
                CLmapTB_A2_WS2.update(OMap.Nom, OMap.Prénom, OMap.Id);
            }
            OCad.actionRows(rq_sql);
        }
    }
}

