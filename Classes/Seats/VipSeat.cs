using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.Classes.Seats
{
    public class VipSeat : Seat
    {
        public override double Price { get; set; } = 15.00;
        public override string Icon { get; set; } = "[V]";
        public override ConsoleColor SelectedForegroundColor { get; set; } = ConsoleColor.Green;

    }
}
