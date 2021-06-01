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
        public static void veranderTicket(string gebruikersnaam, string keuze, int ticketIndex, int indexOfGebruiker)
        {
            if (keuze == "1")
            {
                Console.WriteLine($"U heeft nu {DataStorageHandler.Storage.Reservations[ticketIndex].Snack} als snack geselecteerd, naar wat wilt u dit veranderen?\n1. Popcorn zoet\n2. Popcorn zout\n3. Popcorn mix\n4. Geen\n0. Wijzeging annuleren");
                string snackKeuze = Beheer.Input("");
                if (snackKeuze == "0")
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                else if (snackKeuze == "1")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zoet";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "2")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zout";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "3")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Mix";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else if (snackKeuze == "4")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Geen";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 0;
                    DataStorageHandler.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);                
                }
            }
            //"2" -> datum & tijd veranderen
            else if(keuze == "2")
            {
                int filmIndex = 0;
                foreach (Film filmItem in DataStorageHandler.Storage.Films)
                    if (DataStorageHandler.Storage.Reservations[ticketIndex].Filmtitel == filmItem.Titel)
                        filmIndex = DataStorageHandler.Storage.Films.IndexOf(filmItem);

                int teller = 0;

                Console.WriteLine("Kies uw nieuwe datum:");

                foreach (var projectiemoment in DataStorageHandler.Storage.Films[filmIndex].Projectiemoment)
                {
                    bool geweest = true;
                    string datum = projectiemoment[0];
                    Console.WriteLine(datum);
                    int dag = Int32.Parse($"{datum[0]}{datum[1]}");
                    int maand = Int32.Parse($"{datum[3]}{datum[4]}");
                    int jaar = Int32.Parse($"{datum[6]}{datum[7]}{datum[8]}{datum[9]}");

                    if (jaar < DateTime.Now.Year)
                    {
                        Console.WriteLine("jaar < DateTime.Now.Year");
                        geweest = false;
                    }
                    else if (jaar > DateTime.Now.Year)
                    {
                        Console.WriteLine("jaar > DateTime.Now.Year");
                        geweest = true;
                    }
                    else
                    {
                        if (maand < DateTime.Now.Month)
                        {
                            Console.WriteLine("maand < DateTime.Now.Month");
                            geweest = true;
                        }
                        if (maand > DateTime.Now.Month)
                        {
                            Console.WriteLine("maand > DateTime.Now.Month");
                            geweest = false;
                        }
                        else
                        {
                            if (dag <= DateTime.Now.Day)
                            {
                                Console.WriteLine("dag <= DateTime.Now.Day");
                                geweest = true;
                            }
                            if (dag > DateTime.Now.Day)
                            {
                                Console.WriteLine("dag > DateTime.Now.Day");
                                geweest = false;
                            }
                        }
                    }
                    Beheer.Input();
                    if (geweest == false)
                    {
                        Console.WriteLine($"{teller+1}. {datum}\n");
                        teller++;
                    }
                }

                if (teller == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Er zijn geen andere data beschikbaar!!!\n");
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }

                int outerIndex = 0;

                try { outerIndex = Int32.Parse(Beheer.Input("Welke datum wilt u selecteren? "))-1; if (outerIndex > teller+1) VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex, indexOfGebruiker); }
                catch { Console.Clear(); Console.WriteLine("Er ging iets fout!"); VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex, indexOfGebruiker); }

                Console.WriteLine("Kies uw nieuwe tijd:");

                int teller2 = 1;
                for (int i = 0; i < DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex].Length-1; i++, teller2++)
                    Console.WriteLine($"\n{teller2}. {DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex][i+1]}");
                
                int innerIndex = 0;

                try { innerIndex = Int32.Parse(Beheer.Input("\nWelk tijdstip wilt u selecteren")) - 1; if (innerIndex > teller2) VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex, indexOfGebruiker); }
                catch { Console.Clear(); Console.WriteLine("Er ging iets fout!"); VeranderTicket.veranderTicket(gebruikersnaam, keuze, ticketIndex, indexOfGebruiker); }

                DataStorageHandler.Storage.Reservations[ticketIndex].Datum = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex][0];
                DataStorageHandler.Storage.Reservations[ticketIndex].Tijd = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex][innerIndex];
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }

        }
    }

}
