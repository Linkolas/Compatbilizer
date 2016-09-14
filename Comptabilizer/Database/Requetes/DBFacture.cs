using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes
{
    class DBFacture : DB_Base<Facture>
    {
        public DBFacture() {
			this.Table = "facture";
		}

		#region DB_Base implementation

		/// <summary>
		/// Ajoute un objet en BDD.
		/// Si son ID est négatif, en génère un.
		/// </summary>
		/// <param name="f">Objet contenant les infos.</param>
		/// <returns>L'ID de l'objet ajouté. En cas d'erreur, retourne -1.</returns>
		public override int add(Facture f)
        {
			string requete = "";
			if (f.id >= 0) {
				requete = "INSERT INTO " + TABLE + " VALUES ("
					+ f.id + ", "
					+ f.id_payeur + ", "
					+ f.valeur + ", "
					+ f.date.Date.ToString("yyyy-MM-dd HH:mm:ss") + ", "
					+ "\"" + f.libelle + "\" "
					+ ")";
			} else {
				requete = "INSERT INTO " + TABLE + " (id_payeur, valeur_totale, ddate, libelle) VALUES ("
					+ f.id_payeur + ", "
					+ f.valeur + ", "
					+ f.date.Date.ToString("yyyy-MM-dd HH:mm:ss") + ", "
					+ "\"" + f.libelle + "\" "
					+ ")";
			}

			int id = INSERT(requete);

			return id;
		}
		
		/// <summary>
		/// Modifie un objet en BDD.
		/// </summary>
		/// <param name="id">ID de l'objet à modifier.</param>
		/// <param name="f">Objet contenant les nouvelles infos.</param>
		/// <returns>True si la modif s'est bien passée, false sinon.</returns>
		public override bool set(int id, Facture f) {
			string requete =
					  "UPDATE " + TABLE + " SET "
					+ "id = " + f.id + ", "
					+ "id_payeur = " + f.id_payeur + ", "
					+ "valeur_totale = " + f.valeur + ", "
					+ "ddate = " + f.date.Date.ToString("yyyy-MM-dd HH:mm:ss") + ", "
					+ "libelle = \"" + f.libelle + "\" "
					+ "WHERE id = " + id;

			int rows = MODIFY(requete);

			return (rows == 1);
		}
		
		protected override Facture DRowToObject(DataRow DRow) {
			Facture f = new Facture();

			f.id_payeur = (int) DRow["id_payeur"];
			f.valeur = (float) DRow["valeur_totale"];
			f.date = (DateTime) DRow["ddate"];
			f.libelle = (string) DRow["libelle"];
			f.id = (int) DRow["id"];

			return f;
		}

		public override Facture DefaultObject() {
			return new Facture();
		}
		#endregion

		#region Custom requests

		#region Participants

		/// <summary>
		/// Renvoie les validations pour une facture d'id donnée.
		/// </summary>
		/// <param name="id_facture"></param>
		/// <returns>Tableau associatif : (int) ID_Personne -> (bool) EstValidé</returns>
		public Dictionary<int, bool> Participant_getAll(int id_facture) {
			Dictionary<int, bool> vs = new Dictionary<int, bool>();
			
			string requete =
				  "SELECT * "
				+ "FROM " + PREFIX + "facture_personne "
				+ "WHERE id_facture = " + id_facture;

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count < 1) {
				return vs;
			}

			foreach (DataRow Row in dt.Rows) {
				int id = (int) Row["id_personne"];
				bool val = ((sbyte) Row["valide"] != 0);
				vs.Add(id, val);
			}

			return vs;
		}

		public bool Participant_add(int id_facture, int id_participant, bool validation = false) {
			string requete = 
					  "INSERT INTO " + (PREFIX + "facture_personne") + " VALUES ("
					+ id_facture + ", "
					+ id_participant + ", "
					+ (validation ? 1 : 0)
					+ ")";

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		public bool Participant_set(int id_facture, int id_participant, bool validation) {
			string requete =
					  "UPDATE " + (PREFIX + "facture_personne") + " SET "
					+ "valide = " + (validation ? "1" : "0") + " "
					+ "WHERE id_facture = " + id_facture + " "
					+ "AND id_personne = " + id_participant;

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		public bool Participant_del(int id_facture, int id_participant) {
			string requete =
					  "DELETE FROM " + (PREFIX + "facture_personne") + " "
					+ "WHERE id_facture = " + id_facture + " "
					+ "AND id_personne = " + id_participant;

			int rows = MODIFY(requete);

			return (rows == 1);
		}
		#endregion

		#region Categories

		/// <summary>
		/// Renvoie les catégories pour une facture d'id donnée.
		/// </summary>
		/// <param name="id_facture"></param>
		/// <returns>Liste d'ID de catégories</returns>
		public List<int> Category_getAll(int id_facture) {
			List<int> vs = new List<int>();

			string requete =
				  "SELECT * "
				+ "FROM " + PREFIX + "facture_categorie "
				+ "WHERE id_facture = " + id_facture;

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count < 1) {
				return vs;
			}

			foreach (DataRow Row in dt.Rows) {
				int id = (int) Row["id_categorie"];
				vs.Add(id);
			}

			return vs;
		}

		public bool Category_add(int id_facture, int id_category) {
			string requete =
					  "INSERT INTO " + (PREFIX + "facture_categorie") + " VALUES ("
					+ id_facture + ", "
					+ id_category
					+ ")";

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		public bool Category_del(int id_facture, int id_category) {
			string requete =
					  "DELETE FROM " + (PREFIX + "facture_categorie") + " "
					+ "WHERE id_facture = " + id_facture + " "
					+ "AND id_category = " + id_category;

			int rows = MODIFY(requete);

			return (rows == 1);
		}

        #endregion

        /// <summary>
        /// Récupère toutes les factures qu'une Personne a payée
        /// </summary>
        /// <returns>List d'objets</returns>
        public List<Facture> getAllFromPerson(Personne p)
        {
            string requete =
                  "SELECT * "
                + "FROM " + TABLE + " " 
                + "WHERE id_payeur=" + p.id + " ";

            DataTable dt = SELECT(requete);
            if (dt.Rows.Count < 1)
            {
                return new List<Facture>();
            }

            return DTableToList(dt);
        }

		/// <summary>
		/// Récupère toutes les factures d'une Personne
		/// </summary>
		/// <returns>List d'objets</returns>
		public List<Facture> getAll_Concernant(int id_person) {
			string requete =
				  "SELECT " + TABLE + ".* "
				+ "FROM " + TABLE + ", " + PREFIX + "facture_personne" + " "
				+ "WHERE " + TABLE + ".id = " + PREFIX + "facture_personne" + ".id_facture "
				+ "AND (id_payeur = " + id_person + " OR id_personne = " + id_person +")"
				+ "GROUP BY id";

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count < 1) {
				return new List<Facture>();
			}

			return DTableToList(dt);
		}

		#endregion
	}
}
