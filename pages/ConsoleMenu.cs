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
            int menuchoice;

            Console.WriteLine("Welkom bij de menu:");
            Console.WriteLine("0. Uitloggen");
            Console.WriteLine("1. Sales overview");
            Console.WriteLine("2. Filmprogramma beheren");
            Console.WriteLine("3. Ticket terugvinden");

            menuinput = Console.ReadLine();

            // convert to integer
            menuchoice = Convert.ToInt32(menuinput);

            var Option = new Menuchoice(menuchoice);
        }
    }
    public class Menuchoice
    {
        public Menuchoice(int numberchoice)
        {
            int Numberchoice = numberchoice;
            string Optionname = "";

            if (Numberchoice == 0)
            {
                Optionname = "Uitloggen";
            }
            else if (Numberchoice == 1)
            {
                Optionname = "Sales overview";
            }
            else if (Numberchoice == 2)
            {
                Optionname = "Filmprogramma beheren";
            }
            else if (Numberchoice == 3)
            {
                Optionname = "Ticket terugvinden";
            }
        }
    }
}
