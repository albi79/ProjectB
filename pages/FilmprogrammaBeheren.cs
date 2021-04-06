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
        public static List<Film> films = new List<Film>(); 

        public static void filmprogrammaBeheren()
        {
            bool validinputmenu = false;

            Console.Clear();
            Console.WriteLine("1. Film toevoegen");
            Console.WriteLine("2. Film verwijderen");
            Console.WriteLine("3. Terug naar het menu");
            Console.WriteLine("\n-------------------------------------------\nDit zijn de huidige films die in het programma voortkomen:\n(Titel - Categorie - Leeftijd)\n-------------------------------------------");

            //loop door de lijst
            foreach (Film filmItem in films)
            {
                //consolewriteline voor elke item in de list
                Console.WriteLine(filmItem.Titel + " - " + filmItem.Categorie + " - " + filmItem.Leeftijd);
            }

            string gegeven = Beheer.Input("");

            while (validinputmenu == false)
            {
                if (gegeven == "1")
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

                    films.Add(nieuweFilm);
                    validinputmenu = true;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }

                else if (gegeven == "2")
                {
                    Console.Clear();
                    validinputmenu = true;

                    string nTitel = Beheer.Input("Welke film wilt u verwijderen? (VOER EXACT TITEL IN) \n");

                    foreach (Film filmItem in films)
                    {
                        if (nTitel == filmItem.Titel)
                        {
                            films.Remove(filmItem);
                            break;
                        }
                    }

                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }

                else if (gegeven == "3")
                {
                    Console.Clear();
                    validinputmenu = true;
                    AdminMenu.adminMenu();
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2 of 3");
                    validinputmenu = false;
                }
            }
        }
    }
}