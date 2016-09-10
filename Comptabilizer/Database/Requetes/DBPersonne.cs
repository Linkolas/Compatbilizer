using Comptabilizer.Database.Objets;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes {
    class DBPersonne : DB_Base<Personne> {
        public DBPersonne(string table) : base(table) {}

        /// <summary>
        /// Récupère une personne de la BDD.
        /// </summary>
        /// <param name="id">ID de la personne recherchée.</param>
        /// <returns>Objet Personne contenant toutes ses infos. En cas d'erreur, en personne ayant un ID négatif.</returns>
        public override Personne get(int id) {
            Personne p = new Personne() { id = -1 };
            
            string requete =
                  "SELECT * "
                + "FROM " + TABLE + " "
                + "WHERE id = " + id + ";";
            
            DataTable dt = SELECT(requete);
            if (dt.Rows.Count != 1) {
                return p;
            }

            p.nom = (string)    dt.Rows[0]["nom"];
            p.pseudo = (string) dt.Rows[0]["pseudo"];
            p.avatar = (string) dt.Rows[0]["avatar"];
            p.habituel = ((sbyte) dt.Rows[0]["habituel"] != 0);
            p.id = (int)        dt.Rows[0]["id"];

            return p;
        }

        /// <summary>
        /// Modifie une personne en BDD.
        /// </summary>
        /// <param name="ID">ID de la personne à modifier.</param>
        /// <param name="modified">Objet Personne contenant les nouvelles infos.</param>
        /// <returns>True si la modif s'est bien passée, false sinon.</returns>
        public override bool set(int ID, Personne modified) {
            return false;
        }

        /// <summary>
        /// Ajoute une personne en BDD.
        /// </summary>
        /// <param name="newPerson">Objet Personne contenant les infos. Si l'ID est négatif, en génère un.</param>
        /// <returns>L'ID de la personne ajoutée. En cas d'erreur, retourne -1.</returns>
        public override int add(Personne newPerson) {
            return -1;
        }

        /// <summary>
        /// Supprime une personne.
        /// </summary>
        /// <param name="id">ID de la personne à supprimer.</param>
        /// <returns>True si la modif s'est bien passée, false sinon.</returns>
        public override bool del(int id) {
            return false;
        }

        /// <summary>
        /// Récupère toutes les personnes de la BDD.
        /// </summary>
        /// <returns>Une List contenant les personnes.</returns>
        public override List<Personne> getAll() {
            List<Personne> ps = new List<Personne>();

            string requete =
                  "SELECT * "
                + "FROM " + TABLE + " ";

            DataTable dt = SELECT(requete);
            if (dt.Rows.Count < 1) {
                return ps;
            }

            foreach(DataRow Row in dt.Rows) {
                Personne p = new Personne();
                p.nom = (string) Row["nom"];
                p.pseudo = (string) Row["pseudo"];
                p.avatar = (string) Row["avatar"];
                p.habituel = ((sbyte) Row["habituel"] != 0);
                p.id = (int) Row["id"];

                ps.Add(p);
            }

            return ps;
        }
    }
}
