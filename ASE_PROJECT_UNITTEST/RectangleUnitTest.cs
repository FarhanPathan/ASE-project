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
    public class RectangleUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var rectangle = new Rectangle();
            string[] commandParts = { "RECTANGLE", "50", "50" };

            // Act
            bool result = rectangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidArgument()
        {
            // Arrange
            var rectangle = new Rectangle();
            string[] commandParts = { "RECTANGLE", "50" }; // Missing height

            // Act
            bool result = rectangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument count should return false.");
        }

        [TestMethod]
        public void InvalidHeight()
        {
            var rectangle = new Rectangle();
            string[] commandParts = { "RECTANGLE", "50", "abc" }; // Non-integer height

            // Act
            bool result = rectangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid height should return false.");
        }

        [TestMethod]
        public void InvalidWidth()
        {
            var rectangle = new Rectangle();
            string[] commandParts = { "RECTANGLE", "abc", "50" }; // Non-integer width

            // Act
            bool result = rectangle.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid width should return false.");
        }
    }
}
