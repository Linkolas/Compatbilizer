using Comptabilizer.Database.Requetes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer {
    static class MySQL {
        
        static public DBPersonne Personne {
            get { return new DBPersonne(); }
        }
    }
}
