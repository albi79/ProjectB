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
        public static void reserveren(int zaalnummer, string gebruikersnaam, int selectedFilm, string HuidigOfToekomstig)
        {
            Console.Clear();
            int selectedDate = 0;
            string filmtitel = DataStorageHandler.Storage.Films[selectedFilm].Titel;

            string datum = Datumkiezen.datumkiezen(selectedFilm, ref selectedDate);

            if (datum == "Terug gaan")
            {
                FilmSelect.Overzicht(HuidigOfToekomstig, gebruikersnaam);
            }

            string tijd = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);

            if (tijd == "Terug gaan")
            {
                reserveren(zaalnummer, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
            }

            string ticketinput = Aantalticketkiezen.aantalticketkiezen();

            while (ticketinput == "Terug gaan")
            {
                tijd = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);
                if (tijd == "Terug gaan")
                {
                    reserveren(zaalnummer, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
                }
                else
                {
                    ticketinput = Aantalticketkiezen.aantalticketkiezen();
                }
            }
            int number;
            int ticketInput = 0;
            bool isParse = Int32.TryParse(ticketinput, out number);

            if (isParse)
            {
                ticketInput = number;
            }
            // <<hier moet ticketinput in een integer veranderen en daarom is ticketInput de number>>
            Console.Clear();
            string projectie = "";
            List<BaseSeat> selectedseatList = null;

            if (zaalnummer == 1)
            {
                projectie = "2D";
                selectedseatList = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd, ticketInput);
            }

            else if (zaalnummer == 2)
            {
                projectie = "3D";
                selectedseatList = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd, ticketInput);
            }

            else if (zaalnummer == 3)
            {
                projectie = "IMAX";
                selectedseatList = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd, ticketInput);
            }

            while (selectedseatList.Count == 0) //als een stap teruggaat van zitplaatskiezen
            {
                ticketinput = Aantalticketkiezen.aantalticketkiezen();
                isParse = Int32.TryParse(ticketinput, out number);
                if (isParse)
                {
                    ticketInput = number;
                }
                while (ticketinput == "Terug gaan")
                {
                    tijd = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);
                    if (tijd == "Terug gaan")
                    {
                        reserveren(zaalnummer, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
                    }
                    else
                    {
                        ticketinput = Aantalticketkiezen.aantalticketkiezen();
                        isParse = Int32.TryParse(ticketinput, out number);
                        if (isParse)
                        {
                            ticketInput = number;
                        }
                    }
                }
                if (zaalnummer == 1)
                {
                    projectie = "2D";
                    selectedseatList = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd, ticketInput);
                }

                else if (zaalnummer == 2)
                {
                    projectie = "3D";
                    selectedseatList = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd, ticketInput);
                }

                else if (zaalnummer == 3)
                {
                    projectie = "IMAX";
                    selectedseatList = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd, ticketInput);
                }
            }

            string zitplaatstype = "";
            for (int i = 0; selectedseatList.Count > i; i++)
            {
                if (selectedseatList[i].Price == 15.00)
                {
                    zitplaatstype = "VIP";
                }

                else if (selectedseatList[i].Price == 30.00)
                {
                    zitplaatstype = "MASTER";
                }

                else
                {
                    zitplaatstype = "REGULIERE";
                }
            }
            string snack = Snackskiezen.snackskiezen();

            while (snack == "Terug gaan")
            {
                if (zaalnummer == 1)
                {
                    projectie = "2D";
                    selectedseatList = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd, ticketInput);
                }

                else if (zaalnummer == 2)
                {
                    projectie = "3D";
                    selectedseatList = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd, ticketInput);
                }

                else if (zaalnummer == 3)
                {
                    projectie = "IMAX";
                    selectedseatList = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd, ticketInput);
                }
                while (selectedseatList.Count == 0)
                {
                    ticketinput = Aantalticketkiezen.aantalticketkiezen();
                    while (ticketinput == "Terug gaan")
                    {
                        tijd = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);
                        if (tijd == "Terug gaan")
                        {
                            reserveren(zaalnummer, gebruikersnaam, selectedFilm, HuidigOfToekomstig);
                        }
                        else
                        {
                            ticketinput = Aantalticketkiezen.aantalticketkiezen();
                        }
                    }
                    isParse = Int32.TryParse(ticketinput, out number);
                    if (isParse)
                    {
                        ticketInput = number;
                    }
                    if (zaalnummer == 1)
                    {
                        projectie = "2D";
                        selectedseatList = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd, ticketInput);
                    }

                    else if (zaalnummer == 2)
                    {
                        projectie = "3D";
                        selectedseatList = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd, ticketInput);
                    }

                    else if (zaalnummer == 3)
                    {
                        projectie = "IMAX";
                        selectedseatList = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd, ticketInput);
                    }
                }
                snack = Snackskiezen.snackskiezen();
            }

            double snackPrice = 0.0;

            if (snack.Contains("Popcorn"))
            {
                snackPrice = 6.50;
            }
            else if (snack == "Geen")
            {
                snackPrice = 0.0;
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

            double ticketpriceSum = 0;

            for(int j = 0; selectedseatList.Count > j; j++)
            {
                ticketpriceSum += selectedseatList[j].Price;
            }

            double sumPrice = ticketpriceSum + snackPrice;

            bool newaccount = false;
            string prompt = "";
            string klantnaam = "";

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
                klantnaam = naam2 + achternaam2;

            }

            if (newaccount == false)
            {
                prompt = "STAP 6: ";
                klantnaam = gebruikersnaam;
            }
            else
            {
                gebruikersnaam = null;
                prompt = "STAP 7: ";
            }

            //Console.WriteLine("\n" + prompt + "Controleer uw bestelgegevens\nDit is de informatie over uw bestelling:\n");

            //Console.WriteLine("\nKlantnaam: " + klantnaam + "\nFilmtitel: " + filmtitel + "\nDatum: " + datum + "\nTijd: " + tijd + "\nProjectie: " + projectie + "\nZaal: " + zaalnummer + "\nRij: " + selectedSeat.Rij + "\nZitplaatsnummer: " + selectedSeat.Column + "\nZitplaatstype: " + zitplaatstype + "\nZitplaatsprijs: " + selectedSeat.Price + "\nSnacks: " + snack + "\nSnackprijs: " + snackPrice + "\nTotale prijs: " + sumPrice);

            string option = Bestelgegevensjanee.bestelgegevensjanee(prompt, klantnaam, filmtitel, datum, tijd, projectie, zaalnummer, zitplaatstype, snack, snackPrice, sumPrice, selectedseatList, ticketInput);

            while (option == "NEE")
            {
                string wijzigingsoptie = Specifiekebestelinfoaanpassen.specifiekebestelinfoaanpassen();

                if (wijzigingsoptie == "Datum & Tijd")
                {
                    string datum2 = Datumkiezen.datumkiezen(selectedFilm, ref selectedDate);
                    if (datum2 == "Terug gaan")
                    {
                        option = "NEE";
                    }
                    else
                    {
                        datum = datum2;
                    }

                    string tijd2 = Tijdkiezen.tijdkiezen(selectedFilm, selectedDate);
                    if (tijd2 == "Terug gaan")
                    {
                        option = "NEE";
                    }
                    else
                    {
                        tijd = tijd2;
                    }
                }

                else if (wijzigingsoptie == "Zitplaats")
                {
                    List<BaseSeat> selectedseatList2 = null;
                    if (zaalnummer == 1)
                    {
                        projectie = "2D";
                        selectedseatList2 = Zitplaatsenkiezen.zitplaatsenkiezen(selectedFilm, datum, tijd, ticketInput);
                    }

                    else if (zaalnummer == 2)
                    {
                        projectie = "3D";
                        selectedseatList2 = Zitplaatsenkiezen2.zitplaatsenkiezen2(selectedFilm, datum, tijd, ticketInput);
                    }

                    else if (zaalnummer == 3)
                    {
                        projectie = "IMAX";
                        selectedseatList2 = Zitplaatsenkiezen3.zitplaatsenkiezen3(selectedFilm, datum, tijd, ticketInput);
                    }

                    if (selectedseatList2.Count == 0) // terug gaan
                    {
                        option = "NEE";
                    }
                    else
                    {
                        for (int i = 0; selectedseatList2.Count > i; i++)
                        {
                            if (selectedseatList2[i].Price == 15.00)
                            {
                                zitplaatstype = "VIP";
                            }

                            else if (selectedseatList2[i].Price == 30.00)
                            {
                                zitplaatstype = "MASTER";
                            }

                            else
                            {
                                zitplaatstype = "REGULIERE";
                            }
                            selectedseatList = selectedseatList2;
                        }
                        double ticketpriceSum2 = 0.0;
                        for (int i = 0; selectedseatList.Count > i; i++)
                        {
                            ticketpriceSum2 += selectedseatList[i].Price;
                        }
                        ticketpriceSum = ticketpriceSum2;
                    }
                }

                else if (wijzigingsoptie == "Snacks")
                {
                    string snack2 = Snackskiezen.snackskiezen();
                    if (snack2.Contains("Popcorn"))
                    {
                        snack = snack2;
                        snackPrice = 6.50;
                    }

                    else if (snack2 == "Geen")
                    {
                        snack = snack2;
                        snackPrice = 0.0;
                    }

                    else if (snack2 == "Terug gaan")
                    {
                        option = "NEE";
                    }

                }

                else if (wijzigingsoptie == "Terug gaan")
                {
                    sumPrice = ticketpriceSum + snackPrice;
                    //Console.Clear();
                    //Console.WriteLine("\n" + prompt + "Controleer uw bestelgegevens\nDit is de informatie over uw bestelling:\n");

                    //Console.WriteLine("\nKlantnaam: " + klantnaam + "\nFilmtitel: " + filmtitel + "\nDatum: " + datum + "\nTijd: " + tijd + "\nProjectie: " + projectie + "\nZaal: " + zaalnummer + "\nRij: " + selectedSeat.Rij + "\nZitplaatsnummer: " + selectedSeat.Column + "\nZitplaatstype: " + zitplaatstype + "\nZitplaatsprijs: " + selectedSeat.Price + "\nSnacks: " + snack + "\nSnackprijs: " + snackPrice + "\nTotale prijs: " + sumPrice);

                    option = Bestelgegevensjanee.bestelgegevensjanee(prompt, klantnaam, filmtitel, datum, tijd, projectie, zaalnummer, zitplaatstype, snack, snackPrice, sumPrice, selectedseatList, ticketInput);
                }
            }

            Reservation nieuweReservering = new Reservation

            {
                ID = reservationstring,
                Customer = klantnaam,
                Filmtitel = filmtitel,
                Datum = datum,
                Tijd = tijd,
                Projectie = projectie,
                Zaal = zaalnummer,
                Seats = selectedseatList,
                Zitplaatstype = zitplaatstype,
                Snack = snack,
                Snackprice = snackPrice,
                Sumprice = sumPrice,
            };
            DataStorageHandler.Storage.Reservations.Add(nieuweReservering);
            DataStorageHandler.SaveChanges();
            Console.Clear();
            Console.WriteLine("Het reserveren is gelukt!");
            ConsoleMenu.consoleMenu(gebruikersnaam);
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
