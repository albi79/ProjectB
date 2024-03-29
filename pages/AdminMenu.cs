﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class AdminMenu
    {
        public static void adminMenu()
        {
            string menuinput;
            //int menuchoice;

            string menuexit;
            //int menuExit;

            bool validinputmenu = false;
            bool validinputlogout = false;

            Console.WriteLine("Welkom bij de Admin-menu:");
            Console.WriteLine("1. Uitloggen");
            Console.WriteLine("2. Sales overview");
            Console.WriteLine("3. Filmprogramma beheren");
            Console.WriteLine("4. Ticket terugvinden");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Voer uw optienummer in");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                // convert to integer
                // menuchoice = Convert.ToInt32(menuinput);

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
                            AdminMenu.adminMenu();
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
                    //Console.WriteLine("Hier wordt de sales overview scherm aangeroepen");
                    SalesOverview.salesOverview();
                    validinputmenu = true;
                }

                else if (menuinput == "3")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de filmprogramma scherm aangeroepen");
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                    validinputmenu = true;
                }

                else if (menuinput == "4")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de ticket terugvinden scherm aangeroepen");
                    TicketTerugvinden.ticketTerugvinden();
                    validinputmenu = true;
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, 3, of 4");
                    validinputmenu = false;
                }
            }
        }
    }
}