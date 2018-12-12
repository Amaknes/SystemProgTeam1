using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class CAD
    {
        private string cnx;
        private string rq_sql;
        private SqlDataAdapter dataAdapter;
        private SqlConnection sqlconnexion;
        private SqlCommand sqlcommand;
        private DataSet Dataset;

        public CAD()
        {
            this.cnx = "Data Source=DESKTOP-3L9CEES;Initial Catalog=ProjetProgSystem;Integrated Security=True";
            this.rq_sql = null;
            this.dataAdapter = new SqlDataAdapter();
            this.sqlconnexion = new SqlConnection(cnx);
            this.sqlcommand = new SqlCommand();
            Dataset = new DataSet();
        }

        public string Cnx { get => cnx; set => cnx = value; }
        public string Rq_sql { get => rq_sql; set => rq_sql = value; }
        public SqlDataAdapter DataAdapter { get => dataAdapter; set => dataAdapter = value; }
        public SqlConnection Sqlconnexion { get => sqlconnexion; set => sqlconnexion = value; }
        public SqlCommand Sqlcommand { get => sqlcommand; set => sqlcommand = value; }
        public DataSet Dataset1 { get => Dataset; set => Dataset = value; }

        public void actionRows(string rq_sql)
        {


            // Requête SQL

            Sqlcommand.Connection = Sqlconnexion; // Connexion instanciée auparavant
            Sqlcommand.CommandText = rq_sql;

            SqlDataAdapter adapter = DataAdapter; // Permet de lire les données
            DataSet data = Dataset; // Contiendra les données

            try
            {
                Sqlconnexion.Open(); // Ouverture de la connexion
                Sqlcommand.ExecuteNonQuery(); // Récupère les données de la table donnée
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                Sqlconnexion.Close();
            }
        }

        public DataSet getRows(string rq_sql, string dataTableName)
        {
            Sqlconnexion.ConnectionString = @"Data Source = Localhost\SQLEXPRESS";
            Sqlconnexion.ConnectionString += @"Initial Catalog = Northwind; Integrated Security =SSPI";

            Sqlcommand.Connection = Sqlconnexion;
            Sqlcommand.CommandText = rq_sql;



            try
            {
                Sqlconnexion.Open();
                DataAdapter.Fill(Dataset1, dataTableName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Sqlconnexion.Close();
            }
            return Dataset1;
        }
    }
}