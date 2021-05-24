using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Tijdkiezen
    {
        public static string tijdkiezen(int selectedfilm)
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Kies uw datum en tijd";
            int aantalData = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment.Length;

            string[] dataOptions = new string[aantalData];

            for (int x = 0; x < DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment.Length; x++)
            {
                dataOptions[x] = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment[x][0];
            }

            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, dataOptions);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return dataOptions[selectedIndex];
        }
    }
}
