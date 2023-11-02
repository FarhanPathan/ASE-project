using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_PROJECT
{
    public class CommandParser
    {
        public (string ShapeName, int X, int Y) ParseCommand(string command, int canvasWidth, int canvasHeight)
        {
            string[] parts = command.Split(' ');
            if (parts.Length < 3)
            {
                return (null, 0, 0);
            }

            string shapeName = parts[0].ToLower();
            

            if (x < 0 || x >= canvasWidth || y < 0 || y >= canvasHeight)
            {
                return (null, 0, 0);
            }

            return (shapeName, x, y);
        }
    }
}
