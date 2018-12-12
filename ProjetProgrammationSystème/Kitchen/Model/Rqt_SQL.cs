using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Rqt_SQL
    {
        private string rq_sql;
        private int id;
        private string nom;
        private string prénom;

        public string Rq_sql { get => rq_sql; set => rq_sql = value; }
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prénom { get => prénom; set => prénom = value; }

        public static string ListeEtapeCommande()
        {
            return "SELECT * FROM dbo.Preparation INNER JOIN dbo.CommandLine ON dbo.Preparation.TypePreparation = dbo.CommandLine.TypePreparation";
        }

        public static string LieuDeStockageIngredient()
        {
            return "SELECT IDStock, IDIngredient FROM dbo.StockKitchen";
        }

        /*public static string select(int param)
        {
            return "SELECT IDTabel, IDPreparation, TypePreparation FROM dbo.Preparation, dbo.TabelRest";
        }

        public static string insert(string nom, string prenom)
        {
            return "INSERT INTO dbo.TB_A2_WS2 VALUES ('" + nom + ", " + prenom + "')";
        }

        public static string update(string nom, string prenom, int id)
        {
            return "UPDATE dbo.TB_A2_WS2 SET nom = " + nom + ", prenom = " + prenom + ", WHERE id = " + id;
        }*/
    }
}
