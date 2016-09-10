using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes {
	class DBLog : DB_Base<Log> {

		public DBLog() {
			this.Table = "log";
		}

		public override int add(Log obj) {
			throw new NotImplementedException();
		}

		public override bool del(int id) {
			throw new NotImplementedException();
		}

		public override Log get(int id) {
			throw new NotImplementedException();
		}

		public override List<Log> getAll() {
			throw new NotImplementedException();
		}

		public override bool set(int id, Log obj) {
			throw new NotImplementedException();
		}
	}
}
