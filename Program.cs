using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            login();
        }

        class Login
        {

        public static void login()
        {
            string gebruikersnaam = "";
            string wachtwoord = "";
            Console.Clear();

            Console.Write("Gebruikersnaam: ");
            gebruikersnaam = Console.ReadLine();

            Console.Write("Wachtwoord: ");
            wachtwoord = Console.ReadLine();
            Console.Clear();

            string[] gebruiker = new string[] (gebruikersnaam,wachtwoord);

            foreach(KeyValuePair<string,string> element in gebruikers)
                {
                    if(gebruikers.Contains(gebruiker[0]) && gebruikers.Contains(gebruiker[1]))
                        continue;
            //            menu()
                }
                    
            Console.WriteLine("login klopt niet \n\nKlik R voor registreren\n\nKlik C voor Continue zonder inloggen\n\nKlik Enter voor opnieuw inloggen");

            var key = Console.ReadKey();

            if (key == "r")
                    Registreren.registreren();

            else if (key == "c")
                    Welkom.consoleMenu();

            else
                    Login.login();
        }
        }
    }
}
