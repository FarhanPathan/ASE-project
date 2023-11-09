using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_PROJECT
{
    public class Rectangle : Shape
    {
        public override void DrawLayout(Graphics graphics, int x, int y)
        {
            using (Brush brush = new SolidBrush(Color.BlueViolet))
            {
                graphics.FillRectangle(brush, x, y, 150, 100);
            }
        }
    }
}
