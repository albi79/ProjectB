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
        public static void consoleMenu()
        {
            string menuinput;
            //int menuchoice;

            string menuexit;
            //int menuExit;

            bool validinputmenu = false;
            bool validinputlogout = false;

            Console.WriteLine("Welkom bij de menu:");
            Console.WriteLine("1. Uitloggen");
            Console.WriteLine("2. Film programma");
            Console.WriteLine("3. Ticket terugvinden");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Voer uw optienummer in");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                // convert to integer
                //menuchoice = Convert.ToInt32(menuinput);

                if (menuinput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Weet u zeker dat u wilt uitloggen?\n1. JA\n2. NEE");
                    validinputmenu = true;

                    while (validinputlogout == false)
                    {
                        menuexit = Console.ReadLine();
                        //menuExit = Convert.ToInt32(menuexit);

                        if (menuexit == "1")
                        {
                            Console.Clear();
                            //Console.WriteLine("Hier wordt de welkomscherm aangeroepen");
                            Startscherm.startscherm();
                            validinputlogout = true;
                        }

                        else if (menuexit == "2")
                        {
                            Console.Clear();
                            ConsoleMenu.consoleMenu();
                            validinputlogout = true;
                        }

                        else
                        {
                            Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                            validinputlogout = false;
                        }
                    }
                }

                else if (menuinput == "3")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de sales overview scherm aangeroepen");
                    TicketTerugvinden.ticketTerugvinden();
                    validinputmenu = true;
                }

                else if (menuinput == "2")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de filmprogramma scherm aangeroepen");
                    //FilmprogrammaBeheren.filmprogrammaBeheren();
                    FilmSelect.filmSelect();
                    validinputmenu = true;
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, of 3");
                    validinputmenu = false;
                }
            }
        }
    }
}