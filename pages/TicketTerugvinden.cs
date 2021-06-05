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

                    Console.WriteLine("Zaal: " + reservation.Hall);
                    Console.WriteLine("Projectie: ");
                    Console.WriteLine("Rij: " + reservation.Seats.Row);
                    Console.WriteLine("Stoelnumer: " + reservation.Seats.Column);
                    if (reservation.Seats.Price == (int)reservation.Seats.Price)
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price + ",-");
                    else if (reservation.Seats.Price == Math.Round(reservation.Seats.Price, 1))
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price + "0");
                    else
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price);

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