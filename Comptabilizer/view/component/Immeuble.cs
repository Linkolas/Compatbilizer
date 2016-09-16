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

namespace Comptabilizer.view.component
{
    public partial class Immeuble : UserControl
    {

        public Categorie c
        {
             get { return this.c; }
             set { this.c = value; initImmeuble(); }
        }

        public Immeuble()
        {
            InitializeComponent();
        }

        private void initImmeuble()
        {
            this.label1.Text = c.libelle;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
