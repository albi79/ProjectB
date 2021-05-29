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
            //Beoordeling.beoordeling();
            string menuinput;
            //int menuchoice;

            string menuenter;
            //int menuEnter;

            bool validinputmenu = false;
            bool vldinptwthaccount = false;

            Console.WriteLine("Welkom bij de bioscoop app!\nKies uw nummer uit de volgende opties:\n1. Inloggen\n2. Registreren\n3. Verder gaan zonder account");

            while (validinputmenu == false)
            {
                menuinput = Console.ReadLine();

                // convert to integer
                //menuchoice = Convert.ToInt32(menuinput);

                if (menuinput == "1")
                {
                    Console.Clear();
                    Login.login();
                    validinputmenu = true;
                }

                else if (menuinput == "2")
                {
                    Console.Clear();
                    //Console.WriteLine("Hier wordt de registratie scherm aangeroepen");
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
                        //menuEnter = Convert.ToInt32(menuenter);

                        if (menuenter == "1")
                        {
                            Console.Clear();
                            //Console.WriteLine("Hier wordt de welkomscherm aangeroepen");
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
