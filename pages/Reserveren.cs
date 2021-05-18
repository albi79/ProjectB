using ProjectB.Classes;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Reserveren
    {
        public static void reserveren()
        {
            Console.Clear();
            Console.WriteLine("Hoeveel kaartjes wilt u bestellen?");

            bool validticketinput = false;

            string ticketinput;

            while (validticketinput == false)
            {
                ticketinput = Console.ReadLine();

                if (ticketinput == "1" | ticketinput == "2" | ticketinput == "3" | ticketinput == "4" | ticketinput == "5" | ticketinput == "6" | ticketinput == "7" | ticketinput == "8" | ticketinput == "9" | ticketinput == "10")
                {
                    Console.Clear();
                    validticketinput = true;

                    //if (DataStorageHandler.Storage.Films[selectedFilm].Projectie == "2D" of "3D" of "IMAX")
                    //{
                    //hall = 1 of 2 of 3
                    //var selectedSeat = Zitplaatsenkiezen2.zitplaatsenkiezen2(); of 
                    //}

                    var selectedSeat = Zitplaatsenkiezen.zitplaatsenkiezen();
                    string snack = Snackskiezen.snackskiezen();

                    Reservation nieuweReservering = new Reservation

                    {
                        ID = "hallotest2",
                        Hall = "",
                        Seats = selectedSeat,
                        Snack = snack,
                    };

                    DataStorageHandler.Storage.Reservations.Add(nieuweReservering);
                    DataStorageHandler.SaveChanges();

                    Console.WriteLine("\nDit is de informatie over uw bestelling:\n");

                    foreach (var reservationItem in DataStorageHandler.Storage.Reservations)
                    {
                        Console.WriteLine("\nKlantnaam: " + reservationItem.Seats.Customer + "\nZaal: " + reservationItem.Hall + "\nRij: " + reservationItem.Seats.Row + "\nKolom: " + reservationItem.Seats.Column + "\nPrijs: " + reservationItem.Seats.Price + "\nSnacks: " + reservationItem.Snack);
                    }

                    Console.WriteLine("\nDoor verder te gaan, gaat u akkoord met dat alle bestelgegevens hierboven correct is.\n1. JA\n2. NEE");

                    string option = Console.ReadLine();
                    bool validoption = false;

                    while(validoption == false)
                    {
                        if (option == "1")
                        {
                            validoption = true;
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
