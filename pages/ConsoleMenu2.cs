using ProjectB.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProjectB.pages
{
    class ConsoleMenu2
    {
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Prompt;

        public ConsoleMenu2(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
            DataStorageHandler.SaveChanges();
        }
        public void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];


                if (i == SelectedIndex)
                {

                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Blue;
                }
                else
                {

                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                WriteLine($"  << {currentOption} >>");
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed = ConsoleKey.B;
            while (keyPressed != ConsoleKey.Enter)
            {
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;


                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex >= Options.Length)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
            }
            return SelectedIndex;
        }
    }
}
