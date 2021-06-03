using ProjectB;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Zitplaatsenkiezen
    {
        public static List<BaseSeat> zitplaatsenkiezen(int selectedFilm , string datum, string tijd, int ticketInput)
        {
            object[][] seats150 = new object[][]
            {
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            };
            string prompt = "STAP 4: Selecteer uw zitplaats in Zaal1\n";
            int totaalColumn = 12 * 3 - 2;
            string bioscoopscherm = "";
            for (int i = 0; i < totaalColumn; i++)
            {
                bioscoopscherm += "=";
            }
            bioscoopscherm = "\n|" + bioscoopscherm + "|" + "\n           BIOSCOOPSCHERM";
            SeatsMenu zaal1 = new SeatsMenu(prompt, seats150, ticketInput);
            zaal1.Display(selectedFilm, datum, tijd, ticketInput);
            List<BaseSeat> selectedseatList = zaal1.Run(selectedFilm, datum, tijd, bioscoopscherm, ticketInput);

            //try
            //{

            //    foreach (var item in DataStorageHandler.Storage.Reservations)
            //    {
            //        if (selectedSeat.Rij == item.Seats.Rij && selectedSeat.Column == item.Seats.Column)
            //        {
            //            selectedSeat = null;
            //            zitplaatsenkiezen(selectedFilm, datum, tijd);
            //        }
            //    }

            //}
            //catch (Exception) { };

            return selectedseatList;
        }
    }
}
