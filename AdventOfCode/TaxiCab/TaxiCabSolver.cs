namespace AdventOfCode.TaxiCab
{
    public class TaxiCabSolver
    {

        public int Solve(string rawInstructions)
        {
            var parser = new InstructionParser();

            var instructions = parser.ParseInstructions(rawInstructions);

            // Follow instructions

            return 0;
        }

    }
}
