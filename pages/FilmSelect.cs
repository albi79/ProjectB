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
        public static void filmSelect(string gebruikersnaam)
        {
            Console.WriteLine("1. Huidige films");
            Console.WriteLine("2. Toekomstige films");
            Console.WriteLine("b. Om terug te gaan");

            string HuidigOfToekomstig = Beheer.Input("");
            Console.WriteLine(HuidigOfToekomstig);
            if (HuidigOfToekomstig == "b")
            {
                Console.Clear();
                ConsoleMenu.consoleMenu(gebruikersnaam);
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
        public static void filmSelect(string gebruikersnaam)
        {
            Console.WriteLine("1. Huidige films");
            Console.WriteLine("2. Toekomstige films");
            Console.WriteLine("b. Om terug te gaan");

            string HuidigOfToekomstig = Beheer.Input("");
            Console.WriteLine(HuidigOfToekomstig);
            if (HuidigOfToekomstig == "b")
            {
                Console.WriteLine("Er ging iets mis, kunt u uit de volgende keuzes kiezen:");
                Console.WriteLine("1. Huidige films");
                Console.WriteLine("2. Toekomstige films");
                Console.WriteLine("b. Om terug te gaan");
                HuidigOfToekomstig = Beheer.Input("");
                if (HuidigOfToekomstig == "b")
                {
                    Console.Clear();
<<<<<<< HEAD
                    Startscherm.startscherm();
=======
                    ConsoleMenu.consoleMenu(gebruikersnaam);
>>>>>>> origin/Dong
                }
            }
            HuidigOfToekomstig = ("1" == HuidigOfToekomstig) ? "HuidigeFilms" : "ToekomstigeFilms";
            Console.Clear();
<<<<<<< HEAD
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
=======
            Overzicht(HuidigOfToekomstig, gebruikersnaam);
        }
        public static void Overzicht(string HuidigOfToekomstig, string gebruikersnaam)
>>>>>>> origin/Dong
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
<<<<<<< HEAD
=======
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
>>>>>>> origin/Dong
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


<<<<<<< HEAD
=======
            int selectedFilm = Int32.Parse(Beheer.Input("Vul een film nummer in: ")) - 1;
>>>>>>> origin/Dong

            //          film select
            int selectedFilm = Int32.Parse(Beheer.Input("Vul een film nummer in: ")) - 1;
            Console.Clear();
<<<<<<< HEAD
            if (HuidigOfToekomstig == "HuidigeFilms") { 
                Console.WriteLine("Informatie geselecteerde Huisige film");
=======
            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                Console.WriteLine("Informatie geselecteerde huidige film");
>>>>>>> origin/Dong
                Console.WriteLine();
                Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
                Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
                Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
                Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
<<<<<<< HEAD
                Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
=======
                //Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
>>>>>>> origin/Dong
                Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
                Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
                Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
                Console.WriteLine("Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);
<<<<<<< HEAD


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
=======
                //Console.WriteLine("Speeltijd: " + DataStorageHandler.Storage.Films[selectedFilm].Tijd);
                //Console.WriteLine("Speelt op: " + DataStorageHandler.Storage.Films[selectedFilm].Data);
                Console.WriteLine("Zaal: " + DataStorageHandler.Storage.Films[selectedFilm].Zaal);
                if (DataStorageHandler.Storage.Films[selectedFilm].Beoordeling != 0)
                {
                    Console.Write("Beoordeling: ");
                    for (int i = 0; i < DataStorageHandler.Storage.Films[selectedFilm].Beoordeling; i++)
                        Console.Write("*");
                    Console.Write(" / *****");
                    Console.WriteLine();
                }

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
                                    Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm);
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
                                            FilmSelect.filmSelect(gebruikersnaam);
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
                            Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm);
>>>>>>> origin/Dong
                        }
                    }
                    else
                    {
                        Reserveren.reserveren();
                    }
                }
<<<<<<< HEAD

                else if (toets == "2")
                    filmSelect();
=======
                else if (toets == "2")
                    filmSelect(gebruikersnaam);
>>>>>>> origin/Dong

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

<<<<<<< HEAD

=======
>>>>>>> origin/Dong
                Console.WriteLine("\n1. voor kaartjes reserveren");
                Console.WriteLine("2. voor terug naar overzicht films");
                string toets = Beheer.Input("");

                if (toets == "1")
                {
<<<<<<< HEAD
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
=======
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
                                    Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm);
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
                                            FilmSelect.filmSelect(gebruikersnaam);
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
                            Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm);
                        }
                    }
                }
                else if (toets == "2")
                    filmSelect(gebruikersnaam);
>>>>>>> origin/Dong

                else
                {
                    Console.WriteLine("\nEr ging iets fout");
                    Beheer.Input("");
                }
            }


        }

    }
}
