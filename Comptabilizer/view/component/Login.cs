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

namespace Comptabilizer.view
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
		
		private void button1_Click(object sender, EventArgs e) {
			if((this.textBox1.Text != "") && (this.textBox1.Text != "")) {
				//Les champs sont rempli on tent de se connecter à la base
				Personne p = new Personne();
				p = MySQL.Personne.Connection(textBox1.Text, textBox2.Text);
				Hide();
				//if(p.id == -1) MessageBox.Show("Erreur de Connection, Votre identifiant ou votre mot de passe semble incorrect try again", "Erreur de Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Main m = new Main();
				
				m.Show();
			} else {
				MessageBox.Show("Erreur de Connection, un ou plusieurs champs ne semble pas être remplis", "Erreur de Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
