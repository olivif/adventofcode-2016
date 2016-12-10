namespace AdventOfCode.Tests
{
    using System;
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
