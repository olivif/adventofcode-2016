using System;
namespace AdventOfCode.TaxiCab
{
    using System.Collections.Generic;

    public class TaxiCabSolver
    {
        private Orientation defaultOrientation = Orientation.North;

        private IList<Orientation> xOrientations = new List<Orientation>()
        {
            Orientation.North,
            Orientation.East,
            Orientation.South,
            Orientation.West,
        };

        public int Solve(string rawInstructions, bool stopAfterSameLocation = false)
        {
            var parser = new InstructionParser();

            var instructions = parser.ParseInstructions(rawInstructions);

            // Follow instructions
            var currentOrientation = defaultOrientation;
            var steps = new Dictionary<Orientation, int>();

            // Initialize all steps to 0
            foreach(Orientation orientation in Enum.GetValues(typeof(Orientation)))
            {
                steps.Add(orientation, 0);
            }

            // Record all coordinates
            var coordinatesHistory = new List<Coordinates>();
            coordinatesHistory.Add(new Coordinates() { X = 0, Y = 0 });

            Coordinates coordinateVisitedTwice;

            // Calculate steps
            foreach (var instruction in instructions)
            {
                currentOrientation = this.GetNextOrientation(currentOrientation, instruction.Direction);

                steps[currentOrientation] += instruction.Distance;

                var coordinates = this.CalculateCoordinates(steps);

                if (stopAfterSameLocation && coordinatesHistory.Contains(coordinates))
                {
                    coordinateVisitedTwice = coordinates;
                }

                coordinatesHistory.Add(coordinates);
            }

            return this.CalculateTotalSteps(steps);
        }

        public Coordinates CalculateCoordinates(IDictionary<Orientation, int> steps)
        {
            var x = steps[Orientation.North] - steps[Orientation.South];
            var y = steps[Orientation.West] - steps[Orientation.East];

            return new Coordinates()
            {
                X = x,
                Y = y
            };
        }

        public int CalculateTotalSteps(IDictionary<Orientation, int> steps)
        {
            // Now work out the distance 
            var coordinates = this.CalculateCoordinates(steps);

            var totalSteps =
                Math.Abs(coordinates.X) +
                Math.Abs(coordinates.Y);

            return totalSteps;
        }

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
    }
}
