using System;
namespace AdventOfCode.Common
{
    public class DirectionManager
    {
        public Position GetOffset(Direction direction)
        {
            var x = 0;
            var y = 0;

            switch (direction)
            {
                case Direction.Up: y++; break;
                case Direction.Down: y--; break;
                case Direction.Right: x++; break;
                case Direction.Left: x--; break;
            }

            return new Position(x, y);
        }
    }
}
