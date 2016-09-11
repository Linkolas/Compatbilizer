using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes
{
    class DBMagouille : DB_Base<Magouille>
    {
        public DBMagouille() {
			this.Table = "magouille";
		}

		#region DB_Base implementation

		/// <summary>
		/// Ajoute un objet en BDD.
		/// Si son ID est négatif, en génère un.
		/// </summary>
		/// <param name="f">Objet contenant les infos.</param>
		/// <returns>L'ID de l'objet ajouté. En cas d'erreur, retourne -1.</returns>
		public override int add(Magouille obj) {
			string requete = "";
			if (obj.id >= 0) {
				requete = "INSERT INTO " + TABLE + " VALUES ("
					+ obj.id + ", "
					+ obj.id_facture + ", "
					+ obj.id_beneficiaire + ", "
					+ obj.valeur + ", "
					+ "\"" + obj.libelle + "\" "
					+ ")";
			} else {
				requete = "INSERT INTO " + TABLE + " (id_facture, id_beneficiaire, valeur, libelle) VALUES ("
					+ obj.id_facture + ", "
					+ obj.id_beneficiaire + ", "
					+ obj.valeur + ", "
					+ "\"" + obj.libelle + "\" "
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
		public override bool set(int id, Magouille obj) {
			string requete =
					  "UPDATE " + TABLE + " SET "
					+ "id = " + obj.id + ", "
					+ "id_facture = " + obj.id_facture + ", "
					+ "id_beneficiaire = " + obj.id_beneficiaire + ", "
					+ "valeur = " + obj.valeur + ", "
					+ "libelle = \"" + obj.libelle + "\" "
					+ "WHERE id = " + id;

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		protected override Magouille DRowToObject(DataRow DRow) {
			Magouille m = new Magouille();

			m.id = (int) 
				DRow["id"];
			m.id_beneficiaire = (int) 
				DRow["id_beneficiaire"];
			m.id_facture = (int) 
				DRow["id_facture"];
			m.valeur = (float) 
				DRow["valeur"];
			m.libelle = (string) 
				DRow["libelle"];

			return m;
		}

		public override Magouille DefaultObject() {
			return new Magouille();
		}
		#endregion

		#region Custom requests
		public List<Magouille> getForFacture(int id_facture) {

			List<Magouille> ps = new List<Magouille>();

			string requete =
				  "SELECT * "
				+ "FROM " + TABLE + " "
				+ "WHERE id_facture = " + id_facture;

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count < 1) {
				return ps;
			}

			foreach (DataRow Row in dt.Rows) {
				Magouille p = new Magouille();
				p.id_facture = (int) Row["id_facture"];
				p.id_beneficiaire = (int) Row["id_beneficiaire"];
				p.valeur = (float) Row["valeur"];
				p.libelle = (string) Row["libelle"];
				p.id = (int) Row["id"];

				ps.Add(p);
			}

			return ps;
		}
		#endregion
	}
}
