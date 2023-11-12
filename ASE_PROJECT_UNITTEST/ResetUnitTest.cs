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
    public class ResetUnitTest
    {
        [TestMethod]
        public void ValidSyntex()
        {
            // Arrange
            var reset = new Reset();
            string[] commandParts = { "RESET" };

            // Act
            bool result = reset.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsTrue(result, "Valid syntax should return true.");
        }

        [TestMethod]
        public void InvalidArgument()
        {
            // Arrange
            var reset = new Reset();
            string[] commandParts = { "RESET", "INVALID" }; // Invalid arguments

            // Act
            bool result = reset.SyntaxCheck(commandParts, false);

            // Assert
            Assert.IsFalse(result, "Invalid argument should return false.");
        }
    }
}