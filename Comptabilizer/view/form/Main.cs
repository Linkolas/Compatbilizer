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

        private bool mousseDown = false;
        private Point firstPoint;

        public Main() {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "";
        }

		/// <summary>
		/// Charge les données à afficher à une personne puis envoie l'évènement InitialDataLoaded.
		/// </summary>
		/// <param name="p"></param>
		internal void LoadData(Personne p) {
            dashboard1.loadFactures();

            InitialDataLoaded();
		}

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("MousseDown");
            mousseDown = true;
            firstPoint = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousseDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }
    }
}
