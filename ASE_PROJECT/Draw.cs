using System;
using System.Drawing;
using ASE_PROJECT;

/// <summary>
/// Represents a command for drawing a line in a graphics context.
/// </summary>
public class Draw : Shape
{
    public bool SyntaxCheck(string[] commandParts, bool showError = true)
    {
        if (commandParts.Length < 2 || commandParts.Length > 3)
        {
            string errorMessage = "Syntax error: DRAW command should have 2 arguments.";
            if (showError)
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

        if (!int.TryParse(commandParts[1], out int x))
        {
            string errorMessage = "Syntax error: DRAW command x argument should be an integer.";
            if (showError)
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

        if (commandParts.Length == 3 && !int.TryParse(commandParts[2], out int y))
        {
            string errorMessage = "Syntax error: DRAW command x and y arguments should integers.";
            if (showError)
                // MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

        return true;
    }

    /// <summary>
    /// Executes the DRAW command by drawing a line in the graphics context.
    /// </summary>
    /// <param name="commandParts">An array of command parts.</param>
    /// <param name="x">The current X coordinate.</param>
    /// <param name="y">The current Y coordinate.</param>
    /// <param name="penColor">The current pen color.</param>
    /// <param name="fillShapes">A boolean indicating whether shapes should be filled.</param>
    /// <param name="graphics">The graphics context to draw on.</param>
    public void Execute(string[] commandParts, ref int x, ref int y, ref Color penColor, ref bool fillShapes, Graphics graphics)
    {
        if (SyntaxCheck(commandParts))
        {
            int penX = int.Parse(commandParts[1]);
            int penY = y;

            if (commandParts.Length == 3)
            {
                penY = int.Parse(commandParts[2]);
            }

            using (Pen pen = new Pen(penColor))
            {
                graphics.DrawLine(pen, x, y, penX, penY);
            }

            x = penX;
            y = penY;
        }
    }
}
