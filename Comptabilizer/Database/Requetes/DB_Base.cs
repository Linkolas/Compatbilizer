using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes {
    abstract class DB_Base {

        #region Global Settings
        /// <summary>Chaîne de connexion à la base SQL.</summary>
        private string sql_connectstring = @"server=localhost;user id=root;persistsecurityinfo=True;database=compta";
        
        /// <summary>Préfixe des tables en BDD</summary>
        private string prefix = "compta_";

        /// <summary>Récupère une nouvelle connexion MySQL.</summary>
        protected MySqlConnection Connection {
            get { return new MySqlConnection(sql_connectstring); }
        }

        /// <summary>Préfixe des tables en BDD</summary>
        protected string PREFIX {
            get { return prefix; }
        }

        #endregion

        #region Table Settings
        /// <summary>Don't use this value. Use TABLE instead.</summary>
        protected string Table = "";

        /// <summary>Récupère le nom de la table en cours.</summary>
        protected string TABLE {
            get { return PREFIX + Table; }
        }
        #endregion

        /// <summary>
        /// Exécute une requête (pensé pour des requêtes de type SELECT).
        /// </summary>
        /// <param name="cmd">Commande à éxécuter.</param>
        /// <returns>DataTable contenant les résultats (vide en cas d'erreur).</returns>
        protected DataTable SELECT(MySqlCommand cmd) {
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();

            try {
                connection = Connection;
                connection.Open();
                
                reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
            } catch {

            } finally {
                if (reader != null) {
                    reader.Close();
                }

                if (connection != null) {
                    connection.Close();
                }
            }

            return dt;
        }

        /// <summary>
        /// Exécute une requête (pensé pour des requêtes de type SELECT).
        /// </summary>
        /// <param name="cmd">Commande à éxécuter.</param>
        /// <returns>DataTable contenant les résultats (vide en cas d'erreur).</returns>
        protected DataTable SELECT(string cmd) {
            MySqlCommand commande = new MySqlCommand(cmd);
            return SELECT(commande);
        }
    }
}
