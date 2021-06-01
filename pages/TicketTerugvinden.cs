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
            int indexCount = 1;
            int Select = 0;

            Console.Write($"Welkom bij uw Ticket geschiedenis, ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{gebruikersnaam}\n");
            Console.ResetColor();

            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
            {
                if (gebruikersnaam == reservation.Customer)
                {
                    Console.WriteLine($"Ticket nummer: {indexCount}.");
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

                    Console.WriteLine("Snack: " + reservation.Snack + "\n--");
                }
            }

            Console.WriteLine("Wilt u een ticket annuleren/bewerken (minimaal 24 uur voordat de film draait.)    Typ dan het ticket ID in");
            Console.WriteLine("Typ 0 om terug te gaan.");
            try { Select = Int32.Parse(Beheer.Input("")); }
            catch { Console.Clear(); Console.WriteLine("Er ging iets verkeerd!\n"); ticketTerugvinden(gebruikersnaam); }



            int ticketIndex = 0;

            try 
            {
                if (Select == 0)
                {
                    Console.Clear();
                    ConsoleMenu.consoleMenu(gebruikersnaam);
                }

                foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                {
                    if (gebruikersnaam == reservation.Customer)
                        if (Select == Int32.Parse(reservation.ID))
                            ticketIndex = DataStorageHandler.Storage.Reservations.IndexOf(reservation);
                }

                TicketWijzigen.ticketWijzigen(gebruikersnaam, ticketIndex);
            }
            catch { Console.WriteLine("Er ging iets verkeerd!\n"); ticketTerugvinden(gebruikersnaam); }
        }
    }
}