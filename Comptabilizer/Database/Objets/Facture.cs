using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Objets
{
    class Facture {
        public int id = -1;
        public int id_payeur = -1;
        public float valeur = -1;
        public DateTime date = DateTime.Now;
        public string libelle = "";
    }
}
