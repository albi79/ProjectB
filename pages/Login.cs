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

            //Gebruiker aangemaakt om code mee te checken
            Person guest = new Person();
            guest.gebruikersnaam = "Daniel22";
            guest.wachtwoord = "RotterdamAbi";

            //Input krijgen
            Console.WriteLine("Loginscherm\n");
            string loginGebruikersnaam = Beheer.Input("Gebruikersnaam: ");
            string loginWachtwoord = Beheer.Input("Wachtwoord: ");

            //Check of input correct is
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                if (loginGebruikersnaam == guest.gebruikersnaam && loginWachtwoord == guest.wachtwoord)
                {
                    ConsoleMenu.consoleMenu();
                }

                //verkeerd wachtwoord
                else if (loginGebruikersnaam != guest.gebruikersnaam && loginWachtwoord == guest.wachtwoord)
                {
                    Console.WriteLine("Verkeerd wachtwoord opgegeven\nKlik R voor opnieuw registreren\nKlik I voor opnieuw inloggen\nKlik M voor menu-scherm zonder inloggen");
                    string foutGebruiker = Beheer.Input(": ");

                    if (foutGebruiker == "i")
                        Login.login();

                    else if (foutGebruiker == "r")
                        Registreren.registreren();

                    else if (foutGebruiker == "m")
                        ConsoleMenu.consoleMenu();

                    else
                        Console.WriteLine("Er ging iets fout");
                }

                //onbestaande gebruiker
                else
                {
                    Console.WriteLine("Gebruiker niet bekend\nKlik R voor registreren\nKlik I voor opnieuw inloggen\nKlik M voor menu-scherm zonder inloggen");
                    string foutGebruiker = Beheer.Input(": ");

                    if (foutGebruiker == "i")
                        Login.login();

                    else if (foutGebruiker == "r")
                        Registreren.registreren();

                    else if (foutGebruiker == "m")
                        ConsoleMenu.consoleMenu();

                    else
                        Console.WriteLine("Er ging iets fout");
                }

                //Kladblaadje

                /*guest.gebruikersnaam == Beheer.Input("Gebruiker: ");
                Registreren.registreren();*/
            }
        }
    }
}
