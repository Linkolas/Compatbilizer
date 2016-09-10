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

        public override bool del(int id) {
			string requete =
				  "DELETE FROM " + TABLE + " "
				+ "WHERE id = " + id;

			int rows = MODIFY(requete);

			return (rows == 1);
		}

        public override Magouille get(int id) {
			Magouille p = new Magouille() { id = -1 };

			string requete =
				  "SELECT * "
				+ "FROM " + TABLE + " "
				+ "WHERE id = " + id;

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count != 1) {
				return p;
			}

			p.id_facture = (int) dt.Rows[0]["id_facture"];
			p.id_beneficiaire = (int) dt.Rows[0]["id_beneficiaire"];
			p.valeur = (float) dt.Rows[0]["valeur"];
			p.libelle = (string) dt.Rows[0]["libelle"];
			p.id = (int) dt.Rows[0]["id"];

			return p;
		}

        public override List<Magouille> getAll() {
			List<Magouille> ps = new List<Magouille>();

			string requete =
				  "SELECT * "
				+ "FROM " + TABLE + " ";

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
