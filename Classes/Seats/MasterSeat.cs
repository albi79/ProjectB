using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class MasterSeat : Seat
    {
        public override double Price { get; set; } = 30.00;
        public override string Icon { get; set; } = "[M]";
        public override ConsoleColor SelectedForegroundColor { get; set; } = ConsoleColor.DarkBlue;
    }
}
