﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comptabilizer.Database.Objets
{
    class Facture {
        public int id = -1;
        public int id_payeur;
        public float valeur;
        public DateTime date;
        public string libelle;
    }
}