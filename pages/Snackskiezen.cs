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
            string prompt = "Welkom bij de Bioscoop";
            string[] options = { "Popcorn Zoet", "Popcorn Zout", "Popcorn Mix" };
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
