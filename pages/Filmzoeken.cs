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
        public static void optitel()
        {
            Console.Clear();
            string titel = Beheer.Input("\nVoer de titel van de film in.(VOER ÉÉN OF TWEE WOORDEN IN VOOR BEST RESULTAAT)\n").ToLower();
            int filmNummer = 1;
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Titel.ToLower().Contains(titel))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n\n");
                }
                filmNummer++;
            }
        }
        public static void opleeftijd()
        {
            Console.Clear();
            //omdat het intparse heeft moet er nog een foutmelding gemaakt worden voor de intparse
            int leeftijd = Int32.Parse(Beheer.Input("\nWat moet de minimale leeftijd van de films zijn?(VOER EEN GETAL IN)\n"));
            int filmNummer = 1;
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Leeftijd >= leeftijd)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n\n");
                }
                filmNummer++;
            }
        }
        public static void opgenre()
        {
            Console.Clear();
            string categorie = Beheer.Input("\nWat moet de genre van de film zijn?\n").ToLower();
            int filmNummer = 1;
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                if (filmItem.Categorie.ToLower().Contains(categorie))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"------------------ Film nummer {filmNummer} ------------------");
                    Console.ResetColor();
                    Console.WriteLine($"     {filmItem.Leeftijd}+     {filmItem.Titel}\n     {filmItem.Categorie}\n\n");
                }
                filmNummer++;
            }
        }
    }
}
