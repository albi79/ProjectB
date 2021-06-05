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
    class TicketTerugvinden
    {
        public static void ticketTerugvinden(string gebruikersnaam)
        {
            Console.Write($"Welkom bij uw Ticket geschiedenis, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{gebruikersnaam}\n");
            Console.ResetColor();
            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
            {
                if (gebruikersnaam == reservation.Customer)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write($"\nReservering ID {reservation.ID}:");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\nFilmgegevens:");
                    

                    foreach (Film film in DataStorageHandler.Storage.Films)
                    {
                        if(film.Titel == reservation.Filmtitel)
                        {
                            Console.WriteLine("- Titel: " + film.Titel);
                            Console.WriteLine("- Categorie: " + film.Categorie);
                            Console.WriteLine("- Minimum leeftijd: " + film.Leeftijd);
                            Console.WriteLine("- Beschrijving: " + film.Beschrijving);
                            Console.WriteLine("- Taal: " + film.Taal);
                            Console.WriteLine("- Ondertiteling: " + film.Ondertiteling);
                            Console.WriteLine("- Acteurs: " + film.Acteurs);
                            Console.WriteLine("- Regiseur: " + film.Regisseur);
                        }
                    }
                    Console.ResetColor();
                    Console.WriteLine("Datum: " + reservation.Datum);
                    Console.WriteLine("Tijd: " + reservation.Tijd);
                    Console.WriteLine("Projectie: " + reservation.Projectie);
                    Console.WriteLine("Zaal: " + reservation.Zaal);
                    Console.WriteLine("Rij: " + reservation.Seats[0].Rij);

                    string selectedseatListColumn = "";
                    double totalseatprice = 0.0;

                    for (int i = 0; i < reservation.Seats.Count; i++)
                    {
                        if (reservation.Seats.Count > i + 1)
                        {
                            selectedseatListColumn += reservation.Seats[i].Column + ", ";
                        }
                        else
                        {
                            selectedseatListColumn += reservation.Seats[i].Column;
                        }
                        totalseatprice += reservation.Seats[i].Price;
                    }
                    Console.WriteLine("Stoelnummer(s): " + selectedseatListColumn);
                    if (totalseatprice == (int)totalseatprice)
                        Console.WriteLine("Totaal prijs: €" + totalseatprice + ",-");
                    else if (totalseatprice == Math.Round(totalseatprice, 1))
                        Console.WriteLine("Totaal prijs: €" + totalseatprice + "0");
                    else
                        Console.WriteLine("Totaal prijs: €" + totalseatprice);
                    Console.WriteLine("Snack: " + reservation.Snack + "");
                    if (filmAfgelopen(gebruikersnaam, Int32.Parse(reservation.ID)) == "afgelopen")
                    {
                        Console.Write("-- Typ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(reservation.ID);
                        Console.ResetColor();
                        Console.Write(" om deze film te beoordelen");
                    }
                    else if(filmAfgelopen(gebruikersnaam, Int32.Parse(reservation.ID)) == "wijzigbaar")
                    {
                        Console.Write("-- Typ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(reservation.ID);
                        Console.ResetColor();
                        Console.Write(" om de reservering te annuleren/bewerken\n   (minimaal 24 uur voordat de film draait).");
                    }
                    else
                    {
                        Console.Write("-- Deze film begint binnen 24 uur, mis het niet!");
                    }
                    Console.WriteLine("\n---------------------\n");

                }
            }
            Console.WriteLine("\n\nTyp een kaart ID");
            Console.WriteLine("Druk b om terug te gaan.");
            string Select = Beheer.Input("");
            if (Select == "b")
            {
                Console.Clear();
                ConsoleMenu.consoleMenu(gebruikersnaam);
            }
            else
            {
                try
                {
                    if (filmAfgelopen(gebruikersnaam, Int32.Parse(Select)) == "afgelopen")
                    {
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                        {
                            if (Select == reservation.ID && gebruikersnaam == reservation.Customer)
                            {
                                Beoordeling.beoordeling(gebruikersnaam, Int32.Parse(Select));
                            }
                        }
                    }
                    else if (filmAfgelopen(gebruikersnaam, Int32.Parse(Select)) == "wijzigbaar")
                    {
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                        {
                            if (Select == reservation.ID && gebruikersnaam == reservation.Customer)
                            {
                                TicketWijzigen.ticketWijzigen(gebruikersnaam, Int32.Parse(Select));
                            }
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ze film speelt binnen 24 uur. U kunt deze film niet aanpassen of verwijderen.\n");
                        ticketTerugvinden(gebruikersnaam);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er ging iets verkeerd!\n");
                    Console.ResetColor();
                    ticketTerugvinden(gebruikersnaam);
                }
            }
    }
        public static string filmAfgelopen(string gebruikersnaam, int ticketIndex)
        {
            DateTime moment = DateTime.Now;            

            string afgelopen = "";

            string filmDatum = DataStorageHandler.Storage.Reservations[ticketIndex].Datum;
            string filmDag = $"{filmDatum[0]}{filmDatum[1]}";
            string filmMaand = $"{filmDatum[3]}{filmDatum[4]}";
            string filmJaar = $"{filmDatum[6]}{filmDatum[7]}{filmDatum[8]}{filmDatum[9]}";

            string filmUur = $"{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[0]}{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[1]}";

            int jaar = Int32.Parse(filmJaar);
            int maand = Int32.Parse(filmMaand);
            int dag = Int32.Parse(filmDag);
            int uur = Int32.Parse(filmUur);

            int HuidigeJaar = moment.Year;
            int HuidigeMaand = moment.Month;
            int HuidigeDag = moment.Day;
            int HuidigeUur = moment.Hour;

            if (HuidigeJaar <= jaar)
            {
                if (HuidigeMaand < maand)
                {
                    afgelopen = "wijzigbaar";
                }
                else if (HuidigeMaand == maand)
                {
                    if (HuidigeDag < dag)
                    {
                        if (HuidigeUur > uur)
                        {
                            afgelopen = "";
                        }
                        else
                        {
                            afgelopen = "wijzigbaar";
                        }
                    }
                    else if(HuidigeDag == dag)
                    {
                        if (HuidigeUur > uur)
                        {
                            afgelopen = "afgelopen";
                        }
                        else
                        {
                            afgelopen = "";
                        }
                    }
                    else
                        afgelopen = "afgelopen";
                }
                else
                    afgelopen = "afgelopen";
            }
            else
                afgelopen = "afgelopen";

            return afgelopen;
        }
    }
}