using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Bestelgegevensjanee
    {
        public static string bestelgegevensjanee(string prompt2, string klantnaam, string filmtitel, string datum, string tijd, string projectie, int zaalnummer, int rij, int column, string zitplaatstype, double seatPrice, string snack, double snackPrice, double sumPrice)
        {
            DataStorageHandler.SaveChanges();
            string prompt = "\n" + prompt2 + "Controleer uw bestelgegevens\nDit is de informatie over uw bestelling:\n\nKlantnaam: " + klantnaam + "\nFilmtitel: " + filmtitel + "\nDatum: " + datum + "\nTijd: " + tijd + "\nProjectie: " + projectie + "\nZaal: " + zaalnummer + "\nRij: " + rij + "\nZitplaatsnummer: " + column + "\nZitplaatstype: " + zitplaatstype + "\nZitplaatsprijs: " + seatPrice + "\nSnacks: " + snack + "\nSnackprijs: " + snackPrice + "\nTotale prijs: " + sumPrice+ "\n\nDoor verder te gaan, gaat u akkoord met dat alle bestelgegevens hierboven correct is.";
            string[] options = { "JA", "NEE" };
            ConsoleMenu2 StartPagina = new ConsoleMenu2(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            return options[selectedIndex];
        }
    }
}
