using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class Startscherm
    {
        public static void startscherm()
        {
            string menuinput;
            int menuchoice;

            string menuenter;
            int menuEnter;

            bool validinputmenu = false;
            bool vldinptwthaccount = false;

            Console.WriteLine("Welkom bij de bioscoop app!\nKies uw nummer uit de volgende opties:\n0. Inloggen\n1. Registreren\n2. Verder gaan zonder account");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                // convert to integer
                menuchoice = Convert.ToInt32(menuinput);

                if (menuchoice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Hier wordt de inlogscherm aangeroepen");
                    validinputmenu = true;
                }

                else if (menuchoice == 1)
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de registratie scherm aangeroepen");
                    Registreren.registreren();
                    validinputmenu = true;
                }

                else if (menuchoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Weet u zeker dat u wilt inloggen zonder account?\nLET OP: VOOR HET RESERVEREN IS HET AANMAKEN VAN EEN ACCOUNT AANBEVOLEN\n--------------------------\n0. JA\n1. NEE");
                    validinputmenu = true;

                    while (vldinptwthaccount == false)
                    {
                        menuenter = Console.ReadLine();
                        menuEnter = Convert.ToInt32(menuenter);

                        if (menuEnter == 0)
                        {
                            Console.Clear();
                            //Console.WriteLine("Hier wordt de welkomscherm aangeroepen");
                            ConsoleMenu.consoleMenu();
                            vldinptwthaccount = true;
                        }

                        else if (menuEnter == 1)
                        {
                            Console.Clear();
                            Startscherm.startscherm();
                            vldinptwthaccount = true;
                        }

                        else
                        {
                            Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 0 of 1");
                            vldinptwthaccount = false;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 0, 1 of 2");
                    validinputmenu = false;
                }
            }
        }
    }

}
