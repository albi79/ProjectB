using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class FilmprogrammaBeheren
    {
        public static void filmprogrammaBeheren()
        {
            List<string> films = new List<string>();

            Console.WriteLine("1. Film toevoegen");
            Console.WriteLine("2. Film verwijderen");

            Console.WriteLine(films);

            string gegeven = Beheer.Input("");

            if(gegeven == "1")
            {
                films.Add(Beheer.Input("Welke film wilt u toevoegen: "));
                FilmprogrammaBeheren.filmprogrammaBeheren();
            }

            else if(gegeven == "2")
            {
                Console.WriteLine(films);
                Console.WriteLine($"Film 1 - {films[0]}");
                films.RemoveAt(Convert.ToInt32(Beheer.Input(": ")));
            }
        }
    }
}