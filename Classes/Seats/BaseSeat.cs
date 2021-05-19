using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class BaseSeat
    {

        public Customer Customer;
        public int Rij;
        public int Column;
        public double Price;

        public BaseSeat(Customer customer, int rij, int column, double price)
        {
            Customer = customer;
            Rij = rij;
            Column = column;
            Price = price;
        }
    }
}
