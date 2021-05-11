﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.DAL;
using System.IO;

namespace ProjectB.pages
{
    class FilmSelect
    {
        public static void filmSelect()
        {
            
            int filmNummer = 0;

            Console.Clear();
            Console.WriteLine("Film Programma\n\nWelke film bent u in geïnteresseerd?");
            Console.WriteLine();
            
            foreach (var film in DataStorageHandler.Storage.Films)
            {
                Console.WriteLine($"{filmNummer}: {film.Titel}");
                filmNummer++;
            }

            int selectedFilm = Int32.Parse(Beheer.Input());

            Console.Clear();
            Console.WriteLine("Informatie geselecteerde film");
            Console.WriteLine();
            Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
            Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
            Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
            Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
            Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
            Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
            Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
            Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
            Console.WriteLine("Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);

            Console.WriteLine("\nToets 1. voor kaartjes reserveren");
            Console.WriteLine("Toets 2. voor terug naar overzicht films");
            string toets = Beheer.Input("");

            if (toets == "1")
            {
                Reserveren.reserveren();
            }
            
            else if (toets == "2")
                filmSelect();
            
            else
            {
                Console.WriteLine("\nEr ging iets fout");
                Beheer.Input("");
            }
        }
    }
}
