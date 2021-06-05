using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Datumkiezen
    {
        public static string datumkiezen(int selectedfilm, ref int selectedDate)
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "STAP 1: Kies uw datum";
            int aantalData = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment.Length;

            string[] dataOptions = new string[aantalData + 1];

            for(int x = 0; x < aantalData + 1; x++)
            {
                if (x < aantalData)
                {
                    dataOptions[x] = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment[x][0];
                }
                else
                {
                    dataOptions[x] = "Terug gaan";
                }
            }
            
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, dataOptions);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            selectedDate = selectedIndex;
            return dataOptions[selectedIndex];
        }
    }
}
