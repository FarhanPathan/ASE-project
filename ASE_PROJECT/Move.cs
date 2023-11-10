using System;
using System.Drawing;
using System.Windows.Forms;
using ASE_PROJECT;

/// <summary>
/// Represents a MOVE command that moves the drawing cursor to a new position.
/// </summary>
public class MoveCommand : Shape
{
    public bool SyntaxCheck(string[] commandParts, bool showError = true)
    {
        // The MOVE command should have 3 parts: MOVE x y
        if (commandParts.Length != 3)
        {
            string errorMessage = "Syntax error: MOVE command should have 2 arguments. X and Y axis.";
            if (showError)
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

        if (!int.TryParse(commandParts[1], out int x) || !int.TryParse(commandParts[2], out int y))
        {
            string errorMessage = "Syntax error: MOVE command arguments should be integers. X and Y axis.";
            if (showError)
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

        return true;
    }

    /// <summary>
    /// Executes the MOVE command, moving the drawing cursor to a new position.
    /// </summary>
    /// <param name="commandParts">An array of command parts.</param>
    /// <param name="x">Reference to the current X coordinate.</param>
    /// <param name="y">Reference to the current Y coordinate.</param>
    /// <param name="penColor">Reference to the current pen color.</param>
    /// <param name="fillShapes">Reference to the current fill shapes flag.</param>
    /// <param name="graphics">The <see cref="Graphics"/> object used for drawing.</param>
    public void Execute(string[] commandParts, ref int x, ref int y, ref Color penColor, ref bool fillShapes, Graphics graphics)
    {
        if (SyntaxCheck(commandParts))
        {
            x = int.Parse(commandParts[1]);
            y = int.Parse(commandParts[2]);
        }
    }
}
