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
            string menuenter;
            bool validinputmenu = false;
            bool vldinptwthaccount = false;

            Console.WriteLine("Welkom bij de bioscoop app!\n\nKies uw nummer uit de volgende opties:\n1. Inloggen\n2. Registreren\n3. Verder gaan zonder account\n");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                if (menuinput == "1")
                {
                    Console.Clear();
                    Login.login();
                    validinputmenu = true;
                }

                else if (menuinput == "2")
                {
                    Console.Clear();
                    Registreren.registreren();
                    validinputmenu = true;
                }

                else if (menuinput == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Weet u zeker dat u zonder account verder wilt gaan?\nMet een account kunt u gemakkelijker reserveren.\n1. JA\n2. NEE");
                    validinputmenu = true;

                    while (vldinptwthaccount == false)
                    {
                        menuenter = Console.ReadLine();

                        if (menuenter == "1")
                        {
                            Console.Clear();
                            ConsoleMenu.consoleMenu(null);
                            vldinptwthaccount = true;
                        }

                        else if (menuenter == "2")
                        {
                            Console.Clear();
                            Startscherm.startscherm();
                            vldinptwthaccount = true;
                        }

                        else
                        {
                            Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1 of 2");
                            vldinptwthaccount = false;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: er is een niet bestaande optie gekozen. Kies uit de nummers: 1, 2 of 3");
                    validinputmenu = false;
                }
            }
        }
    }
}