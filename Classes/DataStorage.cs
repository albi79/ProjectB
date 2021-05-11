using System;
using System.Collections.Generic;

namespace ProjectB.Classes
{
    public class DataStorage
    {
        public List<Person> Persons { get; set; } = new List<Person>();
        public List<Film> Films { get; set; } = new List<Film>();
    }
}
