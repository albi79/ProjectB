using ProjectB;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Zitplaatsenkiezen3
    {
        public static BaseSeat zitplaatsenkiezen3()
        {
            object[][] seats500 = new object[][]
            {
            new object[]{ null, null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null, null  },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat() },
            new object[]{ null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new MasterSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new VipSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null },
            new object[]{ null, null, null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null, null, null },
            new object[]{ null, null, null, null, null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null, null, null, null, null },
            new object[]{ null, null, null, null, null, null, null, null, new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), new RegularSeat(), null, null, null, null, null, null, null, null }
            };
            string prompt3 = "Selecteer uw zitplaats in Zaal3";
            SeatsMenu zaal3 = new SeatsMenu(prompt3, seats500);
            zaal3.Display();
            BaseSeat selectedSeat3 = zaal3.Run();

            try
            {

                foreach (var item in DataStorageHandler.Storage.Reservations)
                {
                    if (selectedSeat3.Rij == item.Seats.Rij && selectedSeat3.Column == item.Seats.Column)
                    {
                        selectedSeat3 = null;
                        zitplaatsenkiezen3();
                    }
                }

            }
            catch (Exception) { };

            return selectedSeat3;
        }
    }
}
