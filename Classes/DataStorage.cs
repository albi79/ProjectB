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
        public List<VerwijderdeFilm> VerwijderdeFilms { get; set; } = new List<VerwijderdeFilm>();
        public List<ToekomstigeFilm> ToekomstigeFilms { get; set; } = new List<ToekomstigeFilm>();
        public List<VerwijderdeToekomstigeFilm> VerwijderdeToekomstigeFilms { get; set; } = new List<VerwijderdeToekomstigeFilm>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
