using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Datumentijdkiezen
    {
        public static string datumentijdkiezen()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Kies uw datum en tijd";
            string[] options = { "Popcorn Zoet", "Popcorn Zout", "Popcorn Mix", "Geen" };                
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
