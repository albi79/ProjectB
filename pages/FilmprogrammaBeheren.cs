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
            Console.WriteLine("Beheer filmprogramma\n");
            Console.WriteLine("1. Film toevoegen");
            Console.WriteLine("2. Film verwijderen");
            Console.WriteLine("3. Film info wijzigen");
            Console.WriteLine("\nDit zijn de huidige films die in het programma voortkomen:\n(Titel - Categorie - Leeftijd)\n-------------------------------------------");

            //loop door de lijst
            foreach (Film filmItem in DataStorageHandler.Storage.Films)
            {
                //consolewriteline voor elke item in de list
                Console.WriteLine(filmItem.Titel + " - " + filmItem.Categorie + " - " + filmItem.Leeftijd);
            }

            int gegeven = 0;
            while (gegeven != 1 && gegeven != 2 && gegeven != 3)
            {
                string sGegeven = Beheer.Input("");
                try
                {
                    gegeven = Int32.Parse(sGegeven);
                }
                catch { Console.WriteLine("Verkeerde input!\nTyp Enter"); Beheer.Input(); filmprogrammaBeheren(); }
            }


            if (gegeven == 1)
            {
                Console.Clear();
                string nTitel = Beheer.Input("Wat is de titel van de nieuwe film?\n");
                string nCategorie = Beheer.Input("\nWat is de categorie van de nieuwe film?\n");
                int nLeeftijd = Convert.ToInt32(Beheer.Input("\nWat is de minimum leeftijd van de nieuwe film?\n"));
                string nBeschrijving = Beheer.Input("\nSchrijf een korte filmbeschrijving\n");
                //string nProjectie = Beheer.Input("\nWat voor projectie heeft de film? (2D/3D/IMAX)\n");
                string nTaal = Beheer.Input("\nWat is de hoofdtaal van de film?\n");
                string nOndertiteling = Beheer.Input("\nIn welke taal is de ondertiteling?\n");
                string nActeurs = Beheer.Input("\nWelke grote acteurs spelen in de film?\n");
                string nRegisseur = Beheer.Input("\nWie is de regiseur van de film?\n");
                
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
                int hoeveelTijden = Int32.Parse(Beheer.Input("\nHoe vaak wordt de film op een dag gedraaid? "));
                string[] nTijd = new string[hoeveelTijden];
                for (int i = 0; i < hoeveelTijden; i++)
                {
                    Console.WriteLine($"\nOp welk tijdstip begint de {i + 1}e projectie (HH:MM) ?");
                    nTijd[i] = Beheer.Input("");
                }

                string nData = Beheer.Input("\nOp welke data/datum draait de film?\n");
        
                
                //TODO: FOUTMELDING

                Film nieuweFilm = new Film
                {
                    Titel = nTitel,
                    Categorie = nCategorie,
                    Leeftijd = nLeeftijd,
                    Beschrijving = nBeschrijving,
                    //Projectie = nProjectie,
                    Taal = nTaal,
                    Ondertiteling = nOndertiteling,
                    Acteurs = nActeurs,
                    Regisseur = nRegisseur,
                    Zaal = nZaal,
                    Tijd = nTijd,
                    Data = nData,
                };

                DataStorageHandler.Storage.Films.Add(nieuweFilm);
                DataStorageHandler.SaveChanges();
                FilmprogrammaBeheren.filmprogrammaBeheren();
            }

            else if(gegeven == 2)
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

            else if(gegeven == 3)
            {
                Console.Clear();
                Console.WriteLine("Film info bewerken\n\nWelke film wilt u wijzigen:\n");
                
                int filmNummer = 1;
                foreach (var film in DataStorageHandler.Storage.Films)
                {
                    Console.WriteLine($"{filmNummer}: {film.Titel}");
                    filmNummer++;
                }
                int selectedFilm = Int32.Parse(Beheer.Input("\n")) -1;
                
                try
                {
                    FilmInfoWijzigen.filmInfoWijzigen(selectedFilm);
                }
                catch
                {
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
            }
        }
    }
}