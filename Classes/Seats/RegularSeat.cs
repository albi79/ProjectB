using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class RegularSeat : Seat
    {
        public override double Price { get; set; } = 7.50;
        public override string Icon { get; set; } = "[R]";
        public override ConsoleColor SelectedForegroundColor { get; set; } = ConsoleColor.DarkBlue;
    }
}
