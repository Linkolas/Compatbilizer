using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Objets
{
    class Log
    {
        public int id = -1;
        public int id_personne = -1;
        public DateTime date = DateTime.Now;
        public string libelle = "";
    }
}
