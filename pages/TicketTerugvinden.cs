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
                    Console.WriteLine("Rij: " + reservation.Seats.Rij);
                    Console.WriteLine("Stoelnumer: " + reservation.Seats.Column);
                    if (reservation.Seats.Price == (int)reservation.Seats.Price)
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price + ",-");
                    else if (reservation.Seats.Price == Math.Round(reservation.Seats.Price, 1))
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price + "0");
                    else
                        Console.WriteLine("Projectie: €" + reservation.Seats.Price);

                    Console.WriteLine("Snack: " + reservation.Snack);
                    Console.Write("-- Typ ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(reservation.ID);
                    Console.ResetColor();
                    Console.Write(" om deze film te beoordelen\n");
                }
            }
            Console.WriteLine("\n\nTyp de kaart ID om een film te beoordelen");
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
                    int Select2 = 0;
                    Select2 = Int32.Parse(Select);

                    foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                    {
                        if (Select == reservation.ID && gebruikersnaam == reservation.Customer)
                        {
                            Beoordeling.beoordeling(Select2, gebruikersnaam);
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Er ging iets verkeerd!\n");
                    ticketTerugvinden(gebruikersnaam);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Er ging iets verkeerd!\n");
                    ticketTerugvinden(gebruikersnaam);
                }
            }
        }
    }
}