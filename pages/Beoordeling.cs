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
    class Beoordeling
    {
        public static void beoordeling(/*selectedFilm*/string gebruikersnaam)
        {
            int huidigeBeoordeling = 0;

            int selectedFilm = 0;//Tijdelijk
            Console.Clear();

            Console.WriteLine("Beoordeling "+ DataStorageHandler.Storage.Films[selectedFilm].Titel + "\n");
            string ShuidigeBeoordeling = Beheer.Input("typ 1(slecht) tot 5(geweldig) om de film te beoordelen: ");
            try 
            { 
                huidigeBeoordeling = Int32.Parse(ShuidigeBeoordeling);

                if (huidigeBeoordeling != 1 && huidigeBeoordeling != 2 && huidigeBeoordeling != 3 && huidigeBeoordeling != 4 && huidigeBeoordeling != 5)
                {
                    Console.WriteLine("Verkeerde input!\n\nTyp Enter");
                    Beheer.Input();
                    beoordeling(gebruikersnaam);
                }
            }
            catch {Console.WriteLine("Verkeerde input!\n\nTyp Enter"); Beheer.Input(); beoordeling(gebruikersnaam); }

            DataStorageHandler.Storage.Films[selectedFilm].AantalBeoordelingen++; 
            DataStorageHandler.Storage.Films[selectedFilm].BeoordelingCumulatief += huidigeBeoordeling;
            DataStorageHandler.Storage.Films[selectedFilm].Beoordeling = DataStorageHandler.Storage.Films[selectedFilm].BeoordelingCumulatief / DataStorageHandler.Storage.Films[selectedFilm].AantalBeoordelingen;


            DataStorageHandler.SaveChanges();
            FilmprogrammaBeheren.filmprogrammaBeheren();
            
            Console.WriteLine("\nBedankt\n\nTyp Enter om terug te gaan naar het menu");

            Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Beoordeling);//Tijdelijk

            Beheer.Input();

            ConsoleMenu.consoleMenu(gebruikersnaam);
        }
    }
}
