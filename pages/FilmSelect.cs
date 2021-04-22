using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class FilmSelect
    {
        public static void filmSelect()
        {
            Console.Clear();
            Console.WriteLine("Film Programma\n\nWelke film bent u in geïnteresseerd?");
            Console.WriteLine();
            
            int filmNummer = 0;
            
            foreach (var film in films)
            {
                Console.WriteLine($"{filmNummer}: {film}");
                filmNummer++;
            }

            int selectedFilm = Int32.Parse(Beheer.Input());

            Console.Clear();
            Console.WriteLine(films[selectedFilm]);

            
        }
    }
}
