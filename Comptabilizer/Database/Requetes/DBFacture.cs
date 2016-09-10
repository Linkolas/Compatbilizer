using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes
{
    class DBFacture : DB_Base<Facture>
    {
        public DBFacture() {
			this.Table = "facture";
		}

        public override int add(Facture obj)
        {
            throw new NotImplementedException();
        }

        public override bool del(int id)
        {
            throw new NotImplementedException();
        }

        public override Facture get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Facture> getAll()
        {
            throw new NotImplementedException();
        }

        public override bool set(int id, Facture obj)
        {
            throw new NotImplementedException();
        }
    }
}
