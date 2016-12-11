namespace AdventOfCode.TaxiCab
{
    using System;

    public class TaxiCabSolver
    {

        public int Solve(string rawInstructions)
        {
            var parser = new InstructionParser();

            var instructions = parser.ParseInstructions(rawInstructions);

            var person = new Person(new OrientationManager(), new Position(0, 0), Orientation.North);

            // Follow instructions
            foreach(var instruction in instructions)
            {
                person.ExecuteInstruction(instruction);
            }

            var currentPosition = person.CurrentPosition;

            var totalDistanceTravelled = 
                Math.Abs(currentPosition.X) + 
                Math.Abs(currentPosition.Y);

            return totalDistanceTravelled;
        }
    }
}
