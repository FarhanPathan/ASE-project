using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ASE_PROJECT;

namespace ASE_PROJECT
{
    public partial class Form1 : Form
    {
        private List<Shape> storeShapes = new List<Shape>();
        private CommandParserNew parser;

        public Form1()
        {
            InitializeComponent();
            
            parser = new CommandParserNew(pictureBox1.CreateGraphics());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commandinput = txtcmd.Text.Trim(); ;
            if (commandinput == "")
            {
                txtcmd.Text = "RUN";
                if (txtcmd.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a command with UPPERCASE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    txtcmd.Text = "RUN";
                    commandinput = "RUN";
                }
            }

            if (commandinput == "RUN")
            {
                string program = txtMultiline.Text;

                if (!parser.SyntaxCheckProgram(program))
                {
                    return;
                }

                parser.ExecuteProgram(program);

            }
            else
            {
                if (!parser.SyntaxCheckLine(commandinput))
                {
                    return;
                }

                parser.ExecuteCommand(commandinput);

            }

            Point currentPosition = parser.GetCurrentPosition();
            bool isFillOn = parser.IsFillOn();
            string currentColor = parser.GetCurrentColor();

            statusLabel.Text = $"Position:" +currentPosition;

        }
        


       private void button3_Click(object sender, EventArgs e)
        {
            txtcmd.Text = string.Empty;
            txtMultiline.Text = string.Empty;
            pictureBox1.Image = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = opentext.FileName;
                txtMultiline.Text = selectedFileName;
                try
                {
                    string program = File.ReadAllText(selectedFileName);
                    txtMultiline.Text = program;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, txtMultiline.Text);
                    MessageBox.Show("Program saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string programText = txtMultiline.Text;

            if (parser.SyntaxCheckProgram(programText))
            {
                MessageBox.Show("Syntax check successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Syntax was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMultiline_TextChanged(object sender, EventArgs e)
        {

        }

     }
}


 