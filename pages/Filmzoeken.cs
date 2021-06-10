using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class Filmzoeken
    {
        public static void filmzoeken(string gebruikersnaam)
        {
            Console.WriteLine("Welkom bij film zoeken\n\nGeef aan op wat je wilt zoeken:\n\n1. Filmtitel\n2. Minimum film leeftijd\n3. Op genre\nb. Terug\n\n");
            string zoekenOp = Beheer.Input("");
            bool zoekenOpInput = false;
            while(zoekenOpInput == false)
            {
                if (zoekenOp == "b")
                {
                    zoekenOpInput = true;
                    FilmSelect.Overzicht("HuidigeFilms", gebruikersnaam);
                }
                else if (zoekenOp == "1")
                {
                    zoekenOpInput = true;
                    optitel(gebruikersnaam);
                }
                else if(zoekenOp == "2")
                {
                    zoekenOpInput = true;
                    opleeftijd(gebruikersnaam);
                }
                else if (zoekenOp == "3")
                {
                    zoekenOpInput = true;
                    opgenre(gebruikersnaam);
                }
            }

        }
        public static void optitel(string gebruikersnaam)
        {
            Console.Clear();
            string titel = Beheer.Input("\nVoer de titel van de film in.(VOER ÉÉN OF TWEE WOORDEN IN VOOR BEST RESULTAAT)\n").ToLower();
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Titel.ToLower().Contains(titel))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film Titel {filmItem.Titel} ------------------");
                    Console.ResetColor();
                    Console.WriteLine("Categorie: " + filmItem.Categorie);
                    Console.WriteLine("Minimum leeftijd: " + filmItem.Leeftijd);
                    Console.WriteLine("Beschrijving: " + filmItem.Beschrijving);
                    Console.WriteLine("Taal: " + filmItem.Taal);
                    Console.WriteLine("Ondertiteling: " + filmItem.Ondertiteling);
                    Console.WriteLine("Acteurs: " + filmItem.Acteurs);
                    Console.WriteLine("Regisseur: " + filmItem.Regisseur + "\n\n");
                }
            }
            string input = Beheer.Input("Druk enter om terug te gaan ");
            Console.Clear();
            FilmSelect.Overzicht("HuidigeFilms", gebruikersnaam);
        }
        public static void opleeftijd(string gebruikersnaam)
        {
            Console.Clear();
            int leeftijd = Int32.Parse(Beheer.Input("\nWat moet de minimale leeftijd van de films zijn?(VOER EEN GETAL IN)\n"));
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Leeftijd >= leeftijd)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film Titel {filmItem.Titel} ------------------");
                    Console.ResetColor();
                    Console.WriteLine("Categorie: " + filmItem.Categorie);
                    Console.WriteLine("Minimum leeftijd: " + filmItem.Leeftijd);
                    Console.WriteLine("Beschrijving: " + filmItem.Beschrijving);
                    Console.WriteLine("Taal: " + filmItem.Taal);
                    Console.WriteLine("Ondertiteling: " + filmItem.Ondertiteling);
                    Console.WriteLine("Acteurs: " + filmItem.Acteurs);
                    Console.WriteLine("Regisseur: " + filmItem.Regisseur + "\n\n");
                }
            }
            string input = Beheer.Input("Druk enter om terug te gaan ");
            Console.Clear();
            FilmSelect.Overzicht("HuidigeFilms", gebruikersnaam);
        }
        public static void opgenre(string gebruikersnaam)
        {
            Console.Clear();
            string categorie = Beheer.Input("\nWat moet de genre van de film zijn?\n").ToLower();
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Categorie.ToLower().Contains(categorie))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film Titel {filmItem.Titel} ------------------");
                    Console.ResetColor();
                    Console.WriteLine("Categorie: " + filmItem.Categorie);
                    Console.WriteLine("Minimum leeftijd: " + filmItem.Leeftijd);
                    Console.WriteLine("Beschrijving: " + filmItem.Beschrijving);
                    Console.WriteLine("Taal: " + filmItem.Taal);
                    Console.WriteLine("Ondertiteling: " + filmItem.Ondertiteling);
                    Console.WriteLine("Acteurs: " + filmItem.Acteurs);
                    Console.WriteLine("Regisseur: " + filmItem.Regisseur + "\n\n");
                }
            }
            string input = Beheer.Input("Druk enter om terug te gaan ");
            Console.Clear();
            FilmSelect.Overzicht("HuidigeFilms", gebruikersnaam);
        }
    }
}
