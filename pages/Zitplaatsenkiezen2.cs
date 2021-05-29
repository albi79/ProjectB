using ProjectB;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Zitplaatsenkiezen2
    {
        public static BaseSeat zitplaatsenkiezen2(int selectedFilm, string datum, string tijd)
        {
            object[][] seats300 = new object[][]
            {
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            };
            string prompt2 = "STAP 4: Selecteer uw zitplaats in Zaal2\n\n";
            int totaalColumn = 18 * 3 - 2;
            string bioscoopscherm = "";
            for (int i = 0; i < totaalColumn; i++)
            {
                bioscoopscherm += "=";
            }
            bioscoopscherm = "\n|" + bioscoopscherm + "|";
            SeatsMenu zaal2 = new SeatsMenu(prompt2, seats300);
            zaal2.Display(selectedFilm, datum, tijd);
            BaseSeat selectedSeat2 = zaal2.Run(selectedFilm, datum, tijd, bioscoopscherm);

            try
            {

                foreach (var item in DataStorageHandler.Storage.Reservations)
                {
                    if (selectedSeat2.Rij == item.Seats.Rij && selectedSeat2.Column == item.Seats.Column)
                    {
                        selectedSeat2 = null;
                        zitplaatsenkiezen2(selectedFilm, datum, tijd);
                    }
                }

            }
            catch (Exception) { };

            return selectedSeat2;
        }
    }
}
