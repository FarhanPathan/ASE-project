using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_PROJECT
{
    public class MyShape
    {
            public Shape shapeCreation(string shapeName)
            {
                // switch conditions for Shapes
                switch (shapeName)
                {
                    case "circle":
                        return new Circle();
                    case "rectangle":
                        return new Rectangle();
                    case "triangle":
                    return new Triangle();
                default:
                        return null;
            }
        }
        }

    }