using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Snackskiezen
    {
        public static string snackskiezen()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "STAP 5: Kies uw snacks";
            string[] options = { "Popcorn Zoet", "Popcorn Zout", "Popcorn Mix", "Groot Popcorn Zoet", "Groot Popcorn Zout", "Groot Popcorn Mix", "Geen", "Terug gaan" };
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
