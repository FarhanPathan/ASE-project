﻿using System;
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
        private List<Shape> storeShapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commandinput = txtcmd.Text;
            string multilineCmd = richTextBox1.Text;


            //string[] commands = commandinput.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);


            var (shapeName, x, y) = new CommandParser().ParseCommand(commandinput, pictureBox1.Width, pictureBox1.Height);

            if (shapeName != null)
                
            {   

                Shape shape = new MyShape().shapeCreation(shapeName);
                if (shape != null)
                {
                    storeShapes.Add(shape);
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

        private void button3_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                if (extension.ToLower() == ".txt")
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = opentext.FileName;
                richTextBox1.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtcmd.Text = string.Empty;
            richTextBox1.Text = string.Empty;

            //private Bitmap canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

    //        pictureBox1.Image = canvasBitmap;

        }
    }
}
