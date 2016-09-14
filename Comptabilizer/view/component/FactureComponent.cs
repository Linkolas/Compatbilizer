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
    public partial class FactureComponent : UserControl
    {
        private Facture f = null;
        Color backGroundcolor;
        bool MousseOver = false;

        public FactureComponent()
        {
            InitializeComponent();
            backGroundcolor = panel5.BackColor;
        }

        #region ACCESSEURS

        /// <summary>
        /// Attribue ou retourne une Facture
        /// </summary>
        public Facture facture
        {
            get { return this.f; }
            set { if (value != null) this.f = value; this.updateForm(this.f); }
        }

        #endregion

        #region Updateur

        //TODO MISE A JOUR AUTOMATIQUE DES FACTURES
        //public delegate void FactureValueChanged(object sender, EventArgs e);
        //public event FactureValueChanged fvc;
        
        private void updateForm(Facture f)
        {
            this.Value.Text = f.valeur.ToString() + "€";
            this.FacName.Text = f.libelle + " | " + f.date.ToString();
            this.Avatar_Owner.Image = Avatar.image(Session.Utilisateur.avatar); // A optimiser

            bool lUtilisateurAPAyeSapart = false;
            bool ToutleMondeApayer = true;
            foreach (KeyValuePair<int, bool> entry in MySQL.Facture.Participant_getAll(f.id))
            {
                if (entry.Key == Session.Utilisateur.id && entry.Value == true)
                    lUtilisateurAPAyeSapart = true;
                if (entry.Value == false)
                    ToutleMondeApayer = false;
            }
            if (ToutleMondeApayer) this.pictureBox1.Image = Properties.Resources._checked;
            else if (!ToutleMondeApayer && lUtilisateurAPAyeSapart) this.pictureBox1.Image = Properties.Resources.checked_warning;
            else this.pictureBox1.Image = Properties.Resources.error;


        }

        #endregion

        #region Public Methods



        #endregion

        private void Avatar_Owner_Click(object sender, EventArgs e)
        {

        }

        private void FacName_Click(object sender, EventArgs e)
        {

        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {

            //Au survole de la souris on change le background de facon smouth 
            //A finir de coder
            /*MousseOver = true;
            while (MousseOver == true && panel5.BackColor.R < 120) {
                panel5.BackColor = Color.FromArgb(panel5.BackColor.R + 0x01, panel5.BackColor.G + 0x01, panel5.BackColor.B + 0x01);

            }*/
        }



    }
}
