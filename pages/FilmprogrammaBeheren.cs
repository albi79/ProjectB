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
                Console.WriteLine("U bevindt nu bij de Huidige Films overzicht\n\n");

                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{filmItem.Leeftijd}+   {filmItem.Titel}\n      {filmItem.Categorie}");
                    Console.ResetColor();
                    Console.Write("Film beoordeling: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{filmItem.Beoordeling}");
                    Console.ResetColor();
                    Console.Write($" van de {filmItem.AantalBeoordelingen} beoordelingen\n\n"); ;
                }

                Console.WriteLine("\n1. Film toevoegen");
                Console.WriteLine("2. Film verwijderen");
                Console.WriteLine("3. Film wijzigen");
            }
            else
            {
                Console.WriteLine("U bevindt nu bij de Toekomstige Films overzicht\n\n");

                foreach (ToekomstigeFilm filmItem in DataStorageHandler.Storage.ToekomstigeFilms)
                {
                    Console.WriteLine($"{filmItem.Leeftijd}+   {filmItem.Titel}\n      {filmItem.Categorie}\n"); ;
                }

                Console.WriteLine("\n1. Film toevoegen");
                Console.WriteLine("2. Film verwijderen");
                Console.WriteLine("3. Film wijzigen");
            }



            Console.WriteLine("\n");
            string gegeven = Beheer.Input("");

            if (gegeven == "1")
                toevoegen(HuidigOfToekomstig);


            else if (gegeven == "2")
                verwijderen(HuidigOfToekomstig);

            //WIJZIGEN NOG NIET KUNNEN SAMENVOEGEN(DANI & NISA)
            else if (gegeven == "3")
            {
                Console.Clear();
                Console.WriteLine("Film info bewerken\n\nWelke film wilt u wijzigen:\n");
                if (HuidigOfToekomstig == "HuidigeFilms")
                {
                    //loop door de lijst
                    int filmNummer = 1;
                    foreach (Film filmItem in DataStorageHandler.Storage.Films)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n------------------ Film nummer {filmNummer} ------------------");
                        Console.ResetColor();
                        Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}");
                        Console.Write("Film beoordeling: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{filmItem.Beoordeling}");
                        Console.ResetColor();
                        Console.Write($" van de {filmItem.AantalBeoordelingen} beoordelingen\n\n"); filmNummer++;
                    }
                }
                if (HuidigOfToekomstig == "ToekomstigeFilms")
                {
                    //loop door de lijst
                    int filmNummer = 1;
                    foreach (ToekomstigeFilm filmItem in DataStorageHandler.Storage.ToekomstigeFilms)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n------------------ Film nummer {filmNummer} ------------------");
                        Console.ResetColor();
                        Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n     Release datum: {filmItem.Release}");
                        filmNummer++;
                    }
                }


                int selectedFilm = Int32.Parse(Beheer.Input("\n")) - 1;
                filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);

            }
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

        public static bool inputCheck(string wat)
        {
            Console.Clear();
            Console.WriteLine("Klopt de nieuwe informatie die u wilt toevoegen?");
            Console.WriteLine();
            Console.WriteLine(wat);
            Console.WriteLine("\n1. Ja\n2. Annuleren");

            string antwoord = Beheer.Input();

            if (antwoord == "1")
                return true;
            if (antwoord == "2")
                return false;

            Console.Clear();
            Console.WriteLine("Er ging iets fout");
            Console.WriteLine();
            Console.WriteLine("Wilt u deze informatie definitief aan de film informatie toevoegen?");
            Console.WriteLine();
            Console.WriteLine(wat);
            Console.WriteLine("\n1. Ja\n2. Annuleren");

            antwoord = Beheer.Input();

            if (antwoord == "1")
                return true;
            else if (antwoord == "2")
                return false;
            else
                inputCheck(wat);

            return false;
        }
        public static void filmInfoWijzigen(string HuidigOfToekomstig, int selectedFilm)
        {
            Console.Clear();

            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                Console.WriteLine("Informatie geselecteerde film\n\nWelke informatie wilt u veranderen:\n");
                Console.WriteLine();
                Console.WriteLine("1: Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
                Console.WriteLine("2: Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
                Console.WriteLine("3: Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
                Console.WriteLine("4: Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
                Console.WriteLine("5: Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment);
                Console.WriteLine("6: Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
                Console.WriteLine("7: Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
                Console.WriteLine("8: Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
                Console.WriteLine("9: Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);
                Console.WriteLine("10: Zaal: " + DataStorageHandler.Storage.Films[selectedFilm].Zaal);
                Console.WriteLine();
                Console.WriteLine("0. Terug naar filmprogramma beheren");

                string infoIndex = Beheer.Input("");
                bool correctAntwoord = infoIndex == "1" || infoIndex == "2" || infoIndex == "3" || infoIndex == "4" || infoIndex == "5" || infoIndex == "6" || infoIndex == "7" || infoIndex == "8" || infoIndex == "9";

                if (infoIndex == "1")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe titel: ");

                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Titel = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "2")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe categorie: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Categorie = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);

                }

                else if (infoIndex == "3")
                {
                    int nieuweInfo = 0;

                    try { nieuweInfo = Int32.Parse(Beheer.Input("Wat is de nieuwe minimale leeftijd: ")); }
                    catch
                    {
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                    }

                    DataStorageHandler.Storage.Films[selectedFilm].Leeftijd = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }

                else if (infoIndex == "4")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe beschrijving: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Beschrijving = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);

                }

                else if (infoIndex == "5")
                {
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
                    DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment = nProjectiemoment;
                }

                else if (infoIndex == "6")
                {
                    string nieuweInfo = Beheer.Input("Welke taal is de nieuwe hoofdtaal: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Taal = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "7")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe taal van de ondertiteling: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "8")
                {
                    string nieuweInfo = Beheer.Input("Wie zijn de nieuwe acteurs: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Acteurs = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "9")
                {
                    string nieuweInfo = Beheer.Input("Wie is de nieuwe regisseur: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.Films[selectedFilm].Regisseur = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "10")
                {
                    int nZaal = 0;
                    while (nZaal != 1 && nZaal != 2 && nZaal != 3)
                    {
                        Console.WriteLine("\nIn welke zaal speelt de film?\nZaal 1(IMAX), Zaal 2 (3D) of Zaal 3 (2D)\n");
                        string sZaal = Beheer.Input("Typ 1, 2 of 3: ");
                        try
                        {
                            nZaal = Int32.Parse(sZaal);
                        }
                        catch { Console.WriteLine("Verkeerde zaal input!\nTyp Enter"); Beheer.Input(); }
                    }
                    DataStorageHandler.Storage.Films[selectedFilm].Zaal = nZaal;
                }

                else if (infoIndex == "0")
                {
                    DataStorageHandler.SaveChanges();
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                if (!correctAntwoord)
                    filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
            }
            if (HuidigOfToekomstig == "ToekomstigeFilms")
            {
                Console.WriteLine("Informatie geselecteerde film\n\nWelke informatie wilt u veranderen:\n");
                Console.WriteLine();
                Console.WriteLine("1: Titel: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Titel);
                Console.WriteLine("2: Categorie: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Categorie);
                Console.WriteLine("3: Minimum leeftijd: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd);
                Console.WriteLine("4: Beschrijving: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Beschrijving);
                Console.WriteLine("5: Release: " + DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Release);
                Console.WriteLine();
                Console.WriteLine("0. Terug naar filmprogramma beheren");

                string infoIndex = Beheer.Input("");
                bool correctAntwoord = infoIndex == "1" || infoIndex == "2" || infoIndex == "3" || infoIndex == "4" || infoIndex == "5" || infoIndex == "6" || infoIndex == "7" || infoIndex == "8" || infoIndex == "9";

                if (infoIndex == "1")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe titel: ");

                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Titel = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "2")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe categorie: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Categorie = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);

                }

                else if (infoIndex == "3")
                {
                    int nieuweInfo = 0;

                    try { nieuweInfo = Int32.Parse(Beheer.Input("Wat is de nieuwe minimale leeftijd: ")); }
                    catch
                    {
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                    }

                    DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Leeftijd = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }

                else if (infoIndex == "4")
                {
                    string nieuweInfo = Beheer.Input("Wat is de nieuwe beschrijving: ");
                    if (inputCheck(nieuweInfo))
                    {
                        DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Beschrijving = nieuweInfo;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);

                }

                else if (infoIndex == "10")
                {
                    string nRelease = Beheer.Input("Wat is de nieuwe Release datum: ");
                    string datum = Beheer.Input("");
                    if (datum.Length != 10)
                    {
                        Console.WriteLine("Verkeerde input!\nTyp Enter");
                    }
                    while (datum.Length != 10)
                    {
                        datum = Beheer.Input("");
                        if (datum.Length == 10)
                        {
                            Console.WriteLine("Verkeerde input!\nTyp Enter");

                        }
                    }
                    if (inputCheck(nRelease))
                    {
                        DataStorageHandler.Storage.ToekomstigeFilms[selectedFilm].Beschrijving = nRelease;
                        FilmprogrammaBeheren.filmprogrammaBeheren();
                    }
                    else
                        filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
                }

                else if (infoIndex == "0")
                {
                    DataStorageHandler.SaveChanges();
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                if (!correctAntwoord)
                    filmInfoWijzigen(HuidigOfToekomstig, selectedFilm);
            }

        }

        public static void verwijderen(string HuidigOfToekomstig)
        {
            Console.Clear();

            string nTitel = Beheer.Input("Welke film wilt u verwijderen? (VOER EXACT TITEL IN) \n");

            if (HuidigOfToekomstig == "HuidigeFilms")
            {
                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                {
                    if (nTitel == filmItem.Titel)
                    {
                        DataStorageHandler.Storage.Films.Remove(filmItem);
                        DataStorageHandler.SaveChanges();
                        break;
                    }
                }
            }
            else
            {
                foreach (ToekomstigeFilm toekomstigeFilm in DataStorageHandler.Storage.ToekomstigeFilms)
                {
                    if (nTitel == toekomstigeFilm.Titel)
                    {
                        DataStorageHandler.Storage.ToekomstigeFilms.Remove(toekomstigeFilm);
                        DataStorageHandler.SaveChanges();
                        break;
                    }
                }
            }

            FilmprogrammaBeheren.filmprogrammaBeheren();
        }
    }
}