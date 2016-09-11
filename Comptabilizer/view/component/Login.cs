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
using Comptabilizer.view.form;
using Comptabilizer.utils;
using System.Diagnostics;

namespace Comptabilizer.view
{
    public partial class Login : UserControl
    {
		public delegate void ConnectionOKHandler(Personne p);
		public event ConnectionOKHandler ConnectionOK = delegate { };


		public Login() {
            InitializeComponent();

			ConnectionOK += Login_ConnectionOK;
        }

		private void button1_Click(object sender, EventArgs e) {
			if((this.userBox.Text != "") && (this.passwordBox.Text != "")) {
				//Les champs sont remplis, on tente de se connecter à la base
				Personne p = new Personne();
				p = MySQL.Personne.Connection(userBox.Text, passwordBox.Text);

				if (p.id == -1) {
					MessageBox.Show("Erreur de Connection, Votre identifiant ou votre mot de passe semble incorrect try again", "Erreur de Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// On stocke l'utilisateur en session.
				Session.Utilisateur = p;

				// On déclenche l'évènement.
				ConnectionOK(p);

			} else {
				MessageBox.Show("Erreur de Connection, un ou plusieurs champs ne semble pas être remplis", "Erreur de Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Login_ConnectionOK(Personne p) {
			Debug.WriteLine("TODO : Afficher le chargement.");
		}
	}
}
