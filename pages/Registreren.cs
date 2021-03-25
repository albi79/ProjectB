using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class Registreren
    {
        public static void registreren()
        {
            Console.WriteLine("Naam:");
            string naam = Console.ReadLine();

            Console.WriteLine("Tussenvoegsel:");
            string tussenvoegsel = Console.ReadLine();

            Console.WriteLine("Achternaam:");
            string achternaam = Console.ReadLine();

            Console.WriteLine("Geboortedatum:");
            string geboortedatum = Console.ReadLine();

            Console.WriteLine("E-mail:");
            string email = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("E-mail bevestiging:");
            string email2 = Console.ReadLine();

            Console.WriteLine("Gebruikersnaam:");
            string gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Wachtwoord:");
            string wachtwoord = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Wachtwoord bevestiging:");
            string wachtwoord2 = Console.ReadLine();

            Console.Clear();

            Dictionary<string, string> Gebruikers = new Dictionary<string, string>
            {
                { "Naam:", naam },
                { "Tussenvoegsel:", tussenvoegsel },
                { "Achternaam:", achternaam },
                { "Geboortedatum:", geboortedatum },
                { "E-mail:", email },
                { "E-mail bevestiging:", email2 },
                { "Gebruikersnaam:", gebruikersnaam },
                { "Wachtwoord:", wachtwoord },
                { "Wachtwoord bevestiging:", wachtwoord2 },
            };

            string json = JsonConvert.SerializeObject(Gebruikers, Formatting.Indented);
            string path = @"Gebruikers.json";

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(json.ToString());
                tw.Close();
            }
        }
    }
}
