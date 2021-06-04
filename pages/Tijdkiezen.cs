using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Tijdkiezen
    {
        public static string tijdkiezen(int selectedfilm, int selectedDate)
        {
            int datumIndex = selectedDate;

            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "STAP 2: Kies uw tijd";
            
            int aantalTijden = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment[datumIndex].Length;
            string[] tijdenOptions = new string[aantalTijden];

            for(int i = 0; i < aantalTijden; i++)
            {
                if (i < aantalTijden - 1)
                {
                    tijdenOptions[i] = DataStorageHandler.Storage.Films[selectedfilm].Projectiemoment[datumIndex][i + 1];
                }
                else
                {
                    tijdenOptions[i] = "Terug gaan";
                }
            }

            //string[] terugoptie = { "Terug gaan" };
            //tijdenOptions = tijdenOptions + terugoptie;
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, tijdenOptions);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return tijdenOptions[selectedIndex];
        }
    }
}
