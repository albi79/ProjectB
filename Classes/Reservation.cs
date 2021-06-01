using System;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.Classes.Seats;

namespace ProjectB.Classes
{
    public class Reservation
    {
        public string ID { get; set; }
        public string Customer { get; set; }
        public string Filmtitel { get; set; }
        public string Datum { get; set; }
        public string Tijd { get; set; }
        public string Projectie { get; set; }
        public int Zaal { get; set; }
        public BaseSeat Seats { get; set; } = new BaseSeat(-1, -1, -1.00);
        public string Zitplaatstype { get; set; }
        public string Snack { get; set; }
        public double Snackprice { get; set; }
        public double Sumprice { get; set; }       
    }
}
