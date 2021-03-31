using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class Welkom
    {
        private string prompt;
        private string[] options;

        public Welkom(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
        }

        public static void consoleMenu()
        {
            string menuinput;
            int menuchoice;

            Console.Clear();
            Console.WriteLine("Welkom bij de menu:");
            Console.WriteLine("0. Inloggen");
            Console.WriteLine("1. Registreren");
            Console.WriteLine("2. Verder zonder account");

            menuinput = Console.ReadLine();

            // convert to integer
            menuchoice = Convert.ToInt32(menuinput);

            var Option = new welkom(menuchoice);
        }
    }
    public class welkom
    {
        public welkom(int numberchoice)
        {
            string Optionname = "";

            if (numberchoice == 0)
            {
                Login.login();
                //Optionname = "Inloggen";
            }
            else if (numberchoice == 1)
            {
                Console.Clear();
                Registreren.registreren();
            }
            else if (numberchoice == 2)
            {
                Optionname = "Verder zonder account";
            }
            else
            {
                Optionname = "ERROR";
            }
            Console.WriteLine(Optionname);
        }
    }
}
