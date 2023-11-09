using System.Drawing;
/*
 * This file is parent file of all shapes and other commands
 * It is 2 methods one for syntex checking and another for executing command with some variables like height and width etc*/

namespace ASE_PROJECT
{


    public interface Shape
    {
        bool SyntaxCheck(string[] commandParts, bool showError = true);
        void Execute(string[] commandParts, ref int x, ref int y, ref Color penColor, ref bool fillShapes, Graphics graphics);
    }
}
