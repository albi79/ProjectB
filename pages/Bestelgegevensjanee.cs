using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Bestelgegevensjanee
    {
        public static string bestelgegevensjanee(string prompt2, string klantnaam, string filmtitel, string datum, string tijd, string projectie, int zaalnummer, string zitplaatstype, string snack, double snackPrice, double sumPrice, List<BaseSeat> selectedseatList, int ticketInput)
        {
            DataStorageHandler.SaveChanges();
            int rij = selectedseatList[0].Rij;
            string selectedseatListColumn = "";
            double totalseatprice = 0.0;

            for (int k = 0; k < selectedseatList.Count; k++)
            {
                if (k < selectedseatList.Count - 1)
                {
                    selectedseatListColumn += selectedseatList[k].Column + ", ";
                }
                else
                {
                    selectedseatListColumn += selectedseatList[k].Column;
                }
                totalseatprice += selectedseatList[k].Price;
            }
            
            string prompt = "\n" + prompt2 + "Controleer uw bestelgegevens\nDit is de informatie over uw bestelling:\n\nKlantnaam: " + klantnaam + "\nFilmtitel: " + filmtitel + "\nDatum: " + datum + "\nTijd: " + tijd + "\nProjectie: " + projectie + "\nZaal: " + zaalnummer + "\nAantal kaartjes: " + ticketInput + "\nRij: " + rij + "\nZitplaatsnummer(s): " + selectedseatListColumn + "\nZitplaatstype(s): " + zitplaatstype + "\nTotale zitplaatsprijs: €" + totalseatprice + "\nSnacks: " + snack + "\nSnackprijs: €" + snackPrice + "\nTotale prijs: €" + sumPrice+ "\n\nDoor verder te gaan, gaat u akkoord met dat alle bestelgegevens hierboven correct is.";
            string[] options = { "JA", "NEE" };
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
