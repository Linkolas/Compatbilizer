using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Requetes
{
    class DBMagouille : DB_Base<Magouille>
    {
        public DBMagouille() {
			this.Table = "magouille";
		}

        public override int add(Magouille obj)
        {
            throw new NotImplementedException();
        }

        public override bool del(int id)
        {
            throw new NotImplementedException();
        }

        public override Magouille get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Magouille> getAll()
        {
            throw new NotImplementedException();
        }

        public override bool set(int id, Magouille obj)
        {
            throw new NotImplementedException();
        }
    }
}
