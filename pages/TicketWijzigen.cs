using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class TicketWijzigen
    {
        public static void ticketWijzigen(string gebruikersnaam, int ticketIndex)
        {
            int indexOfGebruiker = 0;
            foreach (Person person in DataStorageHandler.Storage.Persons)
                if (gebruikersnaam == person.gebruikersnaam)
                    indexOfGebruiker = DataStorageHandler.Storage.Persons.IndexOf(person);

            bool wijzigbaar = true;

            string filmDatum = DataStorageHandler.Storage.Reservations[ticketIndex].Datum;
            string filmDag = $"{filmDatum[0]}{filmDatum[1]}";
            string filmMaand = $"{filmDatum[3]}{filmDatum[4]}";
            string filmJaar = $"{filmDatum[6]}{filmDatum[7]}{filmDatum[8]}{filmDatum[9]}";

            string filmUur = $"{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[0]}{DataStorageHandler.Storage.Reservations[ticketIndex].Tijd[1]}";

            int jaar = Int32.Parse(filmJaar);
            int maand = Int32.Parse(filmMaand);
            int dag = Int32.Parse(filmDag);
            int uur = Int32.Parse(filmUur);

            DateTime loginMoment = DataStorageHandler.Storage.Persons[indexOfGebruiker].loginMoment;
            int loginJaar = loginMoment.Year;
            int loginMaand = loginMoment.Month;
            int loginDag = loginMoment.Day;
            int loginUur = loginMoment.Hour;

            if (loginJaar <= jaar)
            {
                if (loginMaand < maand)
                {
                    wijzigbaar = true;
                }
                else if (loginMaand == maand)
                {
                    if (loginDag < dag)
                    {
                        if (loginUur < uur)
                        {
                            wijzigbaar = true;
                        }
                    }
                    else
                        wijzigbaar = false;
                }
                else
                    wijzigbaar = false;
            }
            else
                wijzigbaar = false;

            if (wijzigbaar == false)
            {
                Console.Clear();
                Console.WriteLine("De projectie van de geselecteerde filmticket begint binnen 24 uur of is al geweest.\nU kunt deze ticket niet meer wijzigen of annuleren\n\n");
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }

            Console.WriteLine("\n1. ticket wijzigen\n2. ticket annuleren\n0. Terug");
            string optie = Beheer.Input("");

            if (optie == "1")
            {
                Console.Clear();
                Console.WriteLine("Wat wilt u aan uw ticket veranderen\n1. Snacks\n2. Datum / Tijd\n0. Terug\n");
                string veranderInput = Beheer.Input("");

                if (veranderInput == "0" || veranderInput == "1" || veranderInput == "2")
                {
                    Console.Clear();
                    VeranderTicket.veranderTicket(gebruikersnaam, veranderInput, ticketIndex, indexOfGebruiker);
                }
                else
                {
                    Console.Clear();
                    Console.Write("Er gaat iets fout, probeer het opnieuw\n");
                    ticketWijzigen(gebruikersnaam, ticketIndex);
                }
            }
            else if(optie == "2")
            {
                Console.WriteLine("\nWeet u zeker dat u de ticket permanent wilt annuleren?\n1. JA\n2. NEE");
                string inp = Beheer.Input("");
                if (inp == "1")
                {
                    Console.Clear();
                    DataStorageHandler.Storage.Reservations.RemoveAt(ticketIndex);
                    Console.WriteLine("\nUw ticket is succesvol verwijdert.\nTyp Enter");
                    Beheer.Input();

                    DataStorageHandler.SaveChanges();

                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else
                {
                    Console.Clear();
                    ticketWijzigen(gebruikersnaam, ticketIndex);
                }
            }
            else if(optie == "0")
            {
                Console.Clear();
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Foutieve Input, probeer opnieuw\n");
                ticketWijzigen(gebruikersnaam, ticketIndex);
            }
        }
    }
}

