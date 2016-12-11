namespace AdventOfCode.TaxiCab
{
    using System;
    using System.Linq;
    using Common;

    public class TaxiCabSolver
    {
        public int Solve(string rawInstructions, bool stopEarly = false)
        {
            var parser = new InstructionParser();

            var instructions = parser.ParseInstructions(rawInstructions);

            var person = new Person(new OrientationManager(), new Position(0, 0), Orientation.North);

            // Follow instructions
            foreach(var instruction in instructions)
            {
                person.ExecuteInstruction(instruction);
            }

            Position stopPosition = person.CurrentPosition; ;

            if (stopEarly)
            {
                // Find first position visited twice
                var firstPositionVisitedTwice = person.PositionHistory
                        .GroupBy(p => new { p.X, p.Y })
                        .Where(g => g.Count() > 1)
                        .Select(g => g.FirstOrDefault())
                        .FirstOrDefault();

                if (firstPositionVisitedTwice != null)
                {
                    stopPosition = firstPositionVisitedTwice;
                }
            }

            return this.CalculateDistanceTravelled(stopPosition);
        }

        private int CalculateDistanceTravelled(Position position)
        {
            var totalDistanceTravelled =
                Math.Abs(position.X) +
                Math.Abs(position.Y);

            return totalDistanceTravelled;
        }
    }
}
