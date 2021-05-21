using ProjectB.Classes.Seats;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes
{
    public abstract class Seat
    {
        public virtual double Price { get; set; } = -1.00;
        public virtual string Icon { get; set; } = "[*]";
        public virtual ConsoleColor SelectedForegroundColor { get; set; } = ConsoleColor.Black;
        public virtual ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleColor.White;

        public virtual ConsoleColor NotSelectedForegroundColor { get; set; } = ConsoleColor.White;
        public virtual ConsoleColor NotSelectedBackgroundColor { get; set; }=  ConsoleColor.Black;
    }
}
