using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.pages
{
    class Reserveren
    {
        public static void reserveren()
        {
            Console.Clear();
            Console.WriteLine("Hoeveel kaartjes wilt u bestellen?");

            bool validticketinput = false;

            string ticketinput;

            while (validticketinput == false)
            {
                ticketinput = Console.ReadLine();

                if (ticketinput == "1" | ticketinput == "2" | ticketinput == "3" | ticketinput == "4" | ticketinput == "5" | ticketinput == "6" | ticketinput == "7" | ticketinput == "8" | ticketinput == "9" | ticketinput == "10")
                {
                    Console.Clear();
                    validticketinput = true;
                    Zitplaatsenkiezen.zitplaatsenkiezen();
                }

                else
                {
                    Console.WriteLine("FOUTMELDING: Het aantal kaartjes moet minimaal 1 zijn en niet meer dan 10 zijn.");
                    validticketinput = false;
                }
            }
        }
    }
}
