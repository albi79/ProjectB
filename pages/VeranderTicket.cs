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
            //"1" -> snack veranderen
            if (keuze == "1")
            {
                Console.WriteLine($"U heeft nu {DataStorageHandler.Storage.Reservations[ticketIndex].Snack} als snack geselecteerd, naar wat wilt u dit veranderen?\n1. Popcorn zoet\n2. Popcorn zout\n3. Popcorn mix\n 4. Geen\n0. Wijzeging annuleren");
                string snackKeuze = Beheer.Input("");
                if (snackKeuze == "0")
                    TicketWijzigen.ticketWijzigen(gebruikersnaam, ticketIndex);
                else if (snackKeuze == "1")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zoet";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;
                }
                else if (snackKeuze == "2")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zout";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;

                }
                else if (snackKeuze == "3")
                {
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Mix";
                    DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                    DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seats.Price;

                }
                else if (snackKeuze == "4")
                {
                    if (DataStorageHandler.Storage.Reservations[ticketIndex].Snack != "Geen")
                    {
                        DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice -= 6.5;
                        DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 0;
                    }
                }
            }
            //"2" -> datum & tijd veranderen
            else if(keuze == "2")
            {
                
            }
        }
    }

}
