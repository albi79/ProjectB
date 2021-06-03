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
    class SalesOverview
    {
        public static void salesOverview()
        {
            Console.Clear();
            Console.WriteLine("Welkom bij de Sales Overview!\n\n");

            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"Reservering ID {reservation.ID}:");
                Console.ResetColor();

                double currenttotalseatprice = 0.0;

                for (int i = 0; i < reservation.Seats.Count; i++)
                {
                    currenttotalseatprice += reservation.Seats[i].Price;
                }

                if (currenttotalseatprice == (int)currenttotalseatprice)
                    Console.Write($"   €{currenttotalseatprice},-     {reservation.Customer} \n");
                else if (currenttotalseatprice == Math.Round(currenttotalseatprice, 1))
                    Console.Write($"   €{currenttotalseatprice}0    {reservation.Customer} \n");
                else
                    Console.Write($"   €{currenttotalseatprice}    {reservation.Customer} \n");
            }
            Console.WriteLine("\nWelk ID wilt u selecteren?\nDruk b om terug te gaan.");
            string Select = Beheer.Input("");
            int SelectSale = 0;
            if (Select == "b")
            {
                Console.Clear();
                AdminMenu.adminMenu();
            }
            else
            {
                try
                {
                    SelectSale = Int32.Parse(Select) - 1;
                }
                catch
                {
                    Console.WriteLine("Verkeerde input!\n\nTyp Enter"); Beheer.Input(); salesOverview();
                }
            }
            Console.WriteLine("\nFilmtitel: " + DataStorageHandler.Storage.Reservations[SelectSale].ID);
            string CustomerUsername = DataStorageHandler.Storage.Reservations[SelectSale].Customer;
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                if (CustomerUsername == person.gebruikersnaam)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Klant gegevens: ");
                    Console.ResetColor();
                    Console.WriteLine("     Naam: " + person.naam);
                    Console.WriteLine("     Tussenvoegsel: " + person.tussenvoegsel);
                    Console.WriteLine("     Achternaam: " + person.achternaam);
                    Console.WriteLine("     Gebruikersnaam: " + person.gebruikersnaam);
                    Console.WriteLine("     Geboortedatum: " + person.geboortedatum);
                    Console.WriteLine("     E-mail: " + person.email);
                    break;
                }
            }
            Console.WriteLine("Zaal: " + DataStorageHandler.Storage.Reservations[SelectSale].Zaal);
            Console.WriteLine("Projectie: ");
            Console.WriteLine("Rij: " + DataStorageHandler.Storage.Reservations[SelectSale].Seats[0].Rij);

            string selectedseatListColumn = "";
            double totalseatprice = 0.0;

            for (int i = 0; DataStorageHandler.Storage.Reservations[SelectSale].Seats.Count > i; i++)
            {
                if (DataStorageHandler.Storage.Reservations[SelectSale].Seats.Count > i + 1)
                {
                    selectedseatListColumn += DataStorageHandler.Storage.Reservations[SelectSale].Seats[i].Column + ", ";
                }
                else
                {
                    selectedseatListColumn += DataStorageHandler.Storage.Reservations[SelectSale].Seats[i].Column;
                }
                totalseatprice += DataStorageHandler.Storage.Reservations[SelectSale].Seats[i].Price;
            }

            Console.WriteLine("Stoelnummer(s): " + selectedseatListColumn);
            if (totalseatprice == (int)totalseatprice)
                Console.WriteLine("Projectie: €" + totalseatprice + ",-");
            else if (totalseatprice == Math.Round(totalseatprice, 1))
                Console.WriteLine("Projectie: €" + totalseatprice + "0");
            else
                Console.WriteLine("Projectie: €" + totalseatprice);

            Console.WriteLine("Snack: " + DataStorageHandler.Storage.Reservations[SelectSale].Snack);

            Console.WriteLine("\nDruk b om terug te gaan.");
            string Terug = Beheer.Input("");
            bool backingoption = false;
            while (backingoption == false)
            {
                if (Terug == "b")
                {
                    SalesOverview.salesOverview();
                    backingoption = true;
                }
                else
                {
                    Console.WriteLine("\nFOUTMELDING: er is een ongeldige toets ingevoerd. Toets b om terug te gaan.");
                    backingoption = false;
                }
            }
        }
    }
}