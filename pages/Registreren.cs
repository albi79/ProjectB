using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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
            naam2 = OnlyLetters(Beheer.ControlEmpty(naam2));

            string tussenvoegsel2 = Beheer.Input("Tussenvoegsel: ");

            string achternaam2 = Beheer.Input("Achternaam: ");
            achternaam2 = OnlyLetters(Beheer.ControlEmpty(achternaam2));

            string geboortedatum2 = Beheer.Input("Geboortedatum: ");

            string email2 = Beheer.Input("E-mail: ");
            email2 = EmailControle(Beheer.ControlEmpty(email2));
            string email22 = Beheer.Input("E-mail bevestiging: ");

            string opnieuwMail = "1";
            while (email2 != email22 && opnieuwMail == "1")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw e-mail komt niet over een. Wilt u het opnieuw proberen?");
                Console.ResetColor();
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nee");
                opnieuwMail = Beheer.Input("");
                if (opnieuwMail == "2")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                if (opnieuwMail == "1")
                {
                    email2 = EmailControle(Beheer.Input("E-mail: "));
                    email22 = Beheer.Input("E-mail bevestiging: ");
                    if (email2 == email22)
                    {
                        Console.ResetColor();
                        opnieuwMail = "2";
                    }
                }
                else
                {
                    Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                    opnieuwMail = "1";
                }
            }

            string gebruikersnaam2 = Beheer.Input("Gebruikersnaam: ");
            gebruikersnaam2 = uniekGebruikersnaam(Beheer.ControlEmpty(gebruikersnaam2));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Wachtwoord moet voldoen aan de volgende eisen, minimaal achter characters, één hoofdletter, één kleine letter en één cijfer bevatten.");
            Console.ResetColor();

            string wachtwoord2 = Beheer.Input("Wachtwoord: ");
            wachtwoord2 = WachtwoordControle(wachtwoord2);
            string wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");

            string opnieuwWachtwoord = "1";
            while (wachtwoord2 != wachtwoord22 && opnieuwWachtwoord == "1")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Uw wachtwoord komt niet over een. Wilt u het opnieuw proberen?");
                Console.ResetColor();
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nee");
                opnieuwWachtwoord = Beheer.Input("");
                if (opnieuwWachtwoord == "2")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                else if (opnieuwWachtwoord == "1")
                {
                    wachtwoord2 = Beheer.Input("Wachtwoord: ");
                    wachtwoord2 = WachtwoordControle(wachtwoord2);
                    wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");
                    if (wachtwoord2 == wachtwoord22)
                    {
                        opnieuwWachtwoord = "2";
                    }
                }
                else
                {
                    Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                    opnieuwWachtwoord = "1";
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uw gebruiker is met succes aangemaakt!");
            Console.ResetColor();
            Console.WriteLine("Waar wilt u nu naar toe?");
            Console.WriteLine("1. Terug naar startscherm");
            Console.WriteLine("2. Verder naar het applicatie menu\n");
            string GebruikerInput = Beheer.Input("");

            if (GebruikerInput == "1")
            {
                Console.Clear();
                Startscherm.startscherm();
            }

            else if (GebruikerInput == "2")
            {
                Console.Clear();
                ConsoleMenu.consoleMenu(gebruikersnaam2);
            }

            else
            {
                while (GebruikerInput != "1" || GebruikerInput != "2")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Er ging iets fout, probeer het opnieuw. Keuze uit 1 (startscherm) en 2 (applicatie menu).");
                    Console.ResetColor();
                    GebruikerInput = Beheer.Input("");
                    if (GebruikerInput == "1")
                        Startscherm.startscherm();

                    else if (GebruikerInput == "2")
                        ConsoleMenu.consoleMenu(gebruikersnaam2);
                }
            }

            ConsoleMenu.consoleMenu(gebruikersnaam2);

        }
        private static string WachtwoordControle(string wachtwoord2)
        {
            if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length >= 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw wachtwoord is goedgekeurd");
                Console.ResetColor();

            }
            else
            {
                while (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) || !(Regex.IsMatch(wachtwoord2, "[a-z]")) || !(Regex.IsMatch(wachtwoord2, "[0-9]")) || wachtwoord2.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een cijfer.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een cijfer en een kleine letter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een cijfer, een kleine letter en een hoofdletter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord is mist een cijfer en een hoofdletter.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een kleine letter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een kleine letter en een hoofdletter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length >= 8)
                    {
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een cijfer, een kleine letter, een hoofdletter en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een kleine letter en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een kleine letter, een hoofdletter en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een cijfer en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een kleine letter, cijfer en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter, cijfer en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length >= 8))
                    {
                        Console.WriteLine("Uw wachtwoord is korter dan acht characters.");
                    }
                    else
                    {
                        Console.WriteLine("Uw wachtwoord is helaas niet goed gekeurd probeer het opnieuw.");
                    }
                    Console.ResetColor();
                    wachtwoord2 = WachtwoordControle(Beheer.Input("Wachtwoord: "));
                }
            }
            return wachtwoord2;
        }
        private static string EmailControle(string email2)
        {
            if (new EmailAddressAttribute().IsValid(email2))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw mail is goedgekeurd!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw mail is foutgekeurd!");
                Console.ResetColor();
                email2 = EmailControle(Beheer.Input("E-mail: "));
                email2 = Beheer.ControlEmpty(email2);

            }
            return email2;
        }
        private static string OnlyLetters(string var)
        {
            if (Regex.IsMatch(var, "[0-9]"))
            {
                while (Regex.IsMatch(var, "[0-9]"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dit veld mag geen cijfers bevatten.");
                    Console.ResetColor();
                    string var2 = "";
                    var2 = Beheer.Input("Probeer het nogmaals: ");
                    OnlyLetters(Beheer.ControlEmpty(var2));
                    return var2;
                }

            }
            return var;
        }

        private static string uniekGebruikersnaam(string gebruikersnaam)
        {
            bool BestaandeGebruikersnaam = true;
            while (BestaandeGebruikersnaam)
            {
                foreach (Person person in DataStorageHandler.Storage.Persons)
                {
                    if (gebruikersnaam == person.gebruikersnaam)
                    {
                        
                        BestaandeGebruikersnaam = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("De gebruikersnaam die u heeft ingevoetd is jammer genoeg niet meer beschikbaar");
                        Console.ResetColor();
                        Console.WriteLine("Vul a.u.b. een unieke gebruikersnaam in.\n");
                        gebruikersnaam = Beheer.Input("Gebruikersnaam: ");
                        break;
                    }
                    else
                    {
                        BestaandeGebruikersnaam = false;
                    }
                }

            }
            if (BestaandeGebruikersnaam == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("U heeft een uniek gebruikersnaam ingevoerd!\n");
                Console.ResetColor();
            }
            return gebruikersnaam;
        }
    }
}