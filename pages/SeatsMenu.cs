using System;
using System.Collections.Generic;
using System.Text;
using ProjectB.Classes;
using ProjectB.Classes.Seats;
using static System.Console;

namespace ProjectB
{
    public class SeatsMenu
    {
        public  int SelectedRow;
        public  int SelectedColumn;
        public  object[][] seats;
        public readonly  string Prompt;



        public SeatsMenu(string prompt, object[][] seats_)
        {
            Prompt = prompt;
            seats = seats_;
            SelectedColumn = 0;
            SelectedRow = 0;
          
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
                    bool SelectedSeat = i == SelectedRow && j == SelectedColumn;
                    object choosenSeat = seats[i][j];             
                    row += choosenSeat;
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
                    if (choosenSeat is MasterSeat Mseat)
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
                    else if (choosenSeat is VipSeat seat2)
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
                    if(!(choosenSeat is VipSeat || choosenSeat is MasterSeat))
                    {
                        res += "NO VIP SEAT]";
                    }
                    Write(res);
                }
                WriteLine("");
            }
           
        }

        public BaseSeat Run()
        {
            ConsoleKey keyPressed = ConsoleKey.B;
            while (keyPressed != ConsoleKey.Enter)
            {
                Clear();
                Display();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedRow++;

                    if (SelectedRow > seats.Length - 1)
                    {
                        SelectedRow = seats.Length - 1;
                    }
                }
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedRow--;
                    if (SelectedRow < 0)
                    {
                        SelectedRow = 0;
                    }
                }

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedColumn--;
                    if (SelectedColumn < 0)
                    {
                        SelectedColumn = 0;
                    }
                }
                if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedColumn++;
                    if (SelectedColumn > seats.Length -1)
                    {
                        SelectedColumn = seats.Length -1 ;
                    }
                }
                ResetColor();

            }
            var obj = seats[SelectedRow][SelectedColumn];
            double p = 0.0;
            if (obj is VipSeat) { VipSeat s = (VipSeat)obj; p = s.Price; }
            if (obj is MasterSeat) { MasterSeat s = (MasterSeat)obj; p = s.Price; }
            BaseSeat selectedseat = new BaseSeat
            (
                null,
                SelectedRow,
                SelectedColumn,
                p
            );
         
            return selectedseat;
        }
    }
}
