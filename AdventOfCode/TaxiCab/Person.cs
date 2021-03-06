﻿namespace AdventOfCode.TaxiCab
{
    using System.Collections.Generic;
    using Common;

    public class Person
    {
        private readonly OrientationManager orientationManager;

        public Person(OrientationManager orientationManager, Position currentPosition, Orientation currentOrientation)
        {
            this.orientationManager = orientationManager;

            this.CurrentPosition = currentPosition;
            this.CurrentOrientation = currentOrientation;

            this.PositionHistory = new List<Position>();
            this.PositionHistory.Add(this.CurrentPosition.DeepCopy());
        }

        public Orientation CurrentOrientation { get; set; }

        public Position CurrentPosition { get; set; }

        public IList<Position> PositionHistory { get; set; }

        public void ExecuteInstruction(Instruction instruction)
        {
            // Figure out next orientation based on current orientation 
            this.CurrentOrientation = this.orientationManager.GetNextOrientation(this.CurrentOrientation, instruction.Direction);
            var positionOffset = this.orientationManager.GetPositionOffsetForOrientation(this.CurrentOrientation);

            // Create positions travelled
            for (int instructionStep = 0; instructionStep < instruction.Distance; instructionStep++)
            {
                this.CurrentPosition.Move(positionOffset);

                this.PositionHistory.Add(this.CurrentPosition.DeepCopy());
            }
        }
    }
}
