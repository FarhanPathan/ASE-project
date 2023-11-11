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
    public class MoveUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var move = new Move();
            string[] commandParts = { "MOVE", "50", "50" };

            // Act
            bool result = move.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidXPosition()
        {
            // Arrange
            var move = new Move();
            string[] commandParts = { "MOVE", "abc", "50" }; // Non-integer X position

            // Act
            bool result = move.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid X position should return false.");
        }

        [TestMethod]
        public void InvalidYPosition()
        {
            // Arrange
            var move = new Move();
            string[] commandParts = { "MOVE", "50", "abc" }; // Non-integer Y position

            // Act
            bool result = move.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid Y position should return false.");
        }

        
    }
}
