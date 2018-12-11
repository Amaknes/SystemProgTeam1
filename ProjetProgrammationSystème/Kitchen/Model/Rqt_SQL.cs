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

        public static string selectIngredients(int Param)
        {
            return "SELECT * FROM dbo.Ingrient WHERE id= " + Param;
        }

        public static string selectByName(string param)
        {
            return "SELECT * FROM dbo.TB_A2_WS2 WHERE nom =" + param;
        }

        public static string delete(int param)
        {
            return "DELETE FROM dbo.TB_A2_WS2 WHERE id= " + param;
        }

        public static string insert(string nom, string prenom)
        {
            return "INSERT INTO dbo.TB_A2_WS2 VALUES ('" + nom + ", " + prenom + "')";
        }

        public static string update(string nom, string prenom, int id)
        {
            return "UPDATE dbo.TB_A2_WS2 SET nom = " + nom + ", prenom = " + prenom + ", WHERE id = " + id;
        }
    }
}
