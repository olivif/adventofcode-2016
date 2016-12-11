namespace AdventOfCode.TaxiCab
{
    using System.Collections.Generic;

    public class OrientationManager
    {
        private IList<Orientation> xOrientations = new List<Orientation>()
        {
            Orientation.North,
            Orientation.East,
            Orientation.South,
            Orientation.West,
        };

        public Orientation GetNextOrientation(Orientation currentOrientation, Direction direction)
        {
            var currentIndex = xOrientations.IndexOf(currentOrientation);
            var offsetIndex = 0;

            switch (direction)
            {
                case Direction.Left: offsetIndex--; break;
                case Direction.Right: offsetIndex++; break;
            }

            var index = currentIndex + offsetIndex;

            if (index < 0)
            {
                index = xOrientations.Count - 1;
            }

            if (index >= xOrientations.Count)
            {
                index = 0;
            }

            return xOrientations[index];
        }

        public Position GetPositionOffsetForOrientation(Orientation orientation)
        {
            var x = 0;
            var y = 0;

            switch (orientation)
            {
                case Orientation.North: y++; break;
                case Orientation.South: y--; break;
                case Orientation.East: x++; break;
                case Orientation.West: x--; break;
            }

            return new Position(x, y);
        }
    }
}
