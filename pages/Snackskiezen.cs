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
            string prompt = "Kies uw snacks";
            string[] options = { "Popcorn Zoet", "Popcorn Zout", "Popcorn Mix", "Geen" };
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
