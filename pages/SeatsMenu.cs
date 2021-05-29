using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectB.Classes;
using ProjectB.Classes.Seats;
using ProjectB.DAL;
using static System.Console;

namespace ProjectB
{
    public class SeatsMenu
    {
        public  int selectedRow;
        public  int selectedColumn;
        public  object[][] seats;
        public readonly  string Prompt;



        public SeatsMenu(string prompt, object[][] seats_)
        {
            Prompt = prompt;
            seats = seats_;
            selectedColumn = seats[0].Length / 2;
            selectedRow = seats.Length / 2;
          
        }

        public void Display(int selectedFilm, string datum, string tijd)
        {
            WriteLine(Prompt);
            for (int i =0; i < seats.Length; i++)
            {
                string row = "";
                for(int j =0; j < seats[i].Length; j++)
                {
                    bool SelectedSeat = i == selectedRow && j == selectedColumn;
                    object currentSeat = seats[i][j];
                    row += currentSeat;
                    string res = "";
                    if (SelectedSeat)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;

                    }
                    if (!SelectedSeat)
                    {
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }
                    if (currentSeat is MasterSeat Mseat)
                    {
                        ForegroundColor = Mseat.SelectedForegroundColor;
                        BackgroundColor = Mseat.SelectedBackgroundColor;
                        if (!SelectedSeat)
                        {
                            ForegroundColor = Mseat.NotSelectedForegroundColor;
                            BackgroundColor = Mseat.NotSelectedBackgroundColor;
                        }

                        res += Mseat.Icon;
                    }
                    else if (currentSeat is VipSeat seat2)
                    {
                        ForegroundColor = seat2.SelectedForegroundColor;
                        BackgroundColor = seat2.SelectedBackgroundColor;
                        if (!SelectedSeat)
                        {
                            ForegroundColor = seat2.NotSelectedForegroundColor;
                            BackgroundColor = seat2.NotSelectedBackgroundColor;
                        }
                        res += seat2.Icon;
                    }
                    else if (currentSeat is RegularSeat seat3)
                    {
                        ForegroundColor = seat3.SelectedForegroundColor;
                        BackgroundColor = seat3.SelectedBackgroundColor;
                        if (!SelectedSeat)
                        {
                            ForegroundColor = seat3.NotSelectedForegroundColor;
                            BackgroundColor = seat3.NotSelectedBackgroundColor;
                        }
                        res += seat3.Icon;
                    }

                    //int filmdatumIndex = 0;
                    //int filmtijdIndex = 0;

                    //for (int k = 0; k < DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment.Length; k++)
                    //{ 
                    //    if (DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment[k][0] == datum) 
                    //    {
                    //        filmdatumIndex = k;
                    //    }
                    //}

                    //for (int l = 0; l < DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment[filmdatumIndex].Length; l++)
                    //{
                    //    if (DataStorageHandler.Storage.Films[selectedFilm].Projectiemoment[filmdatumIndex][l] == tijd)
                    //    {
                    //        filmtijdIndex = l;
                    //    }
                    //}

                    if (currentSeat is VipSeat || currentSeat is MasterSeat || currentSeat is RegularSeat)
                    {
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations.Where(per => per.Datum == datum && per.Tijd == tijd && per.Filmtitel == DataStorageHandler.Storage.Films[selectedFilm].Titel))
                        {
                            if (reservation.Seats.Column == j && reservation.Seats.Rij == i)
                            {
                                res = "[_]";
                            }
                        }
                    }

                    else
                    {
                        res = "[ ]";
                    }

                    Write(res);
                }
                WriteLine("");
            }
           
        }

        public BaseSeat Run(int selectedFilm, string datum, string tijd, string bioscoopscherm)
        {
            ConsoleKey keyPressed = ConsoleKey.B;
            while (keyPressed != ConsoleKey.Enter || reservationcheck(selectedRow, selectedColumn, selectedFilm, datum, tijd) == false || seats[selectedRow][selectedColumn] == null)
            {
                Clear();
                Display(selectedFilm, datum, tijd);
                Console.WriteLine(bioscoopscherm);
                Console.WriteLine("\nLEGENDA:\n[R] = Reguliere zitplaats\n[V] = VIP zitplaats\n[M] = Master zitplaats\n[ ] = Geen zitplaats\n[_] = Al gereserveerde zitplaats");
                if (reservationcheck(selectedRow, selectedColumn, selectedFilm, datum, tijd) == false)
                {
                    Console.WriteLine("\nOPMERKING: Deze zitplaats is al gereserveerd.\n");
                }
                else if (seats[selectedRow][selectedColumn] == null)
                {
                    Console.WriteLine("\nOPMERKING: Deze zitplaats kunt u helaas niet reserveren.\n");
                }

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedRow++;

                    if (selectedRow > seats.Length - 1)
                    {
                        selectedRow = seats.Length - 1;
                    }
                }
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedRow--;
                    if (selectedRow < 0)
                    {
                        selectedRow = 0;
                    }
                }

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    selectedColumn--;
                    if (selectedColumn < 0)
                    {
                        selectedColumn = 0;
                    }
                }
                if (keyPressed == ConsoleKey.RightArrow)
                {
                    selectedColumn++;
                    if (selectedColumn > seats.Length -1)
                    {
                        selectedColumn %= 30 ;
                    }
                }
                ResetColor();

            }
            object obj = seats[selectedRow][selectedColumn];
            double p = 0.0;
            if (obj is RegularSeat) { RegularSeat s = (RegularSeat)obj; p = s.Price; }
            if (obj is VipSeat) { VipSeat s = (VipSeat)obj; p = s.Price; }
            if (obj is MasterSeat) { MasterSeat s = (MasterSeat)obj; p = s.Price; }
            BaseSeat selectedseat = new BaseSeat
            (
                selectedRow,
                selectedColumn,
                p
            );
         
            return selectedseat;
        }
        public bool reservationcheck (int selectedRow, int selectedColumn, int selectedFilm, string datum, string tijd)
        {
            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations.Where(per => per.Datum == datum && per.Tijd == tijd && per.Filmtitel == DataStorageHandler.Storage.Films[selectedFilm].Titel))
            {
                if (reservation.Seats.Column == selectedColumn && reservation.Seats.Rij == selectedRow)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
