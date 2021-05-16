using ProjectB.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes
{
    public class DataStorage
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Film> Films { get; set; } = new List<Film>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
