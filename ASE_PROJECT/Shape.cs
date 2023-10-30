using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_PROJECT
{
    public abstract class Shape
    {
        // Variable define with graphics class and with x and y layouts
        public abstract void DrawLayout(Graphics graphics, int x, int y);
    }
}
