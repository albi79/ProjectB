using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProjectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gebruikersnaam:");
            string Gebruikersnaam = Console.ReadLine();

            Console.WriteLine("Wachtwoord:");
            string Wachtwoord = Console.ReadLine();

            Dictionary<string, string> Gebruikers = new Dictionary<string, string>
            {
                { "Gebruikersnaam", Gebruikersnaam },
                { "Wachtwoord", Wachtwoord },
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
