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
		public override int add(Log obj) {
			throw new NotImplementedException();
		}

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
