﻿using System;
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
        public static void beoordeling(string gebruikersnaam, int selectedFilm)
        {
            int huidigeBeoordeling = 0;


            Console.Clear();

            Console.WriteLine("Beoordeling " + DataStorageHandler.Storage.Films[selectedFilm].Titel + "\n");
            string ShuidigeBeoordeling = Beheer.Input("typ 1(slecht) tot 5(geweldig) om de film te beoordelen: ");
            try
            {
                huidigeBeoordeling = Int32.Parse(ShuidigeBeoordeling);

                if (huidigeBeoordeling != 1 && huidigeBeoordeling != 2 && huidigeBeoordeling != 3 && huidigeBeoordeling != 4 && huidigeBeoordeling != 5)
                {
                    Console.WriteLine("Verkeerde input!\n\nTyp Enter");
                    Beheer.Input();
                    beoordeling(gebruikersnaam, selectedFilm);
                }
            }
            catch { Console.WriteLine("Verkeerde input!\n\nTyp Enter"); Beheer.Input(); beoordeling(gebruikersnaam, selectedFilm); }

            DataStorageHandler.Storage.Films[selectedFilm].AantalBeoordelingen++;
            DataStorageHandler.Storage.Films[selectedFilm].BeoordelingCumulatief += huidigeBeoordeling;
            DataStorageHandler.Storage.Films[selectedFilm].Beoordeling = DataStorageHandler.Storage.Films[selectedFilm].BeoordelingCumulatief / DataStorageHandler.Storage.Films[selectedFilm].AantalBeoordelingen;


            DataStorageHandler.SaveChanges();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bedankt voor uw beoordeling!\n");
            Console.ResetColor();
            ConsoleMenu.consoleMenu(gebruikersnaam);
        }
    }
}