using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comptabilizer.Database.Objets;
using Comptabilizer.utils;
using System.Diagnostics;

namespace Comptabilizer.view.component
{
    public partial class dashboard : UserControl
    {
		private Dictionary<int, Categorie> Categories = new Dictionary<int, Categorie>();


        public dashboard()
        {
            InitializeComponent();
        }

        public void loadCategorie()
        {
            Immeuble I = null;
            foreach (Categorie c in MySQL.Categorie.getAll())
            {

            }
        }

        public void loadFactures()
        {
            FactureComponent fc = null;
            foreach (Facture f in MySQL.Facture.getAll_Concernant(Session.Utilisateur.id)) {
                fc = new FactureComponent();
                fc.facture = f;
				fc.Dock = DockStyle.Top;
                FacContainerPanel.Controls.Add(fc);

				loadCategories(f.id);
            }
        }

		public void loadCategories(int id_facture) {
			List<int> ids_categ = MySQL.Facture.Category_getAll(id_facture);
			foreach (int id_categ in ids_categ) {
				if (Categories.Keys.Contains(id_categ))
					continue;

				Categorie cat = MySQL.Categorie.get(id_categ);
				if (cat.id == -1)
					continue;

				Categories.Add(id_categ, cat);
				Debug.WriteLine(cat.libelle);
			}
		}
    }
}
