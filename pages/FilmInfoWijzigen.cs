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
    class FilmInfoWijzigen
    {
        public static bool inputCheck(string wat)
        {
            Console.Clear();
            Console.WriteLine("Klopt de informatie die u wilt toevoegen?");
            Console.WriteLine();
            Console.WriteLine(wat);
            Console.WriteLine("1. Ja\n2. Nee");

            string antwoord = Beheer.Input();

            if (antwoord == "1")
                return true;
            if (antwoord == "2")
                return false;

            Console.Clear();
            Console.WriteLine("\nEr ging iets fout");
            Console.WriteLine();
            Console.WriteLine("Wilt u deze informatie definitief aan de film informatie toevoegen?");
            Console.WriteLine();
            Console.WriteLine(wat);
            Console.WriteLine("1. Ja\n2. Nee");

            antwoord = Beheer.Input();

            if (antwoord == "1")
                return true;
            else if (antwoord == "2")
                return false;
            else
                inputCheck(wat);

            return false;
        }
        public static void filmInfoWijzigen(int selectedFilm)
        {
            Console.Clear();

            Console.WriteLine("Informatie geselecteerde film\n\nWelke informatie wilt u veranderen:\n");
            Console.WriteLine();
            Console.WriteLine("1: Titel: " + DataStorageHandler.Storage.Films[selectedFilm].Titel);
            Console.WriteLine("2: Categorie: " + DataStorageHandler.Storage.Films[selectedFilm].Categorie);
            Console.WriteLine("3: Minimum leeftijd: " + DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
            Console.WriteLine("4: Beschrijving: " + DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
            Console.WriteLine("5: Projectie: " + DataStorageHandler.Storage.Films[selectedFilm].Projectie);
            Console.WriteLine("6: Taal: " + DataStorageHandler.Storage.Films[selectedFilm].Taal);
            Console.WriteLine("7: Ondertiteling: " + DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
            Console.WriteLine("8: Acteurs: " + DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
            Console.WriteLine("9: Regiseur: " + DataStorageHandler.Storage.Films[selectedFilm].Regisseur);

            string infoIndex = Beheer.Input("");
            bool correctAntwoord = infoIndex == "1" || infoIndex == "2" || infoIndex == "3" || infoIndex == "4" || infoIndex == "5" || infoIndex == "6" || infoIndex == "7" || infoIndex == "8" || infoIndex == "9";

            if (infoIndex == "1")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Titel);
                string nieuweInfo = Beheer.Input("Wat is de nieuwe titel: ");

                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Titel = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "2")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Categorie);
                string nieuweInfo = Beheer.Input("Wat is de nieuwe categorie: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Categorie = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "3")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Leeftijd);
                int nieuweInfo = Int32.Parse(Beheer.Input("Wat is de nieuwe minimale leeftijd: "));
                DataStorageHandler.Storage.Films[selectedFilm].Leeftijd = nieuweInfo;
                FilmprogrammaBeheren.filmprogrammaBeheren();
            }

            else if (infoIndex == "4")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Beschrijving);
                string nieuweInfo = Beheer.Input("Wat is de nieuwe beschrijving: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Beschrijving = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "5")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Projectie);
                string nieuweInfo = Beheer.Input("Wat is de nieuwe titel: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Projectie = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "6")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Taal);
                string nieuweInfo = Beheer.Input("Welke taal is de nieuwe hoofdtaal: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Taal = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "7")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling);
                string nieuweInfo = Beheer.Input("Wat is de nieuwe taal van de ondertiteling: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Ondertiteling = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "8")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Acteurs);
                string nieuweInfo = Beheer.Input("Wie zijn de nieuwe acteurs: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Acteurs = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            else if (infoIndex == "9")
            {
                Console.WriteLine(DataStorageHandler.Storage.Films[selectedFilm].Regisseur);
                string nieuweInfo = Beheer.Input("Wie is de nieuwe regisseur: ");
                if (inputCheck(nieuweInfo))
                {
                    DataStorageHandler.Storage.Films[selectedFilm].Regisseur = nieuweInfo;
                    FilmprogrammaBeheren.filmprogrammaBeheren();
                }
                else
                    filmInfoWijzigen(selectedFilm);
            }

            if (!correctAntwoord)
                filmInfoWijzigen(selectedFilm);
        }
    }
}
