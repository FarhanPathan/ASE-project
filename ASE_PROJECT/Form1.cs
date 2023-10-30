using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtcmd.Text;

            var (shapeName, x, y) = new CommandParser().ParseCommand(input, pictureBox1.Width, pictureBox1.Height);

            if (shapeName != null)
                
            {
                
                
                if (shapeName == "circle")
                {
                    Shape shape1 = new Circle();
                }
                else if (shapeName == "rectangle")
                {
                    Shape shape2 = new Rectangle();
                }

                Shape shape = new MyShape().shapeCreation(shapeName);
                if (shape != null)
                {
                    Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        shape.DrawLayout(graphics, x, y);
                    }

                    pictureBox1.Image = bitmap;
                }
                else
                {
                    MessageBox.Show("Shape is not proper.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Inputs.");
            }
        

    }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
