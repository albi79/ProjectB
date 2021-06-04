using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Aantalticketkiezen
    {
        public static string aantalticketkiezen()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "STAP 3: Hoeveel kaartjes wilt u bestellen ? ";
            string[] options = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Terug gaan"};
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
