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
            Console.WriteLine("Maak uw keuze:\n0. Terug\n1. Ticket wijzigen\n2. Ticket verwijedren\n");
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
                                /*
                                 Gegevens van ticket wijzigen
                                    Misschien nieuwe functie maken
                                        Ik doe dit morgen
                                 */
                            }
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("De film speelt binnen 24 uur. U kunt deze film niet aanpassen of verwijderen.\nTyp Enter");
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
    }
}
