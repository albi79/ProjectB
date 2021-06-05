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
    class AdminMenu
    {
        public static void adminMenu()
        {
            Console.Clear();
            string menuinput;

            string menuexit;

            bool validinputmenu = false;
            bool validinputlogout = false;

            Console.WriteLine("Welkom bij de Admin-menu:");
            Console.WriteLine("1. Uitloggen");
            Console.WriteLine("2. Sales overview en tickets terug vinden");
            Console.WriteLine("3. Filmprogramma beheren");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Voer uw optienummer in");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                if (menuinput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Weet u zeker dat u wilt uitloggen?\n1. JA\n2. NEE");
                    validinputmenu = true;

                    while (validinputlogout == false)
                    {
                        menuexit = Console.ReadLine();

                        if (menuexit == "1")
                        {
                            Console.Clear();
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
                    SalesOverview.salesOverview();
                    validinputmenu = true;
                }

                else if (menuinput == "3")
                {
                    Console.Clear();
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                    validinputmenu = true;
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2, 3");
                    validinputmenu = false;
                }
            }
        }
    }
}