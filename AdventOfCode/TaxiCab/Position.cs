namespace AdventOfCode.TaxiCab
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Position other)
        {
            if (other == null)
            {
                return false;
            }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
