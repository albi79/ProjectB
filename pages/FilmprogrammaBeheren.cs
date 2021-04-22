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
            Console.Clear();
            Console.WriteLine("1. Film toevoegen");
            Console.WriteLine("2. Film verwijderen");
            Console.WriteLine("Dit zijn de huidige films die in het programma voortkomen:\n(Titel - Categorie - Leeftijd)\n-------------------------------------------");

            //loop door de lijst
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                //consolewriteline voor elke item in de list
                Console.WriteLine(filmItem.Titel + " - " + filmItem.Categorie + " - " + filmItem.Leeftijd);
            }

            string gegeven = Beheer.Input("");

            if(gegeven == "1")
            {
                Console.Clear();
                string nTitel = Beheer.Input("Wat is de titel van de nieuwe film?\n");
                string nCategorie = Beheer.Input("Wat is de categorie van de nieuwe film?\n");
                int nLeeftijd = Convert.ToInt32(Beheer.Input("Wat is de minimum leeftijd van de nieuwe film?\n"));

                //TODO: FOUTMELDING

                Film nieuweFilm = new Film
                {
                    Titel = nTitel,
                    Categorie = nCategorie,
                    Leeftijd = nLeeftijd
                };

                DataStorageHandler.Storage.Films.Add(nieuweFilm);
                DataStorageHandler.SaveChanges();
                FilmprogrammaBeheren.filmprogrammaBeheren();
            }

            else if(gegeven == "2")
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
}