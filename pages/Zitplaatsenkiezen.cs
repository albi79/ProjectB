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
        public static BaseSeat zitplaatsenkiezen()
        {
            object[][] seats = new object[][]
            {
            new object[]{ new VipSeat(), new VipSeat() , new VipSeat()  },
            new object[]{ new VipSeat() , new VipSeat() , null },
            new object[]{ new VipSeat() , new VipSeat() , new MasterSeat() },
            };
            string prompt = "Welkom bij de Bioscoop";
            SeatsMenu zaal1 = new SeatsMenu(prompt, seats);
            zaal1.Display();
            BaseSeat selectedSeat = zaal1.Run();

            try
            {

                foreach (var item in DataStorageHandler.Storage.Reservations)
                {
                    if (selectedSeat.Row == item.Seats.Row && selectedSeat.Column == item.Seats.Column)
                    {
                        selectedSeat = null;
                        zitplaatsenkiezen();
                    }
                }

            }
            catch (Exception) { };

            return selectedSeat;
        }
    }
}
