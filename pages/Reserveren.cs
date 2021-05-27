using ProjectB.Classes;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    class Reserveren
    {
        public static void reserveren(int zaalnummer, string gebruikersnaam, int selectedFilm)
        {
            Console.Clear();
            int selectedDate = 0;
            string filmtitel = DataStorageHandler.Storage.Films[selectedFilm].Titel;

            string datum = Datumkiezen.datumkiezen(selectedFilm, ref selectedDate);
            string tijd = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);

            Console.WriteLine("STAP 3: Hoeveel kaartjes wilt u bestellen?");

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
                        selectedSeat = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd); 
                    }
                    
                    else if (zaalnummer == 2)
                    {
                        projectie = "3D";
                        selectedSeat = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd);
                    }

                    else if (zaalnummer == 3)
                    {
                        projectie = "IMAX";
                        selectedSeat = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd);
                    }

                    string zitplaatstype = "";

                    if (selectedSeat.Price == 15.00)
                    {
                        zitplaatstype = "VIP";
                    }

                    else if (selectedSeat.Price == 30.00)
                    {
                        zitplaatstype = "MASTER";
                    }

                    else
                    {
                        zitplaatstype = "REGULIERE";
                    }

                    string snack = Snackskiezen.snackskiezen();

                    double snackPrice = 0.0;

                    if (snack.IndexOf("Geen") == -1)
                    {
                        snackPrice = 6.50;
                    }

                    //checkt hoeveel reserveringen er zijn. Vervolgens wordt er naar de laatste ID gezocht met "counter - 1" omdat ID vanaf 0 start.
                    int reservationcounter = DataStorageHandler.Storage.Reservations.Count;
                    string reservationstring = "";

                    if (reservationcounter != 0)
                    {
                        Reservation lastreservation = DataStorageHandler.Storage.Reservations[reservationcounter - 1];
                        reservationstring = (Int32.Parse(lastreservation.ID) + 1).ToString();
                    }

                    else
                    {
                        reservationstring = reservationcounter.ToString();
                    }

                    double sumPrice = selectedSeat.Price + snackPrice;

                    bool newaccount = false;
                    string prompt = "";
                    
                    if (gebruikersnaam == null)
                    {
                        newaccount = true;
                        Console.Clear();

                        string naam2 = Beheer.Input("\nSTAP 6: Voer uw gegevens in\n\nNaam: ");
                        naam2 = Beheer.ControlEmpty(naam2);
                        naam2 = OnlyString(naam2);

                        string tussenvoegsel2 = Beheer.Input("Tussenvoegsel: ");
                        string achternaam2 = Beheer.Input("Achternaam: ");
                        achternaam2 = OnlyString(achternaam2);
                        achternaam2 = Beheer.ControlEmpty(achternaam2);

                        string email2 = Beheer.Input("E-mail: ");
                        email2 = Beheer.ControlEmpty(email2);
                        string email3 = EmailControle(email2);

                        string email22 = Beheer.Input("E-mail bevestiging: ");

                        string opnieuwMail = "j";
                        while (email3 != email22 && opnieuwMail == "j")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Uw e-mail komt niet over een. Voer j in om opnieuw in te voeren.");
                            opnieuwMail = Beheer.Input("");
                            if (opnieuwMail == "j")
                            {
                                email2 = Beheer.Input("E-mail: ");
                                email3 = EmailControle(email2);
                                email22 = Beheer.Input("E-mail bevestiging: ");
                                if (email3 == email22)
                                {
                                    Console.ResetColor();
                                    opnieuwMail = "n";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                                opnieuwMail = "j";
                            }
                        }
                        gebruikersnaam = naam2 + achternaam2;

                    }

                    Reservation nieuweReservering = new Reservation

                    {
                        ID = reservationstring,
                        Customer = gebruikersnaam,
                        Filmtitel = filmtitel,
                        Datum = datum,
                        Tijd = tijd,
                        Projectie = projectie,
                        Zaal = zaalnummer,
                        Seats = selectedSeat,
                        Zitplaatstype = zitplaatstype,
                        Snack = snack,
                        Snackprice = snackPrice,
                        Sumprice = sumPrice,
                    };

                    if (newaccount == false)
                    {
                        prompt = "STAP 6: ";
                    }
                    else
                    {
                        gebruikersnaam = null;
                        prompt = "STAP 7: "; 
                    }

                    Console.Clear();
                    Console.WriteLine("\n" + prompt + "Controleer uw bestelgegevens\nDit is de informatie over uw bestelling:\n");

                    Console.WriteLine("\nKlantnaam: " + nieuweReservering.Customer + "\nFilmtitel: " + nieuweReservering.Filmtitel + "\nDatum: " + nieuweReservering.Datum + "\nTijd: " + nieuweReservering.Tijd + "\nProjectie: " + nieuweReservering.Projectie + "\nZaal: " + nieuweReservering.Zaal + "\nRij: " + nieuweReservering.Seats.Rij + "\nZitplaatsnummer: " + nieuweReservering.Seats.Column + "\nZitplaatstype: " + nieuweReservering.Zitplaatstype + "\nZitplaatsrijs: " + nieuweReservering.Seats.Price + "\nSnacks: " + nieuweReservering.Snack + "\nSnackprijs: " + nieuweReservering.Snackprice + "\nTotale prijs: " + nieuweReservering.Sumprice);
                    
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
                            ConsoleMenu.consoleMenu(gebruikersnaam);
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
        private static string OnlyString(string var)
        {
            if (Regex.IsMatch(var, "[0-9]"))
            {
                while (Regex.IsMatch(var, "[0-9]"))
                {
                    Console.WriteLine("Dit veld mag geen cijfers bevatten.");
                    string var2 = "";
                    var2 = Beheer.Input("Probeer het nogmaals: ");
                    OnlyString(var2);
                    return var2;
                }

            }
            return var;
        }
        private static string EmailControle(string email2)
        {
            if (new EmailAddressAttribute().IsValid(email2))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw mail is goedgekeurd!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw mail is foutgekeurd!");
                email2 = Beheer.Input("E-mail: ");
                email2 = Beheer.ControlEmpty(email2);
                email2 = EmailControle(email2);
            }
            Console.ResetColor();
            return email2;
        }
    }
}