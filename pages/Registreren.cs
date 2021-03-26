using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class Registreren
    {
        public static void registreren()
        {
            Console.Clear();
            Person Gast = new Person
            {
                naam = Beheer.Input("Naam: "),
                tussenvoegsel = Beheer.Input("Tussenvoegsel: "),
                achternaam = Beheer.Input("Achternaam: "),
                geboortedatum = Beheer.Input("Geboortedatum: "),
                email = Beheer.Input("E-mail: "),
                email2 = Beheer.Input("E-mail bevestiging: "),
                gebruikersnaam = Beheer.Input("Gebruikersnaam: "),
                wachtwoord = Beheer.Input("Wachtwoord: "),
                wachtwoord2 = Beheer.Input("Wachtwoord bevestiging: "),
            };
            DataStorageHandler.Storage.Personen.Add(Gast);            
        }
    }
}
