using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class AdminAanmaken
    {
        public static void adminAanmaken()
        {
            //Admin account hardcoden
            Person Admin = new Person
            {
                naam = "",
                tussenvoegsel = "",
                achternaam = "",
                geboortedatum = "",
                email = "AdminBios",
                gebruikersnaam = "AdminBios",
                wachtwoord = "Nimda2021",
            };
            DataStorageHandler.Storage.Persons.Add(Admin); 
            DataStorageHandler.SaveChanges();
            Startscherm.startscherm();
        }
    }
}
