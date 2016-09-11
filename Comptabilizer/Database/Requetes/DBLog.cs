using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Comptabilizer.Database.Requetes {
	class DBLog : DB_Base<Log> {

		public DBLog() {
			this.Table = "log";
		}

		#region DB_Base implementation

		/// <summary>
		/// Ajoute un objet en BDD.
		/// Si son ID est négatif, en génère un.
		/// </summary>
		/// <param name="f">Objet contenant les infos.</param>
		/// <returns>L'ID de l'objet ajouté. En cas d'erreur, retourne -1.</returns>
		public override int add(Log obj) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Modifie un objet en BDD.
		/// </summary>
		/// <param name="id">ID de l'objet à modifier.</param>
		/// <param name="f">Objet contenant les nouvelles infos.</param>
		/// <returns>True si la modif s'est bien passée, false sinon.</returns>
		public override bool set(int id, Log obj) {
			throw new NotImplementedException();
		}

		public override Log DefaultObject() {
			throw new NotImplementedException();
		}

		protected override Log DRowToObject(DataRow DRow) {
			throw new NotImplementedException();
		}
		#endregion
	}
}
