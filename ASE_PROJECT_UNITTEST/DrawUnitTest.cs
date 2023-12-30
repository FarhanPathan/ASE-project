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
    public class DrawUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var draw = new Draw();
            string[] commandParts = { "DRAW", "50", "50" };

            // Act
            bool result = draw.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void MissingYPosition()
        {
            // Arrange
            var draw = new Draw();
            string[] commandParts = { "DRAW", "50" }; // Missing Y position

            // Act
            bool result = draw.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidYPosition()
        {
            // Arrange
            var draw = new Draw();
            string[] commandParts = { "DRAW", "10", "ABC" }; // Non-integer Y position

            // Act
            bool result = draw.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Invalid Y position should return false.");
        }


    }
}
