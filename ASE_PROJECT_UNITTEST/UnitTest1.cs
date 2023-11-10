using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_PROJECT_UNITTEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidSyntex()
        {
            var circle = new Circle();
            string[] commandParts = { "CIRCLE", "50" };

            // Act
            bool result = circle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidArgument() 
        {
            var circle = new Circle();
            string[] commandParts = { "CIRCLE" }; // Missing radius

            // Act
            bool result = circle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument count should return false.");
        }

        [TestMethod]
        public void InvalidRadius() 
        {
            var circle = new Circle();
            string[] commandParts = { "CIRCLE", "abc" }; // Non-integer radius

            // Act
            bool result = circle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid radius should return false.");
        }
        
    }
}
