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
                // if conditions for Shapes
                if(shapeName == "circle")
                {
                    return new Circle();
                }else if(shapeName == "rectangle")
                {
                return new Rectangle();
                }
                else if(shapeName == "triangle")
                {
                    return new Triangle();
                }
                else
                {
                    return null;
                }
               
        }
        }

    }