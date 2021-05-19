using System;
using System.Collections.Generic;
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
            selectedColumn = 22;
            selectedRow = 0;
          
        }

        public void Display()
        {
            Clear();
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

                    if (currentSeat is VipSeat || currentSeat is MasterSeat || currentSeat is RegularSeat)
                    {
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
                        {
                            if (reservation.Seats.Column == j && reservation.Seats.Rij == i)
                            {
                                res = "[ ]";
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

        public BaseSeat Run()
        {
            ConsoleKey keyPressed = ConsoleKey.B;
            while (keyPressed != ConsoleKey.Enter || reservationcheck(selectedRow, selectedColumn) == false)
            {
                Clear();
                Display();
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
                null,
                selectedRow,
                selectedColumn,
                p
            );
         
            return selectedseat;
        }
        public bool reservationcheck (int selectedRow, int selectedColumn)
        {
            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations)
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
