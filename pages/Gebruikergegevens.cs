using System;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    public class Gebruikergegevens
    {
        public static void gebruikergegevens(string gebruikersnaam)
        {
            // doorloop alle personen in de JSON file
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                // zoek de gebruiker met het zelfde gebruikersnaam als de ingelogde gerbuiker
                if (gebruikersnaam == person.gebruikersnaam)
                {
                    // rode letters met een groene onderkant
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Goedendag " + person.naam + ",");
                    Console.ResetColor();
                    Console.WriteLine("\nUw gegevens: ");
                    Console.WriteLine("  Naam: " + person.naam);
                    Console.WriteLine("  Tussenvoegsel: " + person.tussenvoegsel);
                    Console.WriteLine("  Achternaam: " + person.achternaam);
                    Console.WriteLine("  Gebruikersnaam: " + person.gebruikersnaam);
                    Console.WriteLine("  Geboortedatum: " + person.geboortedatum);
                    Console.WriteLine("  E-mail: " + person.email);
                    break;
                }
            }
            // Legenda voor de gebruiker
            Console.WriteLine("\n\n1. Wijzig mijn account gegevens");
            Console.WriteLine("2. Verwijder mijn account definitief");
            Console.WriteLine("b. Terug");
            string Terug = Beheer.Input("");
            // bekijk de ingevoerde string en voer de opdracht uit 
            bool backingoption = false;
            while (backingoption == false)
            {
                if (Terug == "b")
                {
                    Console.Clear();
                    ConsoleMenu.consoleMenu(gebruikersnaam);
                    backingoption = true;
                }
                else if (Terug == "1")
                {
                    Console.Clear();
                    gebruikergegevensWijzigen(gebruikersnaam);
                    backingoption = true;
                }
                else if (Terug == "2")
                {
                    gebruikergegevensVerwijderen(gebruikersnaam);
                    backingoption = true;
                }
                // Als de user een verkeerd input geeft
                else
                {
                    Console.WriteLine("\nFOUTMELDING: er is een ongeldige toets ingevoerd.\nToets b om terug te gaan.");
                    Terug = Beheer.Input("");
                }
            }
        }
        public static void gebruikergegevensWijzigen(string gebruikersnaam)
        {
            // vind de ingelogde user uit alle users
            foreach (Person person in DataStorageHandler.Storage.Persons)
            {
                if (gebruikersnaam == person.gebruikersnaam)
                {
                    // toon alle gegevens nogmaals met een nummer ervoor zodat de user kan selecteren welke hij wilt wijzigen
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Goedendag " + person.naam + ",");
                    Console.ResetColor();
                    Console.WriteLine("\nWat wilt u wijzigen (vul het nummer in die u wilt wijzigen): ");
                    Console.WriteLine("  1. Naam: " + person.naam);
                    Console.WriteLine("  2. Tussenvoegsel: " + person.tussenvoegsel);
                    Console.WriteLine("  3. Achternaam: " + person.achternaam);
                    Console.WriteLine("  4. Geboortedatum: " + person.geboortedatum);
                    Console.WriteLine("  5. E-mail: " + person.email);
                    Console.WriteLine("Uw gebruikersnaam '" + person.gebruikersnaam + "' kunt u niet wijzigen.");
                    Console.WriteLine("b. Terug");

                    string infoIndex = Beheer.Input("");
                    if (infoIndex == "b")
                    {
                        Console.Clear();
                        gebruikergegevens(gebruikersnaam);
                    }
                    // als de gebruiker de naam wilt aanpassen
                    else if (infoIndex == "1")
                    {
                        // de nieuweInfo variable is een string die de nieuwe info in dit geval de nieuwe naam opvraagd
                        string nieuweInfo = Beheer.Input("Vul uw naam in: ");
                        // Vraag de gebruiker of hij het zekerweet met het wijzigen van deze informatie
                        // zo ja wijzig het en sla de veranderingen op
                        if (FilmprogrammaBeheren.inputCheck(nieuweInfo))
                        {
                            person.naam = nieuweInfo;
                            DataStorageHandler.SaveChanges();
                            // verwijder alles van het scherm
                            Console.Clear();
                            // geef in het groen een melding dat het succesvol aangepast is
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uw nieuwe informatie is met succes opgeslagen!");
                            Console.ResetColor();
                            // stuur de user terug naar het overzicht
                            gebruikergegevens(gebruikersnaam);
                        }
                        // als de gebruiker het toch niet wilt wijzigen wordt hij terug gestuurd naar het overzicht
                        else
                        {
                            Console.Clear();
                            gebruikergegevensWijzigen(gebruikersnaam);
                        }
                    }
                    // wijzig tussenvoegsel
                    else if (infoIndex == "2")
                    {
                        string nieuweInfo = Beheer.Input("Vul uw tussenvoegsel in: ");

                        if (FilmprogrammaBeheren.inputCheck(nieuweInfo))
                        {
                            person.tussenvoegsel = nieuweInfo;
                            DataStorageHandler.SaveChanges();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uw nieuwe informatie is met succes opgeslagen!");
                            Console.ResetColor();
                            gebruikergegevens(gebruikersnaam);
                        }
                        else
                        {
                            Console.Clear();
                            gebruikergegevensWijzigen(gebruikersnaam);
                        }
                    }
                    // wijzig achternaam
                    else if (infoIndex == "3")
                    {
                        string nieuweInfo = Beheer.Input("Vul uw achternaam in: ");

                        if (FilmprogrammaBeheren.inputCheck(nieuweInfo))
                        {
                            person.achternaam = nieuweInfo;
                            DataStorageHandler.SaveChanges();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uw nieuwe informatie is met succes opgeslagen!");
                            Console.ResetColor();
                            gebruikergegevens(gebruikersnaam);
                        }
                        else
                        {
                            Console.Clear();
                            gebruikergegevensWijzigen(gebruikersnaam);
                        }
                    }
                    // wijzig geboortedatum
                    else if (infoIndex == "4")
                    {
                        string nieuweInfo = Beheer.Input("Geboortedatum: ");

                        if (FilmprogrammaBeheren.inputCheck(nieuweInfo))
                        {
                            person.tussenvoegsel = nieuweInfo;
                            DataStorageHandler.SaveChanges();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uw nieuwe informatie is met succes opgeslagen!");
                            Console.ResetColor();
                            gebruikergegevens(gebruikersnaam);
                        }
                        else
                        {
                            Console.Clear();
                            gebruikergegevensWijzigen(gebruikersnaam);
                        }
                    }
                    // wijzig mail
                    else if (infoIndex == "5")
                    {
                        string nieuweInfo = Beheer.Input("E-mail: ");

                        if (FilmprogrammaBeheren.inputCheck(nieuweInfo))
                        {
                            person.achternaam = nieuweInfo;
                            DataStorageHandler.SaveChanges();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uw nieuwe informatie is met succes opgeslagen!");
                            Console.ResetColor();
                            gebruikergegevens(gebruikersnaam);
                        }
                        else
                        {
                            Console.Clear();
                            gebruikergegevensWijzigen(gebruikersnaam);
                        }
                    }
                    // als er een ander nummer dan mogelijk is wordt ingevoerd wordt er een fout melding getoond, ook wordt de user terug gestuurd naar het overzicht
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("U heeft een verkeerde toets ingevuld. \nProbeer het opnieuw\n");
                        Console.ResetColor();
                        gebruikergegevensWijzigen(gebruikersnaam);
                    }
                    // stop de foreach loop
                    break;
                }
            }
        }
        public static void gebruikergegevensVerwijderen(string gebruikersnaam)
        {
            Console.Write("\n\nWeet u zeker dat u uw account ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("DEFINITIEF");
            Console.ResetColor();
            Console.Write(" wilt verwijderen?");
            Console.WriteLine("\n1. Ja\n2. Annuleer");
            string antwoordUser = Beheer.Input("");
            if (antwoordUser == "1")
            {
                try
                {
                    foreach (Person person in DataStorageHandler.Storage.Persons)
                    {
                        if (gebruikersnaam == person.gebruikersnaam)
                        {
                            DataStorageHandler.Storage.Persons.Remove(person);
                            DataStorageHandler.SaveChanges();
                            break;
                        }
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Uw account is met succes verwdijerd\n");
                    Console.ResetColor();
                    Startscherm.startscherm();

                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Er is iets misgegaan, excuses voor het ongemak!\n");
                    Console.ResetColor();
                    Startscherm.startscherm();
                }

            }
            else if (antwoordUser == "2")
            {
                Console.Clear();
                gebruikergegevens(gebruikersnaam);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Er ging iets mis probeer het opnieuw.");
                gebruikergegevens(gebruikersnaam);

            }
        }
    }
}
