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
        private string prompt;
        private string[] options;

        public ConsoleMenu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
        }

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

        internal int welkom()
        {
            throw new NotImplementedException();
        }

        internal void DisplayOptions()
        {
            throw new NotImplementedException();
        }
    }
    public class Menuchoice
    {
        public Menuchoice(int numberchoice)
        {
            string Optionname = "";

            if (numberchoice == 0)
            {
                Optionname = "Uitloggen";
            }
            else if (numberchoice == 1)
            {
                Optionname = "Sales overview";
            }
            else if (numberchoice == 2)
            {
                Optionname = "Filmprogramma beheren";
            }
            else if (numberchoice == 3)
            {
                Optionname = "Ticket terugvinden";
            }
            else
            {
                Optionname = "ERROR";
            }
            Console.WriteLine(Optionname);
        }
    }
}
