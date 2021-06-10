using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.Classes.Seats;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class VeranderTicket
    {
        public static void veranderTicket(string gebruikersnaam, string keuze, int ticketIndex)
        {
            if (keuze == "0")
            {
                Console.Clear();
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }
            else if (keuze == "1")
            {
                Console.WriteLine($"U heeft nu {DataStorageHandler.Storage.Reservations[ticketIndex].Snack} als snack geselecteerd, naar wat wilt u dit veranderen?\n0. Wijzeging annuleren\n1. Popcorn zoet\n2. Popcorn zout\n3.Popcorn mix\n4. Groot Popcorn zoet\n5. Groot Popcorn zout\n6. Groot Popcorn mix\n7. Geen");
                string snackKeuze = Beheer.Input("");
                if (snackKeuze == "0")
                { 
                    Console.Clear();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "1")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zoet";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 3.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "2")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zout";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 3.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "3")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Mix";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 3.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "4")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Groot Popcorn Zoet";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 7.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "5")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Groot Popcorn Zout";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 7.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "6")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Groot Popcorn Mix";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 7.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "7")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Geen";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 0;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    Console.ResetColor();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
            }
            else if (keuze == "2")
            {
                int filmIndex = 0;
                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                    if (DataStorageHandler.Storage.Reservations[ticketIndex].Filmtitel == filmItem.Titel)
                        filmIndex = DataStorageHandler.Storage.Films.IndexOf(filmItem);

                int teller = 0;
                int datumIndexTeller = 0;

                Console.WriteLine("Kies uw nieuwe datum:\n");

                foreach (var projectiemoment in DataStorageHandler.Storage.Films[filmIndex].Projectiemoment)
                {
                    bool geweest = true;
                    string datum = projectiemoment[0];
                    int dag = Int32.Parse($"{datum[0]}{datum[1]}");
                    int maand = Int32.Parse($"{datum[3]}{datum[4]}");
                    int jaar = Int32.Parse($"{datum[6]}{datum[7]}{datum[8]}{datum[9]}");

                    if (jaar < DateTime.Now.Year)
                    {
                        geweest = false;
                    }
                    else if (jaar > DateTime.Now.Year)
                    {
                        geweest = true;
                    }
                    else
                    {
                        if (maand < DateTime.Now.Month)
                        {
                            geweest = true;
                        }
                        else if (maand > DateTime.Now.Month)
                        {
                            geweest = false;
                        }
                        else
                        {
                            if (dag <= DateTime.Now.Day)
                            {
                                geweest = true;
                            }
                            if (dag > DateTime.Now.Day)
                            {
                                geweest = false;
                            }
                        }
                    }

                    if (geweest == false)
                    {
                        Console.WriteLine($"{teller + 1}. {datum}\n");
                        teller++;
                    }
                    else
                        datumIndexTeller++;
                }

                if (teller == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Er zijn geen andere data beschikbaar!!!\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }

                int outerIndex = 0;

                try {
                    outerIndex = Int32.Parse(Beheer.Input("Welke datum wilt u selecteren? "));
                    if (outerIndex > teller + 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Er ging iets fout!");
                        Console.ResetColor();
                        VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er ging iets fout!");
                    Console.ResetColor();
                    VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex);
                }

                Console.WriteLine("\nKies uw nieuwe tijd:");

                int teller2 = 1;
                for (int i = 0; i < DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1].Length - 1; i++, teller2++)
                    Console.WriteLine($"\n{teller2}. {DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1][i + 1]}");

                int innerIndex = 0;

                try
                {
                    innerIndex = Int32.Parse(Beheer.Input("\nWelk tijdstip wilt u selecteren "));
                    if (innerIndex > teller2)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Er ging iets fout!");
                        Console.ResetColor();
                        VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er ging iets fout!");
                    Console.ResetColor();
                    VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex);
                }

                DataStorageHandler.Storage.Reservations[ticketIndex].Datum = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1][0];
                DataStorageHandler.Storage.Reservations[ticketIndex].Tijd = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1][innerIndex];
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                Console.ResetColor();
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }

        }
    }
}