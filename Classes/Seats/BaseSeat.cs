using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class BaseSeat
    {

        public int Rij;
        public int Column;
        public double Price;

        public BaseSeat(int rij, int column, double price)
        {
            Rij = rij;
            Column = column;
            Price = price;
        }
    }
}