using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.DAL;
using ProjectB.Classes;

namespace ProjectB.pages
{
    class ConsoleMenu
    {
        public string gebruikersnaam { get; }
        public static void consoleMenu(string gebruikersnaam)
        {
            string menuinput;
            //int menuchoice;

            string menuexit;
            //int menuExit;

            bool validinputmenu = false;
            bool validinputlogout = false;

           
            Console.Write($"Welkom bij de menu ");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                if(gebruikersnaam == person.gebruikersnaam)
                    Console.Write($"{person.naam}");
            }
            Console.ResetColor();
            if (gebruikersnaam != null)
                Console.WriteLine("\n1. Uitloggen");
            else
                Console.WriteLine("\n1. Terug naar startscherm");
            Console.WriteLine("2. Film programma");
            Console.WriteLine("3. Ticket geschiedenis");
            Console.WriteLine("4. Veelgestelde vragen");
            if (gebruikersnaam != null)
                Console.WriteLine("5. Gebruikergegevens");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Voer uw optienummer in");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();


                if (menuinput == "1")
                {
                    Console.Clear();
                    if (gebruikersnaam != null)
                        Console.WriteLine("Weet u zeker dat u wilt uitloggen?\n1. Ja\n2. Nee");
                    else
                        Console.WriteLine("Weet u zeker dat u terug wilt?\n1. Ja\n2. Nee");
                    validinputmenu = true;

                    while (validinputlogout == false)
                    {
                        menuexit = Console.ReadLine();
                        //menuExit = Convert.ToInt32(menuexit);

                        if (menuexit == "1")
                        {
                            Console.Clear();
                            Startscherm.startscherm();
                            validinputlogout = true;
                        }

                        else if (menuexit == "2")
                        {
                            Console.Clear();
                            ConsoleMenu.consoleMenu(gebruikersnaam);
                            validinputlogout = true;
                        }

                        else
                        {
                            Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                            validinputlogout = false;
                        }
                    }
                }

                else if (menuinput == "2")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de filmprogramma scherm aangeroepen");
                    //FilmprogrammaBeheren.filmprogrammaBeheren();
                    FilmSelect.filmSelect(gebruikersnaam);

                    validinputmenu = true;
                }

                else if (menuinput == "3")
                {
                    Console.Clear();
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                    validinputmenu = true;
                }

                else if (menuinput == "4")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de sales overview scherm aangeroepen");
                    FAQ.faq(gebruikersnaam);
                    validinputmenu = true;
                }

                else if (menuinput == "5")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de sales overview scherm aangeroepen");
                    Gebruikergegevens.gebruikergegevens(gebruikersnaam);
                    validinputmenu = true;
                }

                else
                {
                    if (gebruikersnaam != null)
                        Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, 3, 4 of 5");
                    else
                        Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, 3 of 4");

                    validinputmenu = false;
                }
            }
        }
    }
}