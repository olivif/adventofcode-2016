namespace AdventOfCode.Tests
{
    using System;
    using AdventOfCode.TaxiCab;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TaxiCab;

    [TestClass]
    public class InstructionParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InstructionParser_ParseDirection_InvalidKey()
        {
            // Arrange
            var directiomCharacter = 'x';
            var parser = new InstructionParser();

            // Act
            parser.ParseDirection(directiomCharacter);
        }

        [TestMethod]
        public void InstructionParser_ParseDirection_Left()
        {
            this.AssertDirectionParsed(
                directionCharacter: 'L', 
                expectedParsedDirection: Direction.Left);
        }

        [TestMethod]
        public void InstructionParser_ParseDirection_Right()
        {
            this.AssertDirectionParsed(
                directionCharacter: 'R',
                expectedParsedDirection: Direction.Right);
        }

        [TestMethod]
        public void InstructionParser_ParseInstruction_Left()
        {
            this.AssertParsedInstruction(
                rawInstruction: "L4",
                expectedInstruction: new Instruction()
                {
                    Direction = Direction.Left,
                    Distance = 4
                });
        }

        [TestMethod]
        public void InstructionParser_ParseInstruction_LeftLarge()
        {
            this.AssertParsedInstruction(
                rawInstruction: "L186",
                expectedInstruction: new Instruction()
                {
                    Direction = Direction.Left,
                    Distance = 186
                });
        }

        [TestMethod]
        public void InstructionParser_ParseInstruction_Right()
        {
            this.AssertParsedInstruction(
                rawInstruction: "R10",
                expectedInstruction: new Instruction()
                {
                    Direction = Direction.Right,
                    Distance = 10
                });
        }

        [TestMethod]
        public void InstructionParser_ParseInstructions_One()
        {
            this.AssertInstructionsCount(
                rawInstructions: "L4",
                expectedCount: 1);
        }

        [TestMethod]
        public void InstructionParser_ParseInstructions_Multiple()
        {
            this.AssertInstructionsCount(
                rawInstructions: "L4, R2, R4", 
                expectedCount: 3);
        }

        private void AssertParsedInstruction(string rawInstruction, Instruction expectedInstruction)
        {
            // Arrange
            var parser = new InstructionParser();

            // Act
            var instruction = parser.ParseInstruction(rawInstruction);

            // Assert
            Assert.IsNotNull(instruction);
            Assert.AreEqual(expectedInstruction.Direction, instruction.Direction);
            Assert.AreEqual(expectedInstruction.Distance, instruction.Distance);
        }

        public void AssertInstructionsCount(string rawInstructions, int expectedCount)
        {
            // Arrange 
            var parser = new InstructionParser();

            // Act
            var instructions = parser.ParseInstructions(rawInstructions);

            // Assert
            Assert.AreEqual(expectedCount, instructions.Count);
        }

        private void AssertDirectionParsed(char directionCharacter, Direction expectedParsedDirection)
        {
            // Arrange
            var parser = new InstructionParser();

            // Act
            var parsedDirection = parser.ParseDirection(directionCharacter);

            // Assert
            Assert.AreEqual(expectedParsedDirection, parsedDirection);
        }
    }
}
