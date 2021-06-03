using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class ConsoleMenu
    {
        public string gebruikersnaam { get; }
        public static void consoleMenu(string gebruikersnaam)
        {
            Console.Clear();
            string menuinput;
            //int menuchoice;

            string menuexit;
            //int menuExit;

            bool validinputmenu = false;
            bool validinputlogout = false;
            Console.Write($"Welkom bij de menu ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{gebruikersnaam}\n");
            Console.ResetColor();
            Console.WriteLine("1. Uitloggen");
            Console.WriteLine("2. Film programma");
            Console.WriteLine("3. Ticket geschiedenis");
            Console.WriteLine("4. Gebruikergegevens");
            Console.WriteLine("5. Veelgestelde vragen");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Voer uw optienummer in");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();


                if (menuinput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Weet u zeker dat u wilt uitloggen?\n1. Ja\n2. Nee");
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
                    Gebruikergegevens.gebruikergegevens(gebruikersnaam);
                    validinputmenu = true;
                }

                else if (menuinput == "5")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de sales overview scherm aangeroepen");
                    FAQ.faq();
                    validinputmenu = true;
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, 3 of 4");
                    validinputmenu = false;
                }
            }
        }
    }
}