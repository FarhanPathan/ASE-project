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
    public class ColorUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var colorCommand = new ColorCommand();
            string[] commandParts = { "COLOR", "BLUE" };

            // Act
            bool result = colorCommand.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidArgument()
        {
            // Arrange
            var colorCommand = new ColorCommand();
            string[] commandParts = { "COLOR" }; // Missing color argument

            // Act
            bool result = colorCommand.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument should return false.");
        }

        [TestMethod]
        public void InvalidColorName()
        {
            // Arrange
            var colorCommand = new ColorCommand();
            string[] commandParts = { "COLOR", "INVALID" }; // Invalid color name

            // Act
            bool result = colorCommand.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid color name should return false.");
        }


    }
}
