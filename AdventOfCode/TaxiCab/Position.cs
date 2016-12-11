namespace AdventOfCode.TaxiCab
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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

        public void Move(Position offsetPosition)
        {
            this.X += offsetPosition.X;
            this.Y += offsetPosition.Y;
        }

        public Position DeepCopy()
        {
            return new Position(this.X, this.Y);
        }
    }
}
