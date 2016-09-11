using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.utils {
	static class Tests {

		static public void Test_DBPersonne() {
			// GET
			Personne p1 = MySQL.Personne.get(1);
			List<Personne> lp1 = MySQL.Personne.getAll();

			// ADD
			int id1 = MySQL.Personne.add(new Personne() { id = 2, nom = "Jean Truc" });
			Personne p2 = MySQL.Personne.get(id1);
			List<Personne> lp2 = MySQL.Personne.getAll();

			// EDIT
			p2.pseudo = "Jean";
			bool ok1 = MySQL.Personne.set(p2.id, p2);
			bool ok2 = MySQL.Personne.setPassword(p2.id, "Truc");
			Personne p3 = MySQL.Personne.get(id1);
			List<Personne> lp3 = MySQL.Personne.getAll();

			Personne p4 = MySQL.Personne.Connection("LOL", "NOPE");
			Personne p5 = MySQL.Personne.Connection("Jean", "Truc");

			// DELETE
			bool ok3 = MySQL.Personne.del(p3.id);
			Personne p6 = MySQL.Personne.get(id1);
			List<Personne> lp4 = MySQL.Personne.getAll();
		}

	}
}
