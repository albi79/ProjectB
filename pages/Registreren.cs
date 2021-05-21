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
            naam2 = Beheer.ControlEmpty(naam2);
            naam2 = OnlyString(naam2);

            string tussenvoegsel2 = Beheer.Input("Tussenvoegsel: ");
            string achternaam2 = Beheer.Input("Achternaam: ");
            achternaam2 = OnlyString(achternaam2);
            achternaam2 = Beheer.ControlEmpty(achternaam2);

            string geboortedatum2 = Beheer.Input("Geboortedatum: ");

            string email2 = Beheer.Input("E-mail: ");
            email2 = Beheer.ControlEmpty(email2);
            string email3 = EmailControle(email2);     

            string email22 = Beheer.Input("E-mail bevestiging: ");

            string opnieuwMail = "j";
            while (email3 != email22 && opnieuwMail == "j")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw e-mail komt niet over een. Wilt u het opnieuw proberen?");
                Console.WriteLine("j voor ja");
                Console.WriteLine("n voor nee");
                opnieuwMail = Beheer.Input("");
                if (opnieuwMail == "n")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                if (opnieuwMail == "j")
                {
                    email2 = Beheer.Input("E-mail: ");
                    email3 = EmailControle(email2);
                    email22 = Beheer.Input("E-mail bevestiging: ");
                    if (email3 == email22)
                    {
                        Console.ResetColor();
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
            gebruikersnaam2 = Beheer.ControlEmpty(gebruikersnaam2);
            Console.WriteLine("Wachtwoord moet voldoen aan de volgende eisen, minimaal achter characters, één hoofdletter, één kleine letter en één cijfer bevatten.");
            string wachtwoord2 = Beheer.Input("Wachtwoord: ");
            wachtwoord2 = WachtwoordControle(wachtwoord2);
            string wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");
            string opnieuwWachtwoord = "j";
            while (wachtwoord2 != wachtwoord22)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw wachtwoord komt niet over een. Wilt u het opnieuw proberen?");
                Console.WriteLine("j voor ja");
                Console.WriteLine("n voor nee");
                opnieuwWachtwoord = Beheer.Input("");
                if (opnieuwWachtwoord == "n")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                else if (opnieuwWachtwoord == "j")
                {
                    wachtwoord2 = Beheer.Input("Wachtwoord: ");
                    wachtwoord2 = WachtwoordControle(wachtwoord2);
                    wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");
                    if (wachtwoord2 == wachtwoord22)
                    {
                        Console.ResetColor();
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uw gebruiker is met succes aangemaakt!");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Waar wilt u nu naar toe?");
            Console.WriteLine("1. Terug naar startscherm");
            Console.WriteLine("2. Verder naar het applicatie menu");
            string GebruikerInput = Beheer.Input("");

            if (GebruikerInput == "1")
                Startscherm.startscherm();

            else if (GebruikerInput == "2")
                ConsoleMenu.consoleMenu(gebruikersnaam2);

            else
            {
                while (GebruikerInput != "1" || GebruikerInput != "2")
                {
                    Console.WriteLine("Er ging iets fout, probeer het opnieuw. Keuze uit 1 (startscherm) en 2 (applicatie menu).");
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
            if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length > 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw wachtwoord is goedgekeurd");

            }
            else
            {
                while (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) || !(Regex.IsMatch(wachtwoord2, "[a-z]")) || !(Regex.IsMatch(wachtwoord2, "[0-9]")) || wachtwoord2.Length < 8)
                {
                    if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een cijfer.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een cijfer en een kleine letter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een cijfer, een kleine letter en een hoofdletter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord is mist een cijfer en een hoofdletter.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een kleine letter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een kleine letter en een hoofdletter.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length > 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter.");
                    }


                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een cijfer, een kleine letter, een hoofdletter en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een kleine letter en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een kleine letter, een hoofdletter en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een cijfer en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && !(Regex.IsMatch(wachtwoord2, "[a-z]")) && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een kleine letter, cijfer en is korter dan acht characters.");
                    }
                    else if (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) && Regex.IsMatch(wachtwoord2, "[a-z]") && !(Regex.IsMatch(wachtwoord2, "[0-9]")) && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord mist een hoofdletter, cijfer en is korter dan acht characters.");
                    }
                    else if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && !(wachtwoord2.Length > 8))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord is korter dan acht characters.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uw wachtwoord is jammer genoeg niet goed gekeurd probeer het opnieuw.");
                    }
                    wachtwoord2 = Beheer.Input("Wachtwoord: ");
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
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw mail is foutgekeurd!");
                email2 = Beheer.Input("E-mail: ");
                email2 = Beheer.ControlEmpty(email2);
                email2 = EmailControle(email2);
            }
            Console.ResetColor();
            return email2;
        }
        private static string OnlyString(string var)
        {
            if (Regex.IsMatch(var, "[0-9]"))
            {
                while (Regex.IsMatch(var, "[0-9]"))
                {
                    Console.WriteLine("Dit veld mag geen cijfers bevatten.");
                    string var2 = "";
                    var2 = Beheer.Input("Probeer het nogmaals: ");
                    OnlyString(var2);
                    return var2;
                }
                
            }
            return var;
        }
    }
}
