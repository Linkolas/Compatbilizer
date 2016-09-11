using Comptabilizer.Database.Objets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes {
    class DBPersonne : DB_Base<Personne> {
		private const string PASSWD_NOT_SET = "NOT_SET";

		public DBPersonne() {
			this.Table = "personne";
		}

		#region DB_Base implementation

        /// <summary>
        /// Modifie un objet en BDD.
        /// </summary>
        /// <param name="id">ID de l'objet à modifier.</param>
        /// <param name="p">Objet contenant les nouvelles infos.</param>
        /// <returns>True si la modif s'est bien passée, false sinon.</returns>
        public override bool set(int id, Personne p) {
			string requete = 
					  "UPDATE " + TABLE + " SET "
					+ "id = " + p.id.ToString() + ", "
					+ "nom = \"" + p.nom + "\", "
					+ "avatar = \"" + p.avatar + "\", "
					+ "pseudo = \"" + p.pseudo + "\", "
					+ "habituel = " + (p.habituel ? "1" : "0") + " "
					+ "WHERE id = " + id.ToString();

			int rows = MODIFY(requete);

			return (rows == 1);
        }

        /// <summary>
        /// Ajoute un objet en BDD.
        /// Si son ID est négatif, en génère un.
        /// </summary>
        /// <param name="p">Objet contenant les infos.</param>
        /// <returns>L'ID de l'objet ajouté. En cas d'erreur, retourne -1.</returns>
        public override int add(Personne p) {
			string requete = "";
            if(p.id >= 0) {
				requete = "INSERT INTO " + TABLE + " VALUES ("
					+ p.id.ToString() + ", "
					+ "\"" + p.nom + "\", "
					+ "\"" + p.avatar + "\", "
					+ "\"" + p.pseudo + "\", "
					+ "\"" + Saltyze(PASSWD_NOT_SET) + "\", "
					+  (p.habituel ? "1" : "0")
					+ ")" ;
            } else {
				requete = "INSERT INTO " + TABLE + "(nom, avatar, pseudo, password, habituel) VALUES ("
					+ "\"" + p.nom + "\", "
					+ "\"" + p.avatar + "\", "
					+ "\"" + p.pseudo + "\", "
					+ "\"" + Saltyze(PASSWD_NOT_SET) + "\", "
					+ (p.habituel ? "1" : "0")
					+ ")";
			}

			int id = INSERT(requete);

            return id;
        }

		protected override Personne DRowToObject(DataRow DRow) {
			Personne p = new Personne();
			p.nom = (string) DRow["nom"];
			p.pseudo = (string) DRow["pseudo"];
			p.avatar = (string) DRow["avatar"];
			p.habituel = ((sbyte) DRow["habituel"] != 0);
			p.id = (int) DRow["id"];

			return p;
		}
		
		public override Personne DefaultObject() {
			return new Personne();
		}

		#endregion

		#region Custom requests
		/// <summary>
		/// Change le mot de passe d'un utilisateur.
		/// </summary>
		/// <param name="id">ID de la personne concernée.</param>
		/// <param name="password">Nouveau mot de passe.</param>
		/// <returns>True/False</returns>
		public bool setPassword(int id, string password) {
			string requete =
					  "UPDATE " + TABLE + " SET "
					+ "password = \"" + Saltyze(password) + "\" "
					+ "WHERE id = " + id.ToString();

			int rows = MODIFY(requete);

			return (rows == 1);
		}

		/// <summary>
		/// Vérifie si une personne est enregistrée.
		/// </summary>
		/// <param name="pseudo">Pseudo saisi</param>
		/// <param name="password">Mot de passe saisi</param>
		/// <returns>Objet Personne contenant ses informations. En cas d'erreur, son ID est négatif.</returns>
		public new Personne Connection(string pseudo, string password) {
			Personne p = new Personne() { id = -1 };

			string requete =
				  "SELECT * "
				+ "FROM " + TABLE + " "
				+ "WHERE pseudo = \"" + pseudo + "\" "
				+ "AND password = \"" + Saltyze(password) + "\"";

			DataTable dt = SELECT(requete);
			if (dt.Rows.Count != 1) {
				return p;
			}

			p.nom = (string) dt.Rows[0]["nom"];
			p.pseudo = (string) dt.Rows[0]["pseudo"];
			p.avatar = (string) dt.Rows[0]["avatar"];
			p.habituel = ((sbyte) dt.Rows[0]["habituel"] != 0);
			p.id = (int) dt.Rows[0]["id"];

			return p;
		}
		#endregion

		#region Utility functions
		/// <summary>
		/// Encrypte une chaîne de caractères.
		/// </summary>
		/// <param name="ToSalt">Chaîne à encrypter.</param>
		/// <returns>Chaîne encryptée.</returns>
		private string Saltyze(string ToSalt) {
			HashAlgorithm algorithm = new SHA256Managed();
			byte[] plainText = Encoding.UTF8.GetBytes(ToSalt);
			byte[] salt = Encoding.UTF8.GetBytes("Michel Forever Tonight");

			byte[] plainTextWithSaltBytes =
				new byte[plainText.Length + salt.Length];

			for (int i = 0; i < plainText.Length; i++) {
				plainTextWithSaltBytes[i] = plainText[i];
			}

			for (int i = 0; i < salt.Length; i++) {
				plainTextWithSaltBytes[plainText.Length + i] = salt[i];
			}

			byte[] salted = algorithm.ComputeHash(plainTextWithSaltBytes);
			string salted_str = Convert.ToBase64String(salted);
			
			return salted_str;
		}
		#endregion
	}
}
