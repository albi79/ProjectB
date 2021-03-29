using System;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class Registreren
    {
        public static void registreren()
        {
            Console.Clear();
            string naam2 = Beheer.Input("Naam: ");
            string tussenvoegsel2 = Beheer.Input("Tussenvoegsel: ");
            string achternaam2 = Beheer.Input("Achternaam: ");
            string geboortedatum2 = Beheer.Input("Geboortedatum: ");
            string email2 = Beheer.Input("E-mail: ");
            string email22 = Beheer.Input("E-mail bevestiging: ");

            string opnieuwMail = "j";
            while (email2 != email22 && opnieuwMail == "j")
            {
                Console.WriteLine("Uw e-mail komt niet over een. Wilt u het opnieuw proberen?");
                Console.WriteLine("j voor ja");
                Console.WriteLine("n voor nee");
                opnieuwMail = Beheer.Input("");
                if (opnieuwMail == "n")
                {
                    Console.Clear();
                    Welkom.consoleMenu();
                }
                if (opnieuwMail == "j")
                {
                    email2 = Beheer.Input("E-mail: ");
                    email22 = Beheer.Input("E-mail bevestiging: ");
                    if(email2 == email22)
                    {
                        opnieuwMail = "n";
                    }
                }
                else
                {
                    Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                    opnieuwMail = "j";
                }
            }

            string gebruikersnaam2 = Beheer.Input("Gebruikersnaam: ");
            string wachtwoord2 = Beheer.Input("Wachtwoord: ");
            string wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");

            string opnieuwWachtwoord = "j";
            while (wachtwoord2 != wachtwoord22 && opnieuwWachtwoord == "j")
            {
                Console.WriteLine("Uw wachtwoord komt niet over een. Wilt u het opnieuw proberen?");
                Console.WriteLine("j voor ja");
                Console.WriteLine("n voor nee");
                opnieuwWachtwoord = Beheer.Input("");
                if (opnieuwWachtwoord == "n")
                {
                    Console.Clear();
                    Welkom.consoleMenu();
                }
                else if (opnieuwWachtwoord == "j")
                {
                    wachtwoord2 = Beheer.Input("Wachtwoord: ");
                    wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");
                    if (wachtwoord2 == wachtwoord22)
                    {
                        opnieuwWachtwoord = "n";
                    }
                }
                else
                {
                    Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                    opnieuwWachtwoord = "j";
                }
            }

            Person Gast = new Person
            {
                naam = naam2,
                tussenvoegsel = tussenvoegsel2,
                achternaam = achternaam2,
                geboortedatum = geboortedatum2,
                email = email2,
                gebruikersnaam = gebruikersnaam2,
                wachtwoord = wachtwoord2,
            };
            DataStorageHandler.Storage.Persons.Add(Gast);
            DataStorageHandler.SaveChanges();
            Console.Clear();
        }
    }
}
