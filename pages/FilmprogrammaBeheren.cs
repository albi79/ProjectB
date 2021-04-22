using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;
using System.Collections;

namespace ProjectB.pages
{


    class FilmprogrammaBeheren
    {
        public static void filmprogrammaBeheren()
            {
            int filmNummer = 0;
            ArrayList films = new ArrayList() {"Rambo","Man in black", "pirates of the carribean"};
            foreach (var film in films)
            {
                Console.WriteLine($"{filmNummer}: {film}");
                filmNummer++;
            }

            Console.WriteLine();
            Console.WriteLine("Toets: 'T' voor film toevoegen");
            Console.WriteLine("Toets: 'V' voor film verwijderen");

            string gegeven = Beheer.Input("");

            if(gegeven == "t")
            {
                string nieuwFilm = Beheer.Input("Welke film wilt u toevoegen: ");
                films.Add(nieuwFilm);
                foreach(var film in films)
                    Console.WriteLine(film);
            }

            else if(gegeven == "v")
            {
                int verwijderIndex = Convert.ToInt32(Beheer.Input(": "));
                films.RemoveAt(verwijderIndex);
                foreach (var film in films)
                    Console.WriteLine(film);
            }
        }
    }
}