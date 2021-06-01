using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Specifiekebestelinfoaanpassen
    {
        public static string specifiekebestelinfoaanpassen()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Selecteer welke gegeven u wilt wijzigen:";
            string[] options = { "Datum & Tijd", "Zitplaats", "Snacks", "Terug gaan"};
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
