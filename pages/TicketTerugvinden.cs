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
                    Console.ResetColor();
                    Console.WriteLine("\nFilmtitel: " + reservation.ID);

                    Console.WriteLine("Zaal: " + reservation.Zaal);
                    Console.WriteLine("Projectie: ");
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
                        Console.WriteLine("Projectie: €" + totalseatprice + ",-");
                    else if (totalseatprice == Math.Round(totalseatprice, 1))
                        Console.WriteLine("Projectie: €" + totalseatprice + "0");
                    else
                        Console.WriteLine("Projectie: €" + totalseatprice);
                    Console.WriteLine("Snack: " + reservation.Snack + "\n--");
                }
            }
            Console.WriteLine("\n\nDruk b om terug te gaan.");
            string Select = Beheer.Input("");
            if (Select == "b")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Er ging iets verkeerd!\n");
                ticketTerugvinden(gebruikersnaam);
            }
        }
    }
}