using System;

namespace AdventOfCode.TaxiCab
{
    public class Coordinates
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Coordinates other)
        {
            if (other == null)
            {
                return false;
            }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
