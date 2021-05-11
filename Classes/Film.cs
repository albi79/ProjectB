using System;
using System.Collections.Generic;
using System.Text;
using ProjectB.DAL;
using ProjectB.pages;

namespace ProjectB.Classes
{
    public class Film
    {
        public string Titel { get; set; }
        public string Categorie { get; set; }
        public int Leeftijd { get; set; }
        public string Beschrijving { get; set; }
        public string Projectie { get; set; } //Imax / 2D / 3D ....
        public string Taal { get; set; }
        public string Ondertiteling { get; set; }
        public string Acteurs { get; set; }
        public string Regisseur { get; set; }

    } 
}
