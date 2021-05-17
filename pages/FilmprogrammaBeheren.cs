﻿using System;
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

            string gegeven = Beheer.Input("");

            if(gegeven == "1")
            {
                Console.Clear();
                string nTitel = Beheer.Input("Wat is de titel van de nieuwe film?\n");
                string nCategorie = Beheer.Input("Wat is de categorie van de nieuwe film?\n");
                int nLeeftijd = Convert.ToInt32(Beheer.Input("Wat is de minimum leeftijd van de nieuwe film?\n"));
                string nBeschrijving = Beheer.Input("Schrijf een korte filmbeschrijving\n");
                string nProjectie = Beheer.Input("Wat voor projectie heeft de film? (2D/3D/IMAX)\n");
                string nTaal = Beheer.Input("Wat is de hoofdtaal van de film?\n");
                string nOndertiteling = Beheer.Input("In welke taal is de ondertiteling?\n");
                string nActeurs = Beheer.Input("Welke grote acteurs spelen in de film?\n");
                string nRegisseur = Beheer.Input("Wie is de regiseur van de film?\n");
                string nZaal = Beheer.Input("In welke zaal speelt de film?\n");
                string nTijd = Beheer.Input("Op welk tijdstip is de projectie?\n");
                string nData = Beheer.Input("Op welke data/datum draait de film?\n");
        //TODO: FOUTMELDING

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
                    Zaal = nZaal,
                    Tijd = nTijd,
                    Data = nData,
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

            else if(gegeven == "3")
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