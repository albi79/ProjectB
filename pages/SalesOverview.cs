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
    class SalesOverview
    {
        public static void salesOverview()
        {
            Console.WriteLine("Welkom bij de Sales Overview!\n");

            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"Reservering ID {reservation.ID}:");
                Console.ResetColor();

                double currenttotalseatprice = 0.0;

                for (int i = 0; i < reservation.Seats.Count; i++)
                {
                    currenttotalseatprice += reservation.Seats[i].Price;
                }

                if (currenttotalseatprice == (int)currenttotalseatprice)
                    Console.Write($"   €{currenttotalseatprice},-     {reservation.Customer} \n");
                else if (currenttotalseatprice == Math.Round(currenttotalseatprice, 1))
                    Console.Write($"   €{currenttotalseatprice}0    {reservation.Customer} \n");
                else
                    Console.Write($"   €{currenttotalseatprice}    {reservation.Customer} \n");
            }
            Console.WriteLine("\nWelk ID wilt u selecteren?\nDruk b om terug te gaan.");
            string Select = Beheer.Input("");
            int SelectSale = 0;
            if (Select == "b")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else
            {
                try
                {
                    SelectSale = Int32.Parse(Select);
                    
                }
                catch
                {
                    Console.WriteLine("Verkeerde input!\n\nTyp Enter"); Beheer.Input(); salesOverview();
                }
            }
            bool TicketGevonden = false;
            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
            {
                if (Select == reservation.ID) {
                    TicketGevonden = true;
                    foreach (Film film in DataStorageHandler.Storage.Films)
                    {
                        if (film.Titel == reservation.Filmtitel)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nFilmgegevens: ");
                            Console.ResetColor();
                            Console.WriteLine("     Titel: " + film.Titel);
                            Console.WriteLine("     Categorie: " + film.Categorie);
                            Console.WriteLine("     Minimum leeftijd: " + film.Leeftijd);
                            Console.WriteLine("     Beschrijving: " + film.Beschrijving);
                            Console.WriteLine("     Taal: " + film.Taal);
                            Console.WriteLine("     Ondertiteling: " + film.Ondertiteling);
                            Console.WriteLine("     Acteurs: " + film.Acteurs);
                            Console.WriteLine("     Regiseur: " + film.Regisseur);
                        }
                    }

                    string CustomerUsername = reservation.Customer;
                    foreach (Person person in DataStorageHandler.Storage.Persons)
                    {
                        if (CustomerUsername == person.gebruikersnaam)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nKlant gegevens: ");
                            Console.ResetColor();
                            Console.WriteLine("     Naam: " + person.naam);
                            Console.WriteLine("     Tussenvoegsel: " + person.tussenvoegsel);
                            Console.WriteLine("     Achternaam: " + person.achternaam);
                            Console.WriteLine("     Gebruikersnaam: " + person.gebruikersnaam);
                            Console.WriteLine("     Geboortedatum: " + person.geboortedatum);
                            Console.WriteLine("     E-mail: " + person.email);
                            break;
                        }
                    }
                    Console.WriteLine("\nDatum: " + reservation.Datum);
                    Console.WriteLine("Tijd: " + reservation.Tijd);
                    Console.WriteLine("Zaal: " + reservation.Zaal);
                    Console.WriteLine("Projectie: " + reservation.Projectie);
                    Console.WriteLine("Rij: " + reservation.Seats[0].Rij);


                    string selectedseatListColumn = "";
                    double totalseatprice = 0.0;

                    for (int i = 0; reservation.Seats.Count > i; i++)
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

                    Console.WriteLine("Snack: " + reservation.Snack);
                }
            }
            if (TicketGevonden == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er is geen ticket gevonden met deze ID!");
                Console.ResetColor();
                SalesOverview.salesOverview();
            }
            Console.WriteLine("\nb. Terug");
            Console.WriteLine("1. Ticket wijzigen");
            Console.WriteLine("2. Ticket verwijderen");
            string userInput = Beheer.Input("");
            bool backingoption = false;
            while (backingoption == false)
            {
                if (userInput == "b")
                {
                    Console.Clear();
                    SalesOverview.salesOverview();
                    backingoption = true;
                }
                else if (userInput == "1")
                {
                    AdminTicketWijzigen.adminTicketWijzigen(Select);
                    backingoption = true;
                }
                else if (userInput == "2")
                {
                    AdminTicketWijzigen.adminTicketVerwijderen(Select);
                    backingoption = true;
                }
                else
                {
                    Console.WriteLine("\nFOUTMELDING: er is een ongeldige toets ingevoerd. Maak een keuze uit b (terug), 1 (ticket wijzigen) of 2 (ticket verwijderen).");
                    userInput = Beheer.Input("");
                }
            }
        }
    }
}