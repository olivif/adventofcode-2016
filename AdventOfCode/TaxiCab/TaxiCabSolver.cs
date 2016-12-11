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

        public int Solve(string rawInstructions)
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

            // Calculate steps
            foreach(var instruction in instructions)
            {
                currentOrientation = this.GetNextOrientation(currentOrientation, instruction.Direction);

                steps[currentOrientation] += instruction.Distance;
            }

            var totalSteps = this.CalculateTotalSteps(steps);

            return totalSteps;
        }

        public int CalculateTotalSteps(IDictionary<Orientation, int> steps)
        {
            // Now work out the distance 
            var totalSteps =
                Math.Abs(steps[Orientation.North] - steps[Orientation.South]) +
                Math.Abs(steps[Orientation.West] - steps[Orientation.East]);

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
