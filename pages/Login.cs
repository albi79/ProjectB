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
                if (loginGebruikersnaam == "AdminBios" && loginWachtwoord == "Nimda2021")
                {
                    Console.Clear();
                    AdminMenu.adminMenu();
                }

                else if (loginGebruikersnaam == person.gebruikersnaam && loginWachtwoord == person.wachtwoord)
                {
                    Console.Clear();
                    person.loginMoment = DateTime.Now;
                    DataStorageHandler.SaveChanges();
                    ConsoleMenu.consoleMenu(loginGebruikersnaam);
                }
            }

            Console.Clear();
            Console.WriteLine("Gebruikersnaam en/of Wachtwoord komen niet overeen.\n\nKlik: '1' voor opnieuw inloggen\nKlik: '2' voor opnieuw registreren\nKlik: '3' voor terug naar het startscherm.");
            string foutGebruiker = Beheer.Input("");

            if (foutGebruiker == "1")
                Login.login(); 

            else if (foutGebruiker == "2")
                Registreren.registreren();

            else if (foutGebruiker == "3")
                Startscherm.startscherm();

            else
            {
                while (foutGebruiker != "i" || foutGebruiker != "r" || foutGebruiker != "m")
                {
                    Console.WriteLine("Er ging iets fout, probeer het opnieuw. Keuze uit 1 (inloggen), 2 (registreren) en 3 (startscherm)."); ;
                    foutGebruiker = Beheer.Input("");
                    if (foutGebruiker == "1")
                        Login.login();

                    else if (foutGebruiker == "2")
                        Registreren.registreren();

                    else if (foutGebruiker == "3")
                        Startscherm.startscherm();
                }
            }
        }
    }
}