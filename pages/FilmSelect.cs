using System;
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
            Console.WriteLine("1. Huidige films beheren");
            Console.WriteLine("2. Toekomstige films beheren");
            Console.WriteLine("b. Om terug te gaan");

            string HuidigOfToekomstig = Beheer.Input("");
            Console.WriteLine(HuidigOfToekomstig);
            if (HuidigOfToekomstig == "b")
                Startscherm.startscherm();

            while (HuidigOfToekomstig != "1" && HuidigOfToekomstig != "2" && HuidigOfToekomstig != "b")
            {
                Console.WriteLine("Er ging iets mis, kunt u uit de volgende keuzes kiezen:");
                Console.WriteLine("1. Huidige films beheren");
                Console.WriteLine("2. Toekomstige films beheren");
                Console.WriteLine("b. Om terug te gaan");
                HuidigOfToekomstig = Beheer.Input("");
                if (HuidigOfToekomstig == "b")
                    Startscherm.startscherm();
            }
            HuidigOfToekomstig = ("1" == HuidigOfToekomstig) ? "HuidigeFilms" : "ToekomstigeFilms";
            Overzicht(HuidigOfToekomstig);



            //int filmNummer = 1;

            //Console.Clear();
            //Console.WriteLine("Film Programma\n\nWelke film bent u in geïnteresseerd?");
            //Console.WriteLine();
            
            //foreach (var film in DataStorageHandler.Storage.Films)
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
            //    Console.ResetColor();
            //    Console.WriteLine($"     {film.Leeftijd}+     {film.Titel}\n     {film.Categorie}\n\n");
            //    filmNummer++;
            //}
            //int selectedFilm = Int32.Parse(Beheer.Input("Vul een film nummer in: " )) - 1;
            //Console.Clear();
            //Console.WriteLine("Informatie geselecteerde film");
            //Console.WriteLine();
            //Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
            //Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
            //Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
            //Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
            //Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
            //Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
            //Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
            //Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
            //Console.WriteLine("Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);

            
        }
        public static void Overzicht(string HuidigOfToekomstig)
        {
            Console.Clear();
            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                Console.WriteLine("U bevindt nu bij de Huidige Films overzicht");
                //loop door de lijst
                int filmNummer = 1;
                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n\n");
                    filmNummer++;
                }
            }
            if (HuidigOfToekomstig == "ToekomstigeFilms")
            {
                Console.WriteLine("U bevindt nu bij de Toekomstige Films overzicht");
                //loop door de lijst
                int filmNummer = 1;
                foreach (ToekomstigeFilm filmItem in DataStorageHandler.Storage.ToekomstigeFilms)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n     Release datum: {filmItem.Release}\n\n");
                    filmNummer++;
                }
            }



            //          film select
            int selectedFilm = Int32.Parse(Beheer.Input("Vul een film nummer in: ")) - 1;
            Console.Clear();
            if (HuidigOfToekomstig == "HuidigeFilms") { 
                Console.WriteLine("Informatie geselecteerde Huisige film");
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


                Console.WriteLine("\n1. voor kaartjes reserveren");
                Console.WriteLine("2. voor terug naar overzicht films");
                string toets = Beheer.Input("");

                if (toets == "1")
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
                                Reserveren.reserveren();
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
                        Reserveren.reserveren();
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
            else
            {
                Console.WriteLine("Informatie geselecteerde Toekomstige film");
                Console.WriteLine();
                Console.WriteLine("Titel: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Titel);
                Console.WriteLine("Categorie: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Categorie);
                Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd);
                Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Beschrijving);
                Console.WriteLine("Release: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Release);


                Console.WriteLine("\n1. voor kaartjes reserveren");
                Console.WriteLine("2. voor terug naar overzicht films");
                string toets = Beheer.Input("");

                if (toets == "1")
                {
                    if (DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd >= 16)
                    {
                        Console.WriteLine("\nBent u " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd + " of ouder?");
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
                                Reserveren.reserveren();
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
                        Reserveren.reserveren();
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
}
