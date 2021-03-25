using System;
//using Newtonsoft;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            login();
        }

        static void login()
        {
            Console.Clear();

            Console.Write("Gebruikersnaam: ");
            string UserName = Console.ReadLine();

            Console.Write("Wachtwoord: ");
            string PassWord = Console.ReadLine();
            Console.Clear();

            string[] gebruiker = { UserName, PassWord };

            // if gebruiker is bekend -> MenuScherm

            // else
            Console.WriteLine("login klopt niet \n\nKlik R voor registreren\n\nKlik C voor Continue zonder inloggen\n\nKlik Enter voor opnieuw inloggen");

            var key = Console.ReadKey();

            // if (key == r) -> Naar registreer scherm

            // else if (key == c) -> naar menu scherm

            // else -> login()
        }
    }
}
