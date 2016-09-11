using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Data;
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
					+ DateTimeToTimestamp(f.date) + ", "
					+ "\"" + f.libelle + "\" "
					+ ")";
			} else {
				requete = "INSERT INTO " + TABLE + " (id_payeur, valeur_totale, ddate, libelle) VALUES ("
					+ f.id_payeur + ", "
					+ f.valeur + ", "
					+ DateTimeToTimestamp(f.date) + ", "
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
					+ "ddate = " + DateTimeToTimestamp(f.date) + ", "
					+ "libelle = \"" + f.libelle + "\" "
					+ "WHERE id = " + id;

			int rows = MODIFY(requete);

			return (rows == 1);
		}
		
		protected override Facture DRowToObject(DataRow DRow) {
			Facture f = new Facture();

			f.id_payeur = (int) DRow["id_payeur"];
			f.valeur = (float) DRow["valeur_totale"];
			f.date = TimestampToDateTime((double) DRow["ddate"]);
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
					  "UPDATE " + TABLE + " SET "
					+ "valide = " + (validation ? "1" : "0") + " "
					+ "WHERE id_facture = " + id_facture + " "
					+ "AND id_personne = " + id_participant;

			int rows = MODIFY(requete);

			return (rows == 1);
		}
		#endregion

		#endregion

		#region Utility functions
		private long DateTimeToTimestamp(DateTime dt) {
			long epoch = (dt.Ticks - 621355968000000000) / 10000000;
			return epoch;
		}

		private DateTime TimestampToDateTime(double timestamp) {
			DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
			return dtDateTime;
		}
		#endregion
	}
}
