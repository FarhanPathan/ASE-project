using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_PROJECT_UNITTEST
{
    [TestClass]
    public class MethodUnitTest
    {
        [TestMethod]
        public void SyntaxCheck_UndefinedMethodCall_ReturnsFalse()
        {
            // Arrange
            var methodCommand = new MethodCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "UndefinedMethod(10,10,100,100)" };

            // Act
            bool result = methodCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Undefined method call should return false.");
        }
        [TestMethod]
        public void SyntaxCheck_MethodCallWithInvalidParameters_ReturnsFalse()
        {
            // Arrange
            var methodCommand = new MethodCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "DrawLine(10,'a',100,100)" }; // Non-integer parameter

            // Act
            bool result = methodCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Method call with invalid parameters should return false.");
        }

        [TestMethod]
        public void SyntaxCheck_InvalidMethodCall_ReturnsFalse()
        {
            // Arrange
            var methodCommand = new MethodCommand();
            var variables = new Dictionary<string, int>();
            var methods = new Dictionary<string, string[]>();
            string[] commandParts = { "DrawLine(10,10,100,100" }; // Missing closing bracket

            // Act
            bool result = methodCommand.SyntaxCheck(commandParts, ref variables, ref methods, false);

            // Assert
            Assert.IsFalse(result, "Invalid method call syntax should return false.");
        }
    }
}
