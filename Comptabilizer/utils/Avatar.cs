using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.utils
{
    public class Avatar
    {

        /// <summary>
        /// Cette classe ne peut être instancié utilisez 
        /// </summary>
        private Avatar()
        {
            initializeComponent();
        }

        /// <summary>
        /// Liste contenant tout les avatars
        /// </summary>
        private static List<System.Drawing.Bitmap> l = new List<System.Drawing.Bitmap>();

        private static void initializeComponent()
        {
            l.Add(Properties.Resources.boy);
            l.Add(Properties.Resources.boy_1);
            l.Add(Properties.Resources.boy_2);
            l.Add(Properties.Resources.boy_3);
            l.Add(Properties.Resources.boy_4);
            l.Add(Properties.Resources.boy_5);
            l.Add(Properties.Resources.girl);
            l.Add(Properties.Resources.girl_1);
            l.Add(Properties.Resources.girl_2);
            l.Add(Properties.Resources.girl_3);
            l.Add(Properties.Resources.girl_4);
            l.Add(Properties.Resources.girl_5);
        }



        public static System.Drawing.Bitmap image( string id )
        {
            if (id == "") return Properties.Resources.user;
            return l.ElementAt(Int32.Parse(id));
        }

    }
}
