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
        public string Taal { get; set; }
        public string Ondertiteling { get; set; }
        public string Acteurs { get; set; }
        public string Regisseur { get; set; }
        public int Zaal { get; set; }
        public string[][] Projectiemoment { get; set; }
        //public string[] Tijd { get; set; }
        //public string Data { get; set; } //Type aanpassen
        public int Beoordeling { get; set; }
        public int AantalBeoordelingen { get; set; }
        public int BeoordelingCumulatief { get; set; }

    } 
}
