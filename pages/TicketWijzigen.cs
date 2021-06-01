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

            DateTime nu = DateTime.Now;
            int jaar = nu.Year;
            int maand = nu.Month;
            int dag = nu.Day;
            int uur = nu.Hour;

            DateTime loginMoment = DataStorageHandler.Storage.Persons[indexOfGebruiker].loginMoment;
            int loginJaar = loginMoment.Year;
            int loginMaand = loginMoment.Month;
            int loginDag = loginMoment.Day;
            int loginUur = loginMoment.Hour;

            if (loginJaar <= jaar)
            {
                if (loginMaand < maand)
                    wijzigbaar = true;
                else if (loginMaand == maand)
                {
                    if (loginDag < dag)
                    {
                        if (loginUur < uur)
                            wijzigbaar = true;
                        else
                            wijzigbaar = false;
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
                Console.WriteLine("De projectie van de geselecteerde filmticket begint binnen 24 uur of is al geweest.\nU kunt deze ticket niet meer wijzigen of annuleren\n\n");
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }



            Console.WriteLine("1. ticket wijzigen\n2. ticket annuleren\n0. Terug");
            string optie = Beheer.Input("");

            if (optie == "1")
            {
                Console.Clear();
                Console.WriteLine("Wat wilt u aan uw ticket veranderen\n1. Snacks\n2.Datum / Tijd\n.0 Terug");
                string veranderInput = Beheer.Input("");

                if (veranderInput == "0" || veranderInput == "1" || veranderInput == "2")
                    VeranderTicket.veranderTicket(gebruikersnaam, veranderInput, ticketIndex);
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
                    DataStorageHandler.Storage.Reservations.RemoveAt(ticketIndex);
                    Console.WriteLine("\nUw ticket is succesvol verwijdert.\nTyp Enter");
                    Beheer.Input();
                    //Moet ik niet nog ?'Data Safe Changes'? toevoegen, of slaat hij automatisch op.
                    TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
                }
                else
                    ticketWijzigen(gebruikersnaam, ticketIndex);
            }
            else if(optie == "0")
            {
                TicketTerugvinden.ticketTerugvinden(gebruikersnaam);
            }
            else
            {
                Console.WriteLine("Foutieve Input, probeer opnieuw\n");
                ticketWijzigen(gebruikersnaam, ticketIndex);
            }
        }
    }
}
