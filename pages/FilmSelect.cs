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
            }

            while (HuidigOfToekomstig != "1" && HuidigOfToekomstig != "2" && HuidigOfToekomstig != "b")
            {
                Console.WriteLine("Er ging iets mis, kunt u uit de volgende keuzes kiezen:");
                Console.WriteLine("1. Huidige films");
                Console.WriteLine("2. Toekomstige films");
                Console.WriteLine("b. Om terug te gaan");
                HuidigOfToekomstig = Beheer.Input("");
                if (HuidigOfToekomstig == "b")
                {
                    Console.Clear();
                    ConsoleMenu.consoleMenu(gebruikersnaam);
                }
            }
            HuidigOfToekomstig = ("1" == HuidigOfToekomstig) ? "HuidigeFilms" : "ToekomstigeFilms";
            Console.Clear();
            Overzicht(HuidigOfToekomstig, gebruikersnaam);
        }
        public static void Overzicht(string HuidigOfToekomstig, string gebruikersnaam)
        {
            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                Console.WriteLine("U bevindt nu bij de Huidige Films overzicht");
                int filmNummer = 1;
                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}");
                    if (filmItem.Beoordeling != 0)
                    {
                        Console.Write("     Beoordeling: ");
                        for (int i = 0; i < filmItem.Beoordeling; i++)
                            Console.Write("*");
                        Console.Write(" / *****");
                        Console.WriteLine();
                    }

                    filmNummer++;
                }
            }
            if (HuidigOfToekomstig == "ToekomstigeFilms")
            {
                Console.WriteLine("U bevindt nu bij de Toekomstige Films overzicht");
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
            string toets = "";
            Console.WriteLine("\nb. Terug\nVul een film nummer in: ");
            string selectedFilmString = Beheer.Input("");
            int selectedFilm = 0;
            if (selectedFilmString == "b")
            {
                Console.Clear();
                ConsoleMenu.consoleMenu(gebruikersnaam);
            }
            try
            {
                selectedFilm = Int32.Parse(selectedFilmString) - 1;
                if (HuidigOfToekomstig == "HuidigeFilms")
                {
                    Console.Clear();
                    Console.WriteLine("Informatie geselecteerde huidige film");
                    Console.WriteLine();
                    Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
                    Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
                    Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
                    Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
                    Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
                    Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
                    Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
                    Console.WriteLine("Regisseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);

                    int aantalData = DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment.Length;

                    string[] datums = new string[aantalData];
                    string datumsdisplay = "";

                    for (int x = 0; x < aantalData; x++)
                    {
                        datums[x] = DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment[x][0];
                        if (x < aantalData - 1)
                        {
                            datumsdisplay += datums[x] + ", ";
                        }
                        else
                        {
                            datumsdisplay += datums[x];
                        }
                    }
                    Console.WriteLine("Speelt op de dagen: " + datumsdisplay);
                    Console.WriteLine("Zaal: " + DataStorageHandler.Storage.Films[selectedFilm].Zaal);
                    if (DataStorageHandler.Storage.Films[selectedFilm].Beoordeling != 0)
                    {
                        Console.Write("Beoordeling: ");
                        for (int i = 0; i < DataStorageHandler.Storage.Films[selectedFilm].Beoordeling; i++)
                            Console.Write("*");
                        Console.Write(" / *****");
                        Console.WriteLine();
                    }
                }
                if (HuidigOfToekomstig == "ToekomstigeFilms")
                {
                    Console.Clear();
                    Console.WriteLine("Informatie geselecteerde Toekomstige film");
                    Console.WriteLine();
                    Console.WriteLine("Titel: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Titel);
                    Console.WriteLine("Categorie: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Categorie);
                    Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd);
                    Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Beschrijving);
                    Console.WriteLine("Release: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Release);

                    Console.WriteLine("\nb. om terug naar het overzicht films");
                    string toets2 = Beheer.Input("");
                    if(toets2 == "b")
                    {
                        Console.Clear();
                        FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
                    }
                    else
                    {
                        bool inputVerkeerd = true;
                        while (inputVerkeerd)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nU heeft het verkeerd ingevuld.");
                            Console.ResetColor();
                            Console.WriteLine("Probeer het nogmaals.");
                            Console.Write("Toets ");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" b ");
                            Console.ResetColor();
                            Console.Write("om terug te gaan.\n\n");
                            toets2 = Beheer.Input("");
                            if (toets2 == "b")
                            {
                                inputVerkeerd = false;
                                Console.Clear();
                                FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
                            }

                        }
                    }

                }
            }
            catch
            {
                bool foutInput = true;
                while (foutInput)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("U heeft het verkeerd ingevuld.");
                    Console.ResetColor();
                    Console.WriteLine("Probeer het nogmaals.\n");
                    FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
                }
            }


            Console.WriteLine("\n1. voor kaartjes reserveren");
            Console.WriteLine("b. voor terug naar overzicht films");
            toets = Beheer.Input("");

            if (toets == "1")
            {
                Console.WriteLine("LET OP: U moet minimaal 12 jaar oud zijn om te mogen reserveren.\nAls u doorgaat, gaat u akkoord met deze voorwaarden.\n");
                Console.WriteLine("1. Doorgaan\nb. Terug");
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
                                Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
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
                                Console.WriteLine("\nFOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of b");
                                agecheck = false;
                            }
                        }
                    }
                    else
                    {
                        Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
                    }
                }
            }
            else if (toets == "b")
            { 
                Console.Clear();
                FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
            }
            else
            {
                Console.WriteLine("\nEr ging iets fout");
                Beheer.Input("");
            }

            
                if (toets == "1")
                {
                    Console.WriteLine("\nLET OP: U moet minimaal 12 jaar oud zijn om te mogen reserveren.\nAls u doorgaat, gaat u akkoord met deze voorwaarden.\n");
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
                                    Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
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
                                    Console.WriteLine("\nFOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of b");
                                    agecheck = false;
                                }
                            }
                        }
                        else
                        {
                            Reserveren.reserveren(DataStorageHandler.Storage.Films[selectedFilm].Zaal, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
                        }
                    }
                }
                else if (toets == "b")
                {
                    Console.Clear();
                    FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
                }

                else
                {
                    Console.WriteLine("\nEr ging iets fout");
                    Beheer.Input("");
                }
            
        }
    }
}
