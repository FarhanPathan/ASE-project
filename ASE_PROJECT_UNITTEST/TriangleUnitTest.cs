using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_PROJECT_UNITTEST
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var triangle = new Triangle();
            string[] commandParts = { "TRIANGLE", "50", "50" };

            // Act
            bool result = triangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidArgument()
        {
            // Arrange
            var triangle = new Triangle();
            string[] commandParts = { "TRIANGLE", "50" }; // Missing height

            // Act
            bool result = triangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument count should return false.");
        }

        [TestMethod]
        public void InvalidHeight()
        {
            // Arrange
            var triangle = new Triangle();
            string[] commandParts = { "TRIANGLE", "abc", "100" }; // Non-integer base length

            // Act
            bool result = triangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid base length should return false.");
        }

        [TestMethod]
        public void InvalidWidth()
        {
            // Arrange
            var triangle = new Triangle();
            string[] commandParts = { "TRIANGLE", "50", "xyz" }; // Non-integer height

            // Act
            bool result = triangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid height should return false.");
        }

        
    }
}
