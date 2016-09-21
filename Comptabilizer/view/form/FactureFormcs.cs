using Comptabilizer.Database.Objets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comptabilizer.view.component;

namespace Comptabilizer.view.form
{
    public partial class FactureFormcs : Form
    {
        DetailsFactures df;
        public FactureFormcs(Facture f)
        {
            InitializeComponent();
            this.ControlBox = false;
            df = new DetailsFactures();
            df.facture = f;
            this.Controls.Add(df);

        }


        private void FactureFormcs_Load(object sender, EventArgs e)
        {

        }

        private void FactureFormcs_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
