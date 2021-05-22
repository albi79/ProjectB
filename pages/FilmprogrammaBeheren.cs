using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class FilmprogrammaBeheren
    {
        public static void filmprogrammaBeheren()
        {
                Console.WriteLine("1. Huidige films beheren");
                Console.WriteLine("2. Toekomstige films beheren");
                Console.WriteLine("b. Om terug te gaan");

                string HuidigOfToekomstig = Beheer.Input("");
                if (HuidigOfToekomstig == "b")
                {
                    Console.Clear();
                    AdminMenu.adminMenu();
                }

                while (HuidigOfToekomstig != "1" && HuidigOfToekomstig != "2" && HuidigOfToekomstig != "b")
                {
                    Console.WriteLine("Er ging iets mis, kunt u uit de volgende keuzes kiezen:");
                    Console.WriteLine("1. Huidige films beheren");
                    Console.WriteLine("2. Toekomstige films beheren");
                    Console.WriteLine("b. Om terug te gaan");
                    HuidigOfToekomstig = Beheer.Input("");
                    if (HuidigOfToekomstig == "b")
                    {
                        Console.Clear();
                        AdminMenu.adminMenu();
                }
                }
                HuidigOfToekomstig = ("1" == HuidigOfToekomstig) ? "HuidigeFilms" : "ToekomstigeFilms";
                Overzicht(HuidigOfToekomstig);

        }
        public static void Overzicht(string HuidigOfToekomstig)
        {
            Console.Clear();
            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                Console.WriteLine("U bevindt nu bij de Huidige Films overzicht");
            }
            else
            {
                Console.WriteLine("U bevindt nu bij de Toekomstige Films overzicht");
            }

            Console.WriteLine("1. Film toevoegen");
            Console.WriteLine("2. Film verwijderen");
            Console.WriteLine("Dit zijn de huidige films die in het programma voortkomen:\n(Titel - Categorie - Leeftijd)\n-------------------------------------------");

            if (HuidigOfToekomstig == "HuidigeFilms")
            {
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
            string gegeven = Beheer.Input("");

            if (gegeven == "1")
                toevoegen(HuidigOfToekomstig);


            else if (gegeven == "2")
                verwijderen(HuidigOfToekomstig);

            //WIJZIGEN NOG NIET KUNNEN SAMENVOEGEN(DANI & NISA)
            //else if(gegeven == 3)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Film info bewerken\n\nWelke film wilt u wijzigen:\n");

            //    int filmNummer = 1;
            //    foreach (var film in DataStorageHandler.Storage.Films)
            //    {
            //        Console.WriteLine($"{filmNummer}: {film.Titel}");
            //        filmNummer++;
            //    }
            //    int selectedFilm = Int32.Parse(Beheer.Input("\n")) -1;

            //    try
            //    {
            //        FilmInfoWijzigen.filmInfoWijzigen(selectedFilm);
            //    }
            //    catch
            //    {
            //        FilmprogrammaBeheren.filmprogrammaBeheren();
            //    }
            //}
        }
        public static void toevoegen(string HuidigOfToekomstig)
        {
            Console.Clear();
            string nTitel = Beheer.Input("Wat is de titel van de nieuwe film?\n");
            string nCategorie = Beheer.Input("Wat is de categorie van de nieuwe film?\n");
            int nLeeftijd = Convert.ToInt32(Beheer.Input("Wat is de minimum leeftijd van de nieuwe film?\n"));
            string nBeschrijving = Beheer.Input("Schrijf een korte filmbeschrijving\n");


            {
                //TODO: FOUTMELDING

                if (HuidigOfToekomstig == "HuidigeFilms")
                {
                        
                    string nTaal = Beheer.Input("Wat is de Hoofdtaal van de film?\n");
                    string nOndertiteling = Beheer.Input("In welke taal is de ondertiteling?\n");
                    string nActeurs = Beheer.Input("Welke grote acteurs spelen in de film?\n");
                    string nRegisseur = Beheer.Input("Wie is de regiseur van de film?\n");

                    int nZaal = 0;
                    while (nZaal != 1 && nZaal != 2 && nZaal != 3)
                    {
                        Console.WriteLine("\nIn welke zaal speelt de film?\nZaal 1(2D), Zaal 2(3D) of Zaal 3(IMAX)\n");
                        string sZaal = Beheer.Input("Typ 1, 2 of 3: ");
                        try
                        {
                            nZaal = Int32.Parse(sZaal);
                        }
                        catch { Console.WriteLine("Verkeerde zaal input!\nTyp Enter"); Beheer.Input(); }
                    }

                    //Bij verkeerde tijd input moet je via de app bewerken filmInfoWijzigen()
                    /*int hoeveelTijden = Int32.Parse(Beheer.Input("\nHoe vaak wordt de film op een dag gedraaid? "));
                    string[] nTijd = new string[hoeveelTijden];
                    for (int i = 0; i < hoeveelTijden; i++)
                    {
                        Console.WriteLine($"\nOp welk tijdstip begint de {i + 1}e projectie (HH:MM) ?");
                        nTijd[i] = Beheer.Input("");
                    }
                    */
                    //string nData = Beheer.Input("\nOp welke data/datum draait de film?\n");

                    int hoeveelDagen = 0;
                    bool dagenInput = false;
                    while (dagenInput != true)
                    {
                        try
                        {
                            hoeveelDagen = Int32.Parse(Beheer.Input("\nOp hoeveel dagen totaal wordt de film gedraaid? "));
                            dagenInput = true;
                        }
                        catch { Console.WriteLine("Verkeerde input!\nTyp Enter"); Beheer.Input(); }
                    }
                    string[][] nProjectiemoment = new string[hoeveelDagen][];

                    for (int i = 0; i < hoeveelDagen; i++)
                    {
                        string datum = "";
                        bool datumInput = false;
                        while (datumInput != true)
                        {
                            Console.WriteLine($"\nWelke datum is de {i + 1}e projectie?\n(DD-MM-JJJJ)");
                            datum = Beheer.Input("");
                            if (datum.Length == 10)
                                datumInput = true;
                            else
                            {
                                Console.WriteLine("Verkeerde input!\nTyp Enter");
                                Beheer.Input();
                            }
                        }

                        int hoeveelTijden = 0;
                        bool tijdenInput = false;
                        while (tijdenInput != true)
                        {
                            try
                            {
                                hoeveelTijden = Int32.Parse(Beheer.Input($"\nHoe vaak wordt de film op {datum} gedraaid? \n"));
                                nProjectiemoment[i] = new string[hoeveelTijden + 1];
                                nProjectiemoment[i][0] = datum;
                                tijdenInput = true;
                            }
                            catch { Console.WriteLine("Verkeerde input!\nTyp Enter"); Beheer.Input(); }
                        }


                        for (int x = 1; x < hoeveelTijden + 1; x++)
                        {
                            bool huidigeTijdInput = false;
                            while (huidigeTijdInput != true)
                            {
                                Console.WriteLine($"\nOp welk tijdstip begint de {x}e projectie op {nProjectiemoment[i][0]}\n(HH:MM) ?");
                                string huidigeTijd = Beheer.Input("");
                                if (huidigeTijd.Length == 5)
                                {
                                    huidigeTijdInput = true;
                                    nProjectiemoment[i][x] = huidigeTijd;
                                }
                                else
                                {
                                    Console.WriteLine("\nVerkeerde input!\nTyp Enter");
                                    Beheer.Input();
                                }
                            }
                        }
                    }

                    Beheer.Input();

                    Film nieuweFilm = new Film
                    {
                        Titel = nTitel,
                        Categorie = nCategorie,
                        Leeftijd = nLeeftijd,
                        Beschrijving = nBeschrijving,
                        Taal = nTaal,
                        Ondertiteling = nOndertiteling,
                        Acteurs = nActeurs,
                        Regisseur = nRegisseur,
                        Zaal = nZaal,
                        Projectiemoment = nProjectiemoment
                    };

                    DataStorageHandler.Storage.Films.Add(nieuweFilm);
                }


                else if (HuidigOfToekomstig == "ToekomstigeFilms")
                {
                    string nRelease = Beheer.Input("Wanneer wordt de film gereleased?\n");
                    ToekomstigeFilm nieuweToekomstigeFilm = new ToekomstigeFilm
                    {
                        Titel = nTitel,
                        Categorie = nCategorie,
                        Leeftijd = nLeeftijd,
                        Beschrijving = nBeschrijving,
                        Release = nRelease
                    };

                    DataStorageHandler.Storage.ToekomstigeFilms.Add(nieuweToekomstigeFilm);
                }

                DataStorageHandler.SaveChanges();
                FilmprogrammaBeheren.Overzicht(HuidigOfToekomstig);
            }
        }

        public static void verwijderen(string HuidigOfToekomstig)
        {
            Console.Clear();

            string nTitel = Beheer.Input("Welke film wilt u verwijderen? (VOER EXACT TITEL IN) \n");

            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (nTitel == filmItem.Titel)
                {
                    DataStorageHandler.Storage.Films.Remove(filmItem);
                    break;
                }
            }

            FilmprogrammaBeheren.filmprogrammaBeheren();
        }
    }
}
