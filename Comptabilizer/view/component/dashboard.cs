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

namespace Comptabilizer.view.component
{
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();
        }

        public void loadFactures()
        {
            FactureComponent fc = null;
            foreach (Facture f in MySQL.Facture.getAllFromPerson(Session.Utilisateur))
            {
                fc = new FactureComponent();
                fc.facture = f;
                FacContainerPanel.Controls.Add(fc);
            }
        }
    }
}
