using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Comptabilizer.Database.Requetes {
	class DBCategories : DB_Base<Categorie> {
		
		public DBCategories() {
			this.Table = "categorie";
		}
		
		public override int add(Categorie obj) {

			string requete = "";
			if (obj.id >= 0) {
				requete = "INSERT INTO " + TABLE + " VALUES ("
					+ obj.id + ", "
					+ "\"" + obj.libelle + "\" "
					+ ")";
			} else {
				requete = "INSERT INTO " + TABLE + " (libelle) VALUES ("
					+ "\"" + obj.libelle + "\" "
					+ ")";
			}

			int id = INSERT(requete);

			return id;
		}

		public override bool set(int id, Categorie obj) {
			string requete =
					  "UPDATE " + TABLE + " SET "
					+ "id = " + obj.id + ", "
					+ "libelle = \"" + obj.libelle + "\" "
					+ "WHERE id = " + id;

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		protected override Categorie DRowToObject(DataRow DRow) {
			Categorie f = new Categorie();

			f.id = (int) DRow["id"];
			f.libelle = (string) DRow["libelle"];

			return f;
		}

		public override Categorie DefaultObject() {
			return new Categorie();
		}
	}
}
