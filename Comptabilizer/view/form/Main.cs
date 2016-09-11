using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comptabilizer.Database.Objets;
using System.Diagnostics;

namespace Comptabilizer.view.form
{
    public partial class Main : Form
    {
		public delegate void InitialDataLoadedHandler();
		public event InitialDataLoadedHandler InitialDataLoaded = delegate { };


		public Main() {
            InitializeComponent();
        }

		/// <summary>
		/// Charge les données à afficher à une personne puis envoie l'évènement InitialDataLoaded.
		/// </summary>
		/// <param name="p"></param>
		internal void LoadData(Personne p) {
			// ... On charge les données...
			// ... On charge les données...
			// ... On charge les données...
			// ... On charge les données...
			// ... On charge les données...
			
			// On envoie l'évènement.
			InitialDataLoaded();
		}
	}
}
