using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class BaseSeat
    {

        public Customer Customer;
        public int Row;
        public int Column;
        public double Price;

        public BaseSeat(Customer customer, int row, int column, double price)
        {
            Customer = customer;
            Row = row;
            Column = column;
            Price = price;
        }
    }
}
