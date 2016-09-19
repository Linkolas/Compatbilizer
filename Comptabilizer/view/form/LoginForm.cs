using Comptabilizer.utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comptabilizer.view.form
{
    public partial class LoginForm : Form {

		Main mainForm = null;
        RegistryKey comptabilizer;


        public LoginForm() {
            InitializeComponent();
            readRegistery();
			// On gère l'évènement de connection réussie.
			login1.ConnectionOK += Login1_ConnectionOK;
        }

        public void updateRegistery()
        {
            comptabilizer.SetValue("lastUserName", Session.Utilisateur.pseudo);
            comptabilizer.SetValue("lastUserAvatar", Session.Utilisateur.avatar);

        }

        public void readRegistery()
        {
            comptabilizer = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("Comptabilizer");
			
            if (comptabilizer.ValueCount > 0) {
                this.login1.userBox.Text = (string) comptabilizer.GetValue("lastUserName", "");
                this.login1.pictureBox1.Image = Avatar.image((string) comptabilizer.GetValue("lastUserAvatar", ""));
				this.login1.passwordBox.Select();
            }

        }

		/// <summary>
		/// Lancé lorsqu'un utilisateur s'est connecté.
		/// </summary>
		/// <param name="p"></param>
		private void Login1_ConnectionOK(Database.Objets.Personne p) {
			// Une personne s'est connectée ! On prépare la fenêtre suivante.
			mainForm = new Main();

			// On attache les évènements requis...
			mainForm.InitialDataLoaded += MainForm_InitialDataLoaded;
			mainForm.FormClosed += (e,v) => { this.Close(); };

			// On charge les données puis attend l'évènement suivant.
			mainForm.LoadData(p);
		}

		private void MainForm_InitialDataLoaded() {
			// On positionne puis affiche la fenêtre suivante.
			mainForm.StartPosition = FormStartPosition.CenterParent;
			mainForm.Show(this);

            //On met a jour le registre pour la prochaine session
            updateRegistery();

			// On cache cette fenêtre.
			// Il s'agit de la fenêtre principale, si on la ferme le logiciel entier est fermé.
			this.Hide();
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void login1_Load(object sender, EventArgs e)
        {

        }
    }
}
