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
    public partial class DetailsFactures : UserControl
    {
        public List<Magouille> listMagouille = new List<Magouille>();

        public Facture facture
        {
            get { return facture; }
            set { facture = value; UpdateComponent(); }
        }

        public DetailsFactures()
        {
            InitializeComponent();
        }

        private void UpdateComponent()
        {
            showBuyer();
            showParticipant();
            showMacOuille();
        }

        private void showBuyer()
        {
            Personne Acheteur = Session.getUser(facture.id_payeur);
            this.pictureBox1.Image = Avatar.image(Acheteur.avatar);
            this.label1.Text = Acheteur.pseudo;
            this.label2.Text = facture.date.ToString("dd/mm");
            this.label3.Text = facture.valeur + "€";

        }

        private void showParticipant()
        {
            Dictionary<int, bool> dick = MySQL.Facture.Participant_getAll(facture.id);
            int nombreDeParticipant = dick.Count;
            if (nombreDeParticipant <= 0) return;
            int w = panel3.Width;
            int h = panel3.Height;
            int wP = w * (2 / 3) / nombreDeParticipant; // Je divise par le nombre de participant #AFCD
            int wOff = w * (1 / 3) / (nombreDeParticipant + 1);
            Point origin = new Point(wOff, 0);

            //Declaration des variables temporaire
            Personne _personne;
            PictureBox _avatar;
            PictureBox _checked;
            Label _pseudo;

            foreach (KeyValuePair<int, bool> entry in dick) // oh lol
            {
                //On récupère l'utilisateur
                _personne = Session.getUser(entry.Key);

                //On affiche l'avatar
                _avatar = new PictureBox();
                _avatar.SizeMode = PictureBoxSizeMode.StretchImage;
                _avatar.Image = Avatar.image(_personne.avatar);
                _avatar.Height = h;
                _avatar.Width = h;
                _avatar.Padding = new Padding(5);
                _avatar.Location = origin;

                // mise a jour du point d'origine pour le pseudo
                origin.X += _avatar.Width + 5; // 5 pixels d'offset pour éviter d'être accolé à l'avatar

                // On affiche le pseudo
                _pseudo = new Label();
                _pseudo.Text = _personne.pseudo;
                _pseudo.Font = new Font("Segoe UI", 10);
                _pseudo.ForeColor = Color.DarkGray;
                _pseudo.Location = origin;

                //on met à jour origin pour le checked
                origin.Y += h * (2 / 3); 

                // on affiche si l'utilisateur a payé sa part
                _checked = new PictureBox();
                _checked.SizeMode = PictureBoxSizeMode.StretchImage;
                _checked.Height = h / 3;
                _checked.Width = _checked.Height;
                _checked.Padding = new Padding(2);
                _checked.Location = origin;

                if (entry.Value == false)
                {
                    _checked.Image = Properties.Resources.error;
                }
                else
                {
                    _checked.Image = Properties.Resources._checked;
                }

                //On ajoute les controles a la vue
                panel3.Controls.Add(_avatar);
                panel3.Controls.Add(_pseudo);
                panel3.Controls.Add(_checked);

                // On reset origin pour le prochain Participant
                origin.Y = 0;
                origin.X += (-_avatar.Width - 5) + wP + wOff;
            }
        }

        private void showMacOuille()
        {
            //Récupération des magouilles
            listMagouille = MySQL.Magouille.getForFacture(facture.id);

            //Déclarations des variables
            Panel _p;
            Point _origin = new Point(0, 0);
            Label _pseudo;
            Label _montant;
            Label _libelule;
            PictureBox _pb;
            Personne _personne;

            foreach (Magouille m in listMagouille)
            {
                //On recup la personne
                _personne = Session.getUser(m.id_beneficiaire);
                // Preparation panel
                _p = new Panel();
                _p.Height = 100;
                _p.Width = panel2.Width;
                _p.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                _p.Location = _origin;

                //Preparation Picture box
                _pb = new PictureBox();
                _p.Controls.Add(_pb);
                _pb.Image = Avatar.image(_personne.avatar);
                _pb.SizeMode = PictureBoxSizeMode.StretchImage;
                _pb.Location = new Point(0,0);
                _pb.Dock = DockStyle.Right;
                _pb.Width = _pb.Height;

                // On affiche le nom du bénéficiaire
                _pseudo = new Label();
                _pseudo.Text = _personne.pseudo;
                _pseudo.Font = new Font("Segoe UI", 10);
                _pseudo.ForeColor = Color.DarkGray;
                _pseudo.Location = new Point(_pb.Width + 5, 45);
                _p.Controls.Add(_pseudo);

                //On affiche le montant 
                _montant = new Label();
                _montant.Text = m.valeur.ToString() ;
                _montant.Font = new Font("Segoe UI", 10);
                _montant.ForeColor = Color.DarkGray;
                _montant.Location = new Point(_pb.Width + 5 + _pseudo.Width + 5, 45);
                _p.Controls.Add(_montant);

                //On affiche la raison
                _libelule = new Label();
                _libelule.Text = m.valeur.ToString();
                _libelule.Font = new Font("Segoe UI", 10);
                _libelule.ForeColor = Color.DarkGray;
                _libelule.Location = new Point(panel2.Width - _libelule.Width - 5, 45);
                _libelule.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                _p.Controls.Add(_libelule);

                // On integre le nouveau panel à la vue
                panel2.Controls.Add(_p);

                // On incrémente le point pour la prochaine magouille MOUHHHAA
                _origin.Y += 100;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
