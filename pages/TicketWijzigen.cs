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
    class TicketWijzigen
    {
        public static void ticketWijzigen(string gebruikersnaam, int ticketIndex)
        {

            Console.WriteLine("\n1. ticket wijzigen\n2. ticket annuleren\n0. Terug");
            string optie = Beheer.Input("");

            if (optie == "1")
            {
                Console.Clear();
                Console.WriteLine("Wat wilt u aan uw ticket veranderen\n1. Snacks\n2. Datum / Tijd\n0. Terug\n");
                string veranderInput = Beheer.Input("");

                if (veranderInput == "0" || veranderInput == "1" || veranderInput == "2")
                {
                    Console.Clear();
                    VeranderTicket.veranderTicket(gebruikersnaam, veranderInput, ticketIndex);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Er gaat iets fout, probeer het opnieuw\n");
                    Console.ResetColor();
                    ticketWijzigen(gebruikersnaam, ticketIndex);
                }
            }
            else if (optie == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nWeet u zeker dat u de ticket permanent wilt annuleren?");
                Console.ResetColor();
                Console.WriteLine("1. JA\n2. NEE");
                string inp = Beheer.Input("");
                if (inp == "1")
                {
                    Console.Clear();
                    DataStorageHandler.Storage.Reservations.RemoveAt(ticketIndex);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nUw ticket is succesvol verwijdert.\n");
                    Console.ResetColor();
                    DataStorageHandler.SaveChanges();

                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else
                {
                    Console.Clear();
                    ticketWijzigen(gebruikersnaam, ticketIndex);
                }
            }
            else if (optie == "0")
            {
                Console.Clear();
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Foutieve Input, probeer opnieuw\n");
                Console.ResetColor();
                ticketWijzigen(gebruikersnaam, ticketIndex);
            }
        }
    }
}