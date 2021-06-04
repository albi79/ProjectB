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
            // controleer eerst of de naam niet leeg is en vervolgens of het alleen letters bevat.
            naam2 = OnlyLetters(Beheer.ControlEmpty(naam2));

            string tussenvoegsel2 = Beheer.Input("Tussenvoegsel: ");

            string achternaam2 = Beheer.Input("Achternaam: ");
            achternaam2 = OnlyLetters(Beheer.ControlEmpty(achternaam2));

            string geboortedatum2 = Beheer.Input("Geboortedatum: ");

            string email2 = Beheer.Input("E-mail: ");
            // controleer eerst of de email niet leeg is en vervolgens of het de email echt een email format is
            email2 = EmailControle(Beheer.ControlEmpty(email2));
            string email22 = Beheer.Input("E-mail bevestiging: ");

            // check of de eerste ingevulde en tweede ingevulde email hetzelfde is
            string opnieuwMail = "1";
            // blijf door loopen zolang de emails niet overeen komen met elkaar
            while (email2 != email22 && opnieuwMail == "1")
            {
                // het komt niet overeen, dus het is FOUT ingevuld. Hierdoor is er voor gekozen om deze melding rood weer te geven
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw e-mail komt niet over een. Wilt u het opnieuw proberen?");
                // haal de rode letterkleur weg
                Console.ResetColor();
                // vraag de user of hij opnieuw de email wilt typen
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nee");
                opnieuwMail = Beheer.Input("");
                // als de user dit niet wilt, wordt hij doorverzonden naar de startscherm
                if (opnieuwMail == "2")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                // als de user dit wel opnieuw wilt invoeren vragen wij nog keer of hij de mail twee keer opnieuw kan typen
                if (opnieuwMail == "1")
                {
                    email2 = EmailControle(Beheer.Input("E-mail: "));
                    email22 = Beheer.Input("E-mail bevestiging: ");
                    if (email2 == email22)
                    {
                        Console.ResetColor();
                        // verander de var zodat het programma er niet meer doorheen loopt
                        opnieuwMail = "2";
                    }
                }
                // als de user geen 1 of 2 heeft gedrukt is er een fout input gegeven
                else
                {
                    Console.WriteLine("Verkeerd invoer, probeer het nogmaals.");
                    opnieuwMail = "1";
                }
            }

            string gebruikersnaam2 = Beheer.Input("Gebruikersnaam: ");
            gebruikersnaam2 = Beheer.ControlEmpty(gebruikersnaam2);

            // geef de user een melding in het Geel zodat het opvalt (kleur oranje zit er niet standaard bij)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Wachtwoord moet voldoen aan de volgende eisen, minimaal achter characters, één hoofdletter, één kleine letter en één cijfer bevatten.");
            Console.ResetColor();

            string wachtwoord2 = Beheer.Input("Wachtwoord: ");
            wachtwoord2 = WachtwoordControle(wachtwoord2);
            string wachtwoord22 = Beheer.Input("Wachtwoord bevestiging: ");

            // vergelijk de twee wachtwoorden
            string opnieuwWachtwoord = "1";
            while (wachtwoord2 != wachtwoord22 && opnieuwWachtwoord == "1")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Uw wachtwoord komt niet over een. Wilt u het opnieuw proberen?");
                Console.ResetColor();
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nee");
                opnieuwWachtwoord = Beheer.Input("");
                // als de user het niet opnieuw wilt proberen wordt hij teruggestuurd naar het startscherm
                if (opnieuwWachtwoord == "2")
                {
                    Console.Clear();
                    Startscherm.startscherm();
                }
                // laat de user opnieuw wachtwoorden invoeren
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

            // Sla de informatie op in een JSON file
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
            // sla de aanpassingen op zodat het opgeslagen wordt in JSON
            DataStorageHandler.SaveChanges();
            Console.Clear();

            // De user is aangepaakt
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uw gebruiker is met succes aangemaakt!");
            Console.ResetColor();
            Console.WriteLine("Waar wilt u nu naar toe?");
            Console.WriteLine("1. Terug naar startscherm");
            Console.WriteLine("2. Verder naar het applicatie menu");
            string GebruikerInput = Beheer.Input("");

            // ga naar het startscherm
            if (GebruikerInput == "1")
                Startscherm.startscherm();

            // ga naar het menu
            else if (GebruikerInput == "2")
                ConsoleMenu.consoleMenu(gebruikersnaam2);

            // user vult een verkeerde input in
            else
            {
                // loop totdat user 1 of 2 heeft ingevuld
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
            // Als het wachtwoord hoofdletter(s), kleine letter(s), cijfer(s) en groter of gelijk aan acht charakters is, is het wachtwoord goedgekeurd
            if (Regex.IsMatch(wachtwoord2, "[A-Z]") && Regex.IsMatch(wachtwoord2, "[a-z]") && Regex.IsMatch(wachtwoord2, "[0-9]") && wachtwoord2.Length >= 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw wachtwoord is goedgekeurd");
                Console.ResetColor();

            }
            // anders
            else
            {
                // zolang het wachtwoord niet aan de eisen voldoen
                while (!(Regex.IsMatch(wachtwoord2, "[A-Z]")) || !(Regex.IsMatch(wachtwoord2, "[a-z]")) || !(Regex.IsMatch(wachtwoord2, "[0-9]")) || wachtwoord2.Length < 8)
                {
                    // Er wordt precies gecontrolleerd welk charachter (hoofdletter, kleine letter, cijfer, wachtwoord lengte) er ontbreekt
                    // de charachter(s) die ontbreekt wordt vervolgens met rood door de Console.WriteLine getoond aan de gebruiker
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
                        Console.WriteLine("Uw wachtwoord is jammer genoeg niet goed gekeurd probeer het opnieuw.");
                    }
                    Console.ResetColor();
                    wachtwoord2 = WachtwoordControle(Beheer.Input("Wachtwoord: "));
                }
            }
            return wachtwoord2;
        }
        private static string EmailControle(string email2)
        {
            // als het ingevoerde informatie voldoet aan een email format, is de email met succes
            // ingevuld en zal er in het groen een goede melding getoond worden.
            // Doordat het goed is ingevuld hebben we ook voor groen gekozen
            if (new EmailAddressAttribute().IsValid(email2))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uw mail is goedgekeurd!");
                Console.ResetColor();
            }
            // als het geen email format is word een rode foutmelding getoond
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uw mail is foutgekeurd!");
                Console.ResetColor();
                // vraag opnieuw om een mail in te vullen
                email2 = EmailControle(Beheer.Input("E-mail: "));
                // check vervolgens of de mail niet leeg is
                email2 = Beheer.ControlEmpty(email2);

            }
            return email2;
        }
        private static string OnlyLetters(string var)
        {
            // checkt of deze string ook cijfers heeft (dit mag niet)
            if (Regex.IsMatch(var, "[0-9]"))
            {
                // zolang de variable 'var' cijfers bevat zal het doorloopen
                while (Regex.IsMatch(var, "[0-9]"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dit veld mag geen cijfers bevatten.");
                    Console.ResetColor();
                    string var2 = "";
                    var2 = Beheer.Input("Probeer het nogmaals: ");
                    // check of var2 wel ingevuld is
                    OnlyLetters(Beheer.ControlEmpty(var2));
                    // return de nieuwe variable
                    return var2;
                }

            }
            // return de meegegeven variable
            return var;
        }
    }
}