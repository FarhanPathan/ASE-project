using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_PROJECT_UNITTEST
{
    [TestClass]
    public class IfConditionUnitTest
    {
        [TestMethod]
        public void SyntaxCheck_ValidSyntax_ReturnsTrue()
        {
            // Arrange
            var ifCommand = new IfCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "IF", "20", ">", "10" };

            // Act
            bool result = ifCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidComparisonOperator_ReturnsFalse()
        {
            // Arrange
            var ifCommand = new IfCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "IF", "x", "INVALID", "10" }; // Invalid operator

            // Act
            bool result = ifCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid comparison operator should return false.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidFirstValue_ReturnsFalse()
        {
            // Arrange
            var ifCommand = new IfCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "IF", "abc", ">", "10" }; // Non-integer first value

            // Act
            bool result = ifCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid first value should return false.");
        }

        

        [TestMethod]
        public void Execute_ConditionFalse_SkipsCommands()
        {
            // Arrange
            var ifCommand = new IfCommand();
            var variables = new Dictionary<string, int> { { "x", 5 } };
            var methods = new Dictionary<string, string[]>();
            var isExecutingSpecialCommandStack = new Stack<bool>();
            var specialCommandsStack = new Stack<string>();
            int currentLineIndex = 0;

            // Nested command to simulate skipping
            specialCommandsStack.Push("IF");
            isExecutingSpecialCommandStack.Push(true);

            string[] commandParts = { "IF", "x", ">", "10" };

            // Act
            // Should not throw an exception
            ifCommand.Execute(commandParts, ref variables, ref methods, ref isExecutingSpecialCommandStack, ref specialCommandsStack, ref currentLineIndex);
        }

        
    }
}

