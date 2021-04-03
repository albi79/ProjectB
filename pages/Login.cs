using System;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    public class Login
    {
        public static void login()
        {
            Console.Clear();

            //Input krijgen
            Console.WriteLine("Login-scherm\n");
            string loginGebruikersnaam = Beheer.Input("Gebruikersnaam: ");
            string loginWachtwoord = Beheer.Input("Wachtwoord: ");

            //Check of input correct is
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                if (loginGebruikersnaam == person.gebruikersnaam && loginWachtwoord == person.wachtwoord)
                {
                    Console.Clear();
                    ConsoleMenu.consoleMenu();
                }
            }

            Console.Clear();
            Console.WriteLine("Gebruiker onbekend\n\nKlik: 'r' voor opnieuw registreren\nKlik: 'i' voor opnieuw inloggen\nKlik: 'm' voor menu-scherm zonder inloggen");
            string foutGebruiker = Beheer.Input(": ");

            if (foutGebruiker == "i")
                Login.login();

            else if (foutGebruiker == "r")
                Registreren.registreren();

            else if (foutGebruiker == "m")
                ConsoleMenu.consoleMenu();

            else
                Console.WriteLine("Er ging iets fout");

            while (foutGebruiker != "i" || foutGerbuiker != "r" || foutGebruiker !=)
            {
                continue;
            }
        }
    }
}
