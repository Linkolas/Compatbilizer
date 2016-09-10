using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes {
    abstract class DB_Base<T> {

        #region Abstract methods
        public abstract T get(int id);
        public abstract List<T> getAll();
        public abstract bool set(int id, T obj);
        public abstract int add(T obj);
        public abstract bool del(int id);
        #endregion

        #region Global Settings
        /// <summary>Chaîne de connexion à la base SQL.</summary>
        private string sql_connectstring = @"server=localhost; uid=root; pwd=; database=compta; port=3306";
        
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

        #region Shared methods
        /// <summary>
        /// Exécute une requête de sélection (SELECT).
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

                if (connection.State == ConnectionState.Open) {
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();

                    dt = new DataTable();
                    dt.Load(reader);
                }

            } catch (MySqlException e) {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Erreur SQL no " + e.Number.ToString());

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
        /// Exécute une requête de sélection (SELECT).
        /// </summary>
        /// <param name="cmd">Commande à éxécuter.</param>
        /// <returns>DataTable contenant les résultats (vide en cas d'erreur).</returns>
        protected DataTable SELECT(string cmd) {
            MySqlCommand commande = new MySqlCommand(cmd);
            return SELECT(commande);
        }

        /// <summary>
        /// Exécute une requête de modification.
        /// </summary>
        /// <param name="cmd">Commande à éxécuter.</param>
        /// <returns>Le nombre de lignes affectées.</returns>
        protected int MODIFY(MySqlCommand cmd) {
            MySqlConnection connection = null;
            int retour = -1;

            try {
                connection = Connection;
                connection.Open();

                if (connection.State == ConnectionState.Open) {
                    cmd.Connection = connection;
                    retour = cmd.ExecuteNonQuery();
                }

            } catch (MySqlException e) {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Erreur SQL no " + e.Number.ToString());

            } finally {
                if (connection != null) {
                    connection.Close();
                }
            }

            return retour;
        }

        /// <summary>
        /// Exécute une requête de modification.
        /// </summary>
        /// <param name="cmd">Commande à éxécuter.</param>
        /// <returns>Le nombre de lignes affectées.</returns>
        protected int MODIFY(string cmd) {
            MySqlCommand commande = new MySqlCommand(cmd);
            return MODIFY(commande);
        }

		/// <summary>
		/// Exécute une requête d'insertion.
		/// </summary>
		/// <param name="cmd">Commande à éxécuter.</param>
		/// <returns>L'ID de l'insertion.</returns>
		protected int INSERT(MySqlCommand cmd) {
			MySqlConnection connection = null;
			int id = -1;

			try {
				connection = Connection;
				connection.Open();

				if (connection.State == ConnectionState.Open) {
					cmd.Connection = connection;
					cmd.ExecuteNonQuery();
					id = (int) cmd.LastInsertedId;
				}

			} catch (MySqlException e) {
				Debug.WriteLine(e.Message);
				Debug.WriteLine("Erreur SQL no " + e.Number.ToString());

			} finally {
				if (connection != null) {
					connection.Close();
				}
			}

			return id;
		}
		
		/// <summary>
		/// Exécute une requête d'insertion.
		/// </summary>
		/// <param name="cmd">Commande à éxécuter.</param>
		/// <returns>L'ID de l'insertion.</returns>
		protected int INSERT(string cmd) {
			MySqlCommand commande = new MySqlCommand(cmd);
			return INSERT(commande);
		}
        #endregion
    }
}
