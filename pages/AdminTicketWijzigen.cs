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
    class AdminTicketWijzigen
    {
        public static void tussen()
        {
            Console.WriteLine("Maak uw keuze:\n1. Ticket wijzigen\n2. Ticket verwijedren\n0. Terug\n");
            string antwoord = Beheer.Input("");

            if (antwoord == "1")
            {
                Console.Clear();
                adminTicketWijzigen();
            }
            else if (antwoord == "2")
            {
                Console.Clear();
                adminTicketVerwijderen();
            }
            else if (antwoord == "0")
                AdminMenu.adminMenu();
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er gaat iets fout, probeer het opniew!\n");
                Console.ResetColor();
                tussen();
            }
        }
        public static void adminTicketWijzigen()
        {
            foreach (Reservation reservatie in DataStorageHandler.Storage.Reservations)
            {
                Console.WriteLine($"ID: {reservatie.ID}\n");
                Console.WriteLine($"Klant: {reservatie.Customer}\n");
                Console.WriteLine($"Film: {reservatie.Filmtitel}\n");
                Console.WriteLine($"Datum: {reservatie.Datum}\n");
                Console.WriteLine($"----------\n");
            }

            Console.WriteLine("\n\nTyp een kaart ID");
            Console.WriteLine("Druk b om terug te gaan.");
            string Select = Beheer.Input("");
            if (Select == "b")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else
            {
                try
                {
                    if (filmAfgelopen2(Int32.Parse(Select)) == "wijzigbaar")
                    {
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                        {
                            if (Select == reservation.ID)
                            {
                                int ticketIndex = DataStorageHandler.Storage.Reservations.IndexOf(reservation);
                                
                                Console.Clear();
                                Console.WriteLine("Wat wilt u aan uw ticket veranderen\n1. Snacks\n2. Datum / Tijd\n0. Terug\n");
                                string veranderInput = Beheer.Input("");

                                if (veranderInput == "1")
                                {
                                    adminSnacksWijzigen(ticketIndex);
                                }
                                else if (veranderInput == "2")
                                {
                                    adminTijdWijzigen(ticketIndex);
                                }
                                else if (veranderInput == "0")
                                {

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Er ging iets verkeerd!\nTyp Enter");
                                    Console.ResetColor();
                                    Beheer.Input();
                                    AdminMenu.adminMenu();
                                }
                            }                            
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("De film speelt binnen 24 uur. U kunt deze film niet aanpassen of verwijderen.");
                        Console.ResetColor();
                        Console.WriteLine("\nTyp Enter");
                        Beheer.Input();
                        AdminMenu.adminMenu();
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er ging iets verkeerd!\nTyp Enter");
                    Console.ResetColor();
                    Beheer.Input();
                    AdminMenu.adminMenu();
                }
            }
        }
        public static string filmAfgelopen2(int ticketIndex)
        {
            DateTime moment = DateTime.Now;

            string afgelopen = "";

            string filmDatum = DataStorageHandler.Storage.Reservations[ticketIndex].Datum;
            string filmDag = $"{filmDatum[0]}{filmDatum[1]}";
            string filmMaand = $"{filmDatum[3]}{filmDatum[4]}";
            string filmJaar = $"{filmDatum[6]}{filmDatum[7]}{filmDatum[8]}{filmDatum[9]}";

            string filmUur = $"{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[0]}{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[1]}";

            int jaar = Int32.Parse(filmJaar);
            int maand = Int32.Parse(filmMaand);
            int dag = Int32.Parse(filmDag);
            int uur = Int32.Parse(filmUur);

            int HuidigeJaar = moment.Year;
            int HuidigeMaand = moment.Month;
            int HuidigeDag = moment.Day;
            int HuidigeUur = moment.Hour;

            if (HuidigeJaar <= jaar)
            {
                if (HuidigeMaand < maand)
                {
                    afgelopen = "wijzigbaar";
                }
                else if (HuidigeMaand == maand)
                {
                    if (HuidigeDag < dag)
                    {
                        if (HuidigeUur > uur)
                        {
                            afgelopen = "";
                        }
                        else
                        {
                            afgelopen = "wijzigbaar";
                        }
                    }
                    else if (HuidigeDag == dag)
                    {
                        if (HuidigeUur > uur)
                        {
                            afgelopen = "afgelopen";
                        }
                        else
                        {
                            afgelopen = "";
                        }
                    }
                    else
                        afgelopen = "afgelopen";
                }
                else
                    afgelopen = "afgelopen";
            }
            else
                afgelopen = "afgelopen";

            return afgelopen;
        }

        public static void adminTicketVerwijderen()
        {
            foreach (Reservation reservatie in DataStorageHandler.Storage.Reservations)
            {
                Console.WriteLine($"ID: {reservatie.ID}\n");
                Console.WriteLine($"Klant: {reservatie.Customer}\n");
                Console.WriteLine($"Film: {reservatie.Filmtitel}\n");
                Console.WriteLine($"Datum: {reservatie.Datum}\n");
                Console.WriteLine($"----------\n");
            }

            Console.WriteLine("\n\nTyp een kaart ID om te verwijderen");
            Console.WriteLine("Druk b om terug te gaan.");
            string Select = Beheer.Input("");
            if (Select == "b")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else
            {
                if (filmAfgelopen2(Int32.Parse(Select)) == "wijzigbaar")
                {
                    foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                    {
                        if (Select == reservation.ID)
                        {
                            int ticketIndex = 0;

                            foreach (Reservation res in DataStorageHandler.Storage.Reservations)
                                if (Select == res.ID)
                                    ticketIndex = DataStorageHandler.Storage.Reservations.IndexOf(res);

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
                                Console.WriteLine("\nUw ticket is succesvol verwijdert.\nTyp Enter");
                                Console.ResetColor();
                                DataStorageHandler.SaveChanges();
                                Beheer.Input();

                                AdminMenu.adminMenu();
                            }

                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Ticket is niet meer wijzigbaar\nTyp Enter");
                    Beheer.Input();
                    AdminMenu.adminMenu();
                }
            }
        }
        public static void adminSnacksWijzigen(int ticketIndex)
        {
            Console.WriteLine($"U heeft nu {DataStorageHandler.Storage.Reservations[ticketIndex].Snack} als snack geselecteerd, naar wat wilt u dit veranderen?\n0. Wijzeging annuleren\n1. Popcorn zoet\n2. Popcorn zout\n3. Popcorn mix\n4. Geen");
            string snackKeuze = Beheer.Input("");
            if (snackKeuze == "0")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else if (snackKeuze == "1")
            {
                DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zoet";
                DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                Console.ResetColor();
                Console.WriteLine("\nTyp Enter");
                Beheer.Input();
                AdminMenu.adminMenu();
            }
            else if (snackKeuze == "2")
            {
                DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Zout";
                DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                Console.ResetColor();
                Console.WriteLine("\nTyp Enter");
                Beheer.Input();
                AdminMenu.adminMenu();
            }
            else if (snackKeuze == "3")
            {
                DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Popcorn Mix";
                DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 6.5;
                DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice + DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                Console.ResetColor();
                Console.WriteLine("\nTyp Enter");
                Beheer.Input();
                AdminMenu.adminMenu();
            }
            else if (snackKeuze == "4")
            {
                DataStorageHandler.Storage.Reservations[ticketIndex].Snack = "Geen";
                DataStorageHandler.Storage.Reservations[ticketIndex].Sumprice = DataStorageHandler.Storage.Reservations[ticketIndex].Seatsumprice;
                DataStorageHandler.Storage.Reservations[ticketIndex].Snackprice = 0;
                DataStorageHandler.SaveChanges();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aanpassingen zijn opgeslagen\n");
                Console.ResetColor();
                Console.WriteLine("\nTyp Enter");
                Beheer.Input();
                AdminMenu.adminMenu();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er ging iets verkeerd!\nTyp Enter");
                Console.ResetColor();
                Beheer.Input();
                adminSnacksWijzigen(ticketIndex);
            }
        }
        public static void adminTijdWijzigen(int ticketIndex)
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
                adminTicketWijzigen();
            }

            int outerIndex = 0;

            try
            {
                outerIndex = Int32.Parse(Beheer.Input("Welke datum wilt u selecteren? "));
                if (outerIndex > teller + 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er ging iets fout!");
                    Console.ResetColor();
                    adminTijdWijzigen(ticketIndex);
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er ging iets fout!");
                Console.ResetColor();
                adminTijdWijzigen(ticketIndex);
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
                    adminTijdWijzigen(ticketIndex);
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Er ging iets fout!");
                Console.ResetColor();
                adminTijdWijzigen(ticketIndex);
            }

            DataStorageHandler.Storage.Reservations[ticketIndex].Datum = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1][0];
            DataStorageHandler.Storage.Reservations[ticketIndex].Tijd = DataStorageHandler.Storage.Films[filmIndex].Projectiemoment[outerIndex + datumIndexTeller - 1][innerIndex];
            DataStorageHandler.SaveChanges();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Aanpassingen zijn opgeslagen\n");
            Console.ResetColor();
            Console.WriteLine("\nTyp Enter");
            Beheer.Input();
            AdminMenu.adminMenu();
        }
    }
}
