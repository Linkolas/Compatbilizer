using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.utils {
	static class Session {
		static public Personne Utilisateur = new Personne();
        static private List<Personne> ListUsers = new List<Personne>();
        /// <summary>
        /// Fonction qui retourne l'objet personne en fonction de son ID
        /// Si la personne n'a jamais été chargé avant on le stock dans la liste
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public Personne getUser(int id)
        {
            // On test si il est pas dans la liste
            foreach (Personne p in ListUsers)
            {
                if (p.id == id) return p;
            }
            // il n'est pas dans la liste du coup on va le chercher en base et on le rajoute à la liste
            Personne rtn = MySQL.Personne.get(id);
            ListUsers.Add(rtn);
            // On retourne l'utilisateur
            return rtn;
        }
	}
}
