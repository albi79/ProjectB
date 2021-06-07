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
        public List<int> highlightedSeatsRows;
        public List<int> highlightedSeatsColumns;

        public SeatsMenu(string prompt, object[][] seats_, int ticketInput)
        {
            Prompt = prompt;
            seats = seats_;
            selectedColumn = seats[0].Length / 2;
            selectedRow = seats.Length / 2;
            highlightedSeatsRows = new List<int>();
            highlightedSeatsColumns = new List<int>();
        }

        public void Display(int selectedFilm, string datum, string tijd, int ticketInput)
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
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Blue;

                    }
                    if (!SelectedSeat)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
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
                        foreach (Reservation reservation in DataStorageHandler.Storage.Reservations.Where(per => per.Datum == datum && per.Tijd == tijd && per.Filmtitel == DataStorageHandler.Storage.Films[selectedFilm].Titel))
                        {
                            for (int k = 0; k < reservation.Seats.Count; k++)
                            {
                                if (reservation.Seats[k].Column == j && reservation.Seats[k].Rij == i)
                                {
                                    res = "[_]";
                                }
                            }
                        }
                        for (int l = 0; l < highlightedSeatsRows.Count; l++)
                        {
                            if (highlightedSeatsColumns[l] == j && highlightedSeatsRows[l] == i)
                            {
                                res = "[*]";
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

        public List<BaseSeat> Run(int selectedFilm, string datum, string tijd, string bioscoopscherm, int ticketInput)
        {
            ConsoleKey keyPressed = ConsoleKey.B;
            while (highlightedSeatsRows.Count < ticketInput || Reservationcheck(selectedFilm, datum, tijd) == false || seats[selectedRow][selectedColumn] == null)
            {
                Clear();
                Display(selectedFilm, datum, tijd, ticketInput);
                Console.WriteLine(bioscoopscherm);
                Console.WriteLine("\nLEGENDA:\n[R] = Reguliere zitplaats\n[V] = VIP zitplaats\n[M] = Master zitplaats\n[ ] = Geen zitplaats\n[_] = Al gereserveerde zitplaats\n\nDruk de ESCAPE toets in om terug te gaan");
                if (Reservationcheck(selectedFilm, datum, tijd) == false)
                {
                    Console.WriteLine("\nOPMERKING: Deze zitplaats is al gereserveerd.\n");
                }
                else if (seats[selectedRow][selectedColumn] == null)
                {
                    Console.WriteLine("\nOPMERKING: Deze zitplaats kunt u helaas niet reserveren.\n");
                }

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && highlightedSeatsRows.Count == 0)
                {
                    selectedRow++;

                    if (selectedRow > seats.Length - 1)
                    {
                        selectedRow %= 30;

                    }
                }
                if (keyPressed == ConsoleKey.UpArrow && highlightedSeatsRows.Count == 0)
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
                if (keyPressed == ConsoleKey.Enter)
                {
                    if (highlightedSeatsRows.Count < ticketInput && Selectedcheck() && Reservationcheck(selectedFilm, datum, tijd)) //dit moet in de selectedcheck gebruikt worden
                    {
                        highlightedSeatsRows.Add(selectedRow);
                        highlightedSeatsColumns.Add(selectedColumn);
                    }
                }
                ResetColor();
                if (keyPressed == ConsoleKey.Escape)
                {
                    break;
                }

            }
            List<BaseSeat> selectedseatList = new List<BaseSeat>();
            for (int l = 0; l < highlightedSeatsRows.Count; l++)
            {
                object obj = seats[highlightedSeatsRows[l]][highlightedSeatsColumns[l]];
                double p = 0.0;

                if (keyPressed == ConsoleKey.Escape)
                {
                    return null;
                }
                else
                {
                    if (obj is RegularSeat) { RegularSeat s = (RegularSeat)obj; p = s.Price; }
                    if (obj is VipSeat) { VipSeat s = (VipSeat)obj; p = s.Price; }
                    if (obj is MasterSeat) { MasterSeat s = (MasterSeat)obj; p = s.Price; }
                    BaseSeat selectedseat = new BaseSeat
                    (
                        highlightedSeatsRows[l],
                        highlightedSeatsColumns[l],
                        p
                    );
                    selectedseatList.Add(selectedseat);
                }
            }
         
            return selectedseatList;
        }
        public bool Reservationcheck (int selectedFilm, string datum, string tijd)
        {
            foreach (Reservation reservation in DataStorageHandler.Storage.Reservations.Where(per => per.Datum == datum && per.Tijd == tijd && per.Filmtitel == DataStorageHandler.Storage.Films[selectedFilm].Titel))
            {
                for (int m = 0; m < reservation.Seats.Count; m++)
                {
                    if (reservation.Seats[m].Column == selectedColumn && reservation.Seats[m].Rij == selectedRow)
                    {
                        return false;
                    }  
                }
            }
            return true;
        }
        public bool Selectedcheck()
        {
            for (int n = 0; n < highlightedSeatsRows.Count; n++)
            {
                if (highlightedSeatsColumns[n] == selectedColumn && highlightedSeatsRows[n] == selectedRow)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
