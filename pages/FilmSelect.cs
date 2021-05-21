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
            int filmNummer = 1;

            Console.Clear();
            Console.WriteLine("Film Programma\n\nWelke film bent u in geïnteresseerd?");
            Console.WriteLine();
            
            foreach (var film in DataStorageHandler.Storage.Films)
            {
                Console.WriteLine($"{filmNummer}: {film.Titel}");
                filmNummer++;
            }

            int selectedFilm = Int32.Parse(Beheer.Input()) -1;

            Console.Clear();
            Console.WriteLine("Informatie geselecteerde film");
            Console.WriteLine();
            Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
            Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
            Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
            Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
            //Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
            Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
            Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
            Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
            Console.WriteLine("Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);
            Console.WriteLine("Speeltijd: " + DataStorageHandler.Storage.Films[selectedFilm].Tijd);
            Console.WriteLine("Speelt op: " + DataStorageHandler.Storage.Films[selectedFilm].Data);
            Console.WriteLine("Zaal: " + DataStorageHandler.Storage.Films[selectedFilm].Zaal);
            if (DataStorageHandler.Storage.Films[selectedFilm].Beoordeling != 0)
                Console.Write("Beoordeling: ");
                for (int i = 0; i < DataStorageHandler.Storage.Films[selectedFilm].Beoordeling; i++)
                    Console.Write("*");
            Console.Write(" / *****");
            Console.WriteLine();

            Console.WriteLine("\n1. voor kaartjes reserveren");
            Console.WriteLine("2. voor terug naar overzicht films");
            string toets = Beheer.Input("");

            if (toets == "1")
            {
                Console.WriteLine("LET OP: U moet minimaal 12 jaar oud zijn om te mogen reserveren.\nAls u doorgaat, gaat u akkoord met deze voorwaarden.\n");
                Console.WriteLine("1. Doorgaan\n2. Terug");
                string toets2 = Beheer.Input("");
                if (toets2 == "1")
                {
                    if (DataStorageHandler.Storage.Films[selectedFilm].Leeftijd >= 16)
                    {
                        Console.WriteLine("\nBent u " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd + " of ouder?");
                        Console.WriteLine("\n1. JA");
                        Console.WriteLine("2. NEE");
                        bool agecheck = false;
                        var ageinput = "";
                        var backinginput = "";
                        bool backingoption = false;

                        while (agecheck == false)
                        {
                            ageinput = Console.ReadLine();

                            if (ageinput == "1")
                            {
                                Console.Clear();
                                Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal);
                                agecheck = true;
                            }

                            else if (ageinput == "2")
                            {
                                Console.WriteLine("\nU voldoet niet aan de minimum leeftijd" + "\nToets b om terug te gaan");

                                while (backingoption == false)
                                {
                                    backinginput = Console.ReadLine();

                                    if (backinginput == "b")
                                    {
                                        FilmSelect.filmSelect();
                                        backingoption = true;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nFOUTMELDING: er is een ongeldige toets ingevoerd. Toets b om terug te gaan.");
                                        backingoption = false;
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("\nFOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                                agecheck = false;
                            }
                        }
                    }
                    else
                    {
                        Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal);
                    }
                }
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
