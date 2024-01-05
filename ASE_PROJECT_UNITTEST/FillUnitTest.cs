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
    public class FillUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var fill = new Fill();
            string[] commandParts = { "FILL", "ON" };

            // Act
            bool result = fill.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "FILL ON/OFF syntax should return true.");
        }

        [TestMethod]
        public void MissingArgument()
        {
            // Arrange
            var fill = new Fill();
            string[] commandParts = { "FILL" }; // Missing argument

            // Act
            bool result = fill.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument count should return false.");
        }

        [TestMethod]
        public void InvalidValue()
        {
            // Arrange
            var fill = new Fill();
            string[] commandParts = { "FILL", "OnN" }; // Invalid fill value

            // Act
            bool result = fill.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid fill value should return false.");
        }


    }
}
