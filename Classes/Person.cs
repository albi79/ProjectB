using System;
namespace ProjectB.Classes
{
    public class Person
    {
        public string naam { get; set; } // alleen letters - verplicht
        public string tussenvoegsel { get; set; } // alleen letters - optioneel
        public string achternaam { get; set; } // alleen letters - verplicht
        public string geboortedatum { get; set; } // datum maken - verplicht
        public string email { get; set; } //mail - verplicht
        public string gebruikersnaam { get; set; } //mail - verplicht
        public string wachtwoord { get; set; } //wachtwoord eisen toevoegen - verplicht 
    }
}
