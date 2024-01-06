using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_PROJECT_UNITTEST
{
    [TestClass]
    public class VariableUnitTest
    {
        [TestMethod]
        public void SyntaxCheck_ValidSyntax_ReturnsTrue()
        {
            // Arrange
            var variableCommand = new VariableCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "a", "=", "50" };

            // Act
            bool result = variableCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidArgumentsCount_ReturnsFalse()
        {
            // Arrange
            var variableCommand = new VariableCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "Count", "=" }; // Missing value

            // Act
            bool result = variableCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument count should return false.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidVariableName_ReturnsFalse()
        {
            // Arrange
            var variableCommand = new VariableCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "123", "=", "50" }; // Invalid variable name

            // Act
            bool result = variableCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid variable name should return false.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidOperator_ReturnsFalse()
        {
            // Arrange
            var variableCommand = new VariableCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "Count", "INVALID", "50" }; // Invalid operator

            // Act
            bool result = variableCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid operator should return false.");
        }

        [TestMethod]
        public void IsVariableAssignment_TooManyArguments_ReturnsFalse()
        {
            // Arrange
            string[] commandParts = { "Count", "=", "50", "+", "1", "extra" }; // Extra argument

            // Act
            bool result = VariableCommand.IsVariableAssignment(commandParts);

            // Assert
            Assert.IsFalse(result, "Should not be a valid variable assignment.");
        }
    }
}
