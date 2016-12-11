namespace AdventOfCode.BathroomSecurity
{
    using Common;

    public class Keypad
    {
        private readonly DirectionManager directionManager;

        private int[,] keypad = new int[3, 3]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };

        private Position currentPosition;

        public Keypad(DirectionManager directionManager, Position startPosition)
        {
            this.directionManager = directionManager;
            this.currentPosition = startPosition;
        }

        public void Move(Direction direction)
        {
            var offset = this.directionManager.GetOffset(direction);

            this.currentPosition.Move(offset);

            if (!this.IsWithinBounds())
            {
                // If we went out of bounds, reverse the move.
                this.currentPosition.MoveReverse(offset);
            }
        }

        private bool IsWithinBounds()
        {
            var xInBounds = this.currentPosition.X >= 0 && this.currentPosition.X < keypad.Length;
            var yInBounds = this.currentPosition.Y >= 0 && this.currentPosition.Y < keypad.Length;

            return xInBounds && yInBounds;
        }
    }
}
