using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    public class HuidigeFilms
    {
        public static void huidigeFilms()
        {
            Film huidigeFilms = new Film
            {
                Titel = "niew",
                Categorie = "niew",
                Leeftijd = 2
            };

            DataStorageHandler.Storage.Films.Add(huidigeFilms);
            DataStorageHandler.SaveChanges();
            AdminAanmaken.adminAanmaken();
        }
    }
}
