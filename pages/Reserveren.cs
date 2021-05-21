using ProjectB.Classes;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectB.pages
{
    class Reserveren
    {
        public static void reserveren(int zaalnummer)
        {
            Console.Clear();
            Console.WriteLine("Hoeveel kaartjes wilt u bestellen?");

            bool validticketinput = false;

            string ticketinput;

            while (validticketinput == false)
            {
                ticketinput = Console.ReadLine();

                if (new string[]{ "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}.Contains(ticketinput)) {
                    Console.Clear();
                    validticketinput = true;
                    string projectie = "";
                    BaseSeat selectedSeat= null;

                    if (zaalnummer == 1)
                    {
                        projectie = "2D";
                        selectedSeat = Zitplaatsenkiezen.zitplaatsenkiezen(); 
                    }
                    
                    else if (zaalnummer == 2)
                    {
                        projectie = "3D";
                        selectedSeat = Zitplaatsenkiezen2.zitplaatsenkiezen2();
                    }

                    else if (zaalnummer == 3)
                    {
                        projectie = "IMAX";
                        selectedSeat = Zitplaatsenkiezen3.zitplaatsenkiezen3();
                    }

                    string snack = Snackskiezen.snackskiezen();
                    Reservation nieuweReservering = new Reservation

                    {
                        ID = "hallotest2",
                        Zaal = zaalnummer,
                        Seats = selectedSeat,
                        Snack = snack,
                    };

                    Console.WriteLine("\nDit is de informatie over uw bestelling:\n");

                    Console.WriteLine("\nKlantnaam: " + nieuweReservering.Seats.Customer + "\nZaal: " + nieuweReservering.Zaal + "\nRij: " + nieuweReservering.Seats.Rij + "\nKolom: " + nieuweReservering.Seats.Column + "\nPrijs: " + nieuweReservering.Seats.Price + "\nSnacks: " + nieuweReservering.Snack);

                    Console.WriteLine("\nDoor verder te gaan, gaat u akkoord met dat alle bestelgegevens hierboven correct is.\n1. JA\n2. NEE");

                    bool validoption = false;

                    while(validoption == false)
                    {
                        string option = Console.ReadLine();

                        if (option == "1")
                        {
                            validoption = true;
                            DataStorageHandler.Storage.Reservations.Add(nieuweReservering);
                            DataStorageHandler.SaveChanges();
                            Console.Clear();
                            Console.WriteLine("Het reserveren is gelukt!");
                            ConsoleMenu.consoleMenu();
                        }
                        else if (option == "2")
                        {
                            validoption = true;
                            Console.WriteLine("hier komt een bewerkingsfunctie");
                        }
                        else
                        {
                            Console.WriteLine("\nFOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                            validoption = false;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: Het aantal kaartjes moet minimaal 1 zijn en niet meer dan 10 zijn.");
                    validticketinput = false;
                }
            }
        }
    }
}
