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
                    string nProjectie = Beheer.Input("Wat voor projectie heeft de film? (2D/3D/IMAX)\n");
                    string nTaal = Beheer.Input("Wat is de Hoofdtaal van de film?\n");
                    string nOndertiteling = Beheer.Input("In welke taal is de ondertiteling?\n");
                    string nActeurs = Beheer.Input("Welke grote acteurs spelen in de film?\n");
                    string nRegisseur = Beheer.Input("Wie is de regiseur van de film?\n");
                    Film nieuweFilm = new Film
                    {
                        Titel = nTitel,
                        Categorie = nCategorie,
                        Leeftijd = nLeeftijd,
                        Beschrijving = nBeschrijving,
                        Projectie = nProjectie,
                        Taal = nTaal,
                        Ondertiteling = nOndertiteling,
                        Acteurs = nActeurs,
                        Regisseur = nRegisseur,
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