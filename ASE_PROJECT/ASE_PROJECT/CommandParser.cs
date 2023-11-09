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
            string shapeName = parts[0].ToLower();
            if (!int.TryParse(parts[1], out int x) || !int.TryParse(parts[2], out int y))
            {
                return (null, 0, 0);
            }

            if (x < 0 || x >= canvasWidth || y < 0 || y >= canvasHeight)
            {
                return (null, 0, 0);
            }

            return (shapeName, x, y);
        }
    }
}
