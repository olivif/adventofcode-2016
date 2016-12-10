namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using TaxiCab;

    public class InstructionParser
    {
        IDictionary<char, Direction> charDirectionMap = new Dictionary<char, Direction>()
        {
            { 'L', Direction.Left },
            { 'R', Direction.Right },
        };

        public IList<Instruction> ParseInstructions(string instructions)
        {
            // Split by ,
            var rawInstructions = instructions.Split(new string[] { ", " }, StringSplitOptions.None);

            // Parse into instructions
            var parsedInstructions = new List<Instruction>();

            foreach(var rawInstruction in rawInstructions)
            {
                var direction = this.ParseDirection(rawInstruction[0]);
                var distance = Int32.Parse(rawInstruction.Substring(1));

                var parsedInstruction = new Instruction()
                {
                    Direction = direction, 
                    Distance = distance
                };

                parsedInstructions.Add(parsedInstruction);
            }

            return parsedInstructions;
        }

        public Direction ParseDirection(char direction)
        {
            Direction parsedDirection;

            if (!charDirectionMap.TryGetValue(direction, out parsedDirection))
            {
                throw new InvalidOperationException();
            }

            return parsedDirection;
        }
    }
}
