using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class FilmSelect
    {
        public static void filmSelect()
        {
            int filmNummer = 0;

            Console.Clear();
            Console.WriteLine("Film Programma\n\nWelke film bent u in geïnteresseerd?");
            Console.WriteLine();
            
            foreach (var film in DataStorageHandler.Storage.Films)
            {
                Console.WriteLine($"{filmNummer}: {film.Titel}");
                filmNummer++;
            }

            int selectedFilm = Int32.Parse(Beheer.Input());

            Console.Clear();
            Console.WriteLine("Informatie geselecteerde film");
            Console.WriteLine();
            Console.WriteLine("Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
            Console.WriteLine("Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
            Console.WriteLine("Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
            Console.WriteLine("Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
            Console.WriteLine("Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
            Console.WriteLine("Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
            Console.WriteLine("Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
            Console.WriteLine("Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
            Console.WriteLine("Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);

            Console.WriteLine("\n1. voor kaartjes reserveren");
            Console.WriteLine("2. voor terug naar overzicht films");
            string toets = Beheer.Input("");

            if (toets == "1")
            {
                Console.WriteLine("LET OP: U moet minimaal 12 jaar oud zijn om te mogen reserveren.\nAls u doorgaat, gaat u akkoord met deze voorwaarden.\n");
                Console.WriteLine("1. Doorgaan\n2. Terug");
                string toets2 = Beheer.Input("");
                if (toets2 == "1")
                {
                    if (DataStorageHandler.Storage.Films[selectedFilm].Leeftijd >= 16)
                    {
                        Console.WriteLine("\nBent u " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd + " of ouder?");
                        Console.WriteLine("\n1. JA");
                        Console.WriteLine("2. NEE");
                        bool agecheck = false;
                        var ageinput = "";
                        var backinginput = "";
                        bool backingoption = false;

                        while (agecheck == false)
                        {
                            ageinput = Console.ReadLine();

                            if (ageinput == "1")
                            {
                                Console.Clear();
                                Reserveren.reserveren();
                                agecheck = true;
                            }

                            else if (ageinput == "2")
                            {
                                Console.WriteLine("\nU voldoet niet aan de minimum leeftijd" + "\nToets b om terug te gaan");

                                while (backingoption == false)
                                {
                                    backinginput = Console.ReadLine();

                                    if (backinginput == "b")
                                    {
                                        FilmSelect.filmSelect();
                                        backingoption = true;
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
                                                    Console.WriteLine("\nKlantnaam: " + reservationItem.Seats.Customer + "\nRij: " + reservationItem.Seats.Row + "\nKolom: " + reservationItem.Seats.Column + "\nPrijs: " + reservationItem.Seats.Price + "\nSnacks: " + reservationItem.Snack);
                                                }

                                                Console.WriteLine("Door verder te gaan, gaat u akkoord met dat alle bestelgegevens hierboven correct is.\n1. JA\n2. NEE");

                                                string option = Console.ReadLine();
                                                bool validoption = false;

                                                while (validoption == false)
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
                                    else
                                    {
                                        Console.WriteLine("\nFOUTMELDING: er is een ongeldige toets ingevoerd. Toets b om terug te gaan.");
                                        backingoption = false;
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("\nFOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                                agecheck = false;
                            }
                        }
                    }
                    else
                    {
                        Reserveren.reserveren();
                    }
                }
            }
            else if (toets == "2")
                filmSelect();

            else
            {
                Console.WriteLine("\nEr ging iets fout");
                Beheer.Input("");
            }
        }
    }
}
