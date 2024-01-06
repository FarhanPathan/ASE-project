using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ASE_PROJECT
{  
public partial class MainForm : Form
{
    private TextBox txtMultiline = new TextBox();
    private TextBox txtcmd = new TextBox();
    private Button button1 = new Button();
    private Button button2 = new Button();
    private Button btnClear = new Button();
    private PictureBox pictureBox1 = new PictureBox();
    private Graphics resultBoxGraphics;
    private CommandParserNew parser;
    private Label statusLabel = new Label();
    private Button btnSave = new Button();
    private Button btnOpen = new Button();
    private Button btnThread = new Button();
    private List<Form> additionalForms = new List<Form>();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
        this.resultBoxGraphics = pictureBox1.CreateGraphics();
        parser = new CommandParserNew(resultBoxGraphics);
    }

    /// <summary>
    /// Initializes the GUI components.
    /// </summary>
    private void InitializeComponent()
    {
        // Create and configure GUI components
        txtMultiline.Multiline = true;

        txtMultiline.Size = new System.Drawing.Size(360, 351);
        txtMultiline.Location = new System.Drawing.Point(30, 61);
        txtMultiline.Name = "txtMultiline";
        txtMultiline.Size = new System.Drawing.Size(360, 351);
        txtMultiline.TabIndex = 16;


        txtcmd.Size = new System.Drawing.Size(360, 22);
        txtcmd.Location = new System.Drawing.Point(30, 433);

        txtcmd.Enter += (sender, e) =>
        {
           
        };

            // add different buttons and their properties
        button1.Text = "Run";
        button1.TabIndex = 7;
        button1.Size = new System.Drawing.Size(75, 23);
        button1.Location = new System.Drawing.Point(30, 480);
        button1.Click += RunButton_Click;

        button2.Text = "Syntax";
        button2.TabIndex = 8;
        button2.Size = new System.Drawing.Size(75, 23);
        button2.Location = new System.Drawing.Point(143, 480);
        button2.Click += SyntaxCheckButton_Click;

        btnClear.Location = new System.Drawing.Point(270, 480);
        btnClear.Size = new System.Drawing.Size(75, 23);
        btnClear.TabIndex = 13;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += new System.EventHandler(this.button3_Click);


        btnSave.Text = "Save";
        btnSave.TabIndex = 15;
        btnSave.Size = new System.Drawing.Size(75, 23);
        btnSave.Location = new System.Drawing.Point(154, 26);
        btnSave.Click += (sender, e) =>
        {
            SaveButton_Click(sender, e, txtMultiline);
        };

        btnOpen.Text = "Open";
        btnOpen.TabIndex = 14;
        btnOpen.Size = new System.Drawing.Size(75, 23);
        btnOpen.Location = new System.Drawing.Point(30, 26);
        btnOpen.Click += (sender, e) =>
        {
            LoadButton_Click(sender, e, txtMultiline);
        };
        btnThread.Text = "Thread";
        btnThread.TabIndex = 18;
        btnThread.Size = new System.Drawing.Size(75, 23);
        btnThread.Location = new System.Drawing.Point(424, 433);

        btnThread.Click += OpenNewThread_Click;

        void OpenNewThread_Click(object? sender, EventArgs e)
        {
            // Create a new form on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                Form newForm = new Form();

                TextBox txtMultiline = new TextBox();
                txtMultiline.Multiline = true;
                txtMultiline.Size = new System.Drawing.Size(500, 200);
                txtMultiline.Location = new System.Drawing.Point(10, 10);


                Button btnSave = new Button();
                btnSave.Text = "Save";
                btnSave.Size = new System.Drawing.Size(195, 30);
                btnSave.Location = new System.Drawing.Point(10, 220);
                btnSave.Click += (sender, e) =>
                {
                    SaveButton_Click(sender, e, txtMultiline);
                };

                Button btnOpen = new Button();
                btnOpen.Text = "Open";
                btnOpen.Size = new System.Drawing.Size(195, 30);
                btnOpen.Location = new System.Drawing.Point(215, 220);
                btnOpen.Click += (sender, e) =>
                {
                    LoadButton_Click(sender, e, txtMultiline);
                };


                newForm.Size = new System.Drawing.Size(600, 300);
                newForm.StartPosition = FormStartPosition.CenterScreen;
                newForm.FormBorderStyle = FormBorderStyle.FixedSingle;

                newForm.Controls.Add(txtMultiline);

                newForm.Controls.Add(btnSave);
                newForm.Controls.Add(btnOpen);



                newForm.Show();

                additionalForms.Add(newForm);
            });
        }

        pictureBox1.Size = new System.Drawing.Size(350, 350);
        pictureBox1.Location = new System.Drawing.Point(421, 61);
        pictureBox1.BackColor = System.Drawing.Color.LightGray;
        this.Controls.Add(pictureBox1);

        // info label
        statusLabel.Text = "Position : ";
        statusLabel.TabIndex = 17;
        statusLabel.Size = new System.Drawing.Size(60, 30);
        statusLabel.Location = new System.Drawing.Point(421, 26);

        // Set up the form
        this.Text = "ASE PROJECT";
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Size = new System.Drawing.Size(823, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Controls.Add(txtMultiline);
        this.Controls.Add(txtcmd);
        this.Controls.Add(button1);
        this.Controls.Add(button2);
        this.Controls.Add(btnSave);
        this.Controls.Add(btnClear);
        this.Controls.Add(btnOpen);
        this.Controls.Add(btnThread);
        this.Controls.Add(pictureBox1);
        this.Controls.Add(statusLabel);
    }

    private async void RunButton_Click(object? sender, EventArgs e)
    {
        string command = txtcmd.Text.Trim();

        if (command == "")
        {
            if (txtMultiline.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtcmd.Text = "RUN";
                command = "RUN";
                    
                }
        }

        if (command == "RUN")
        {
                
            parser.ResetProgram();

            string mainFormProgram = txtMultiline.Text;

            // Create tasks for the main form program and additional forms
            var mainFormTask = Task.Run(() => ExecuteProgramOnUIThread(mainFormProgram));

            var additionalFormTasks = additionalForms
                .Select(form => Task.Run(() =>
                {
                    TextBox additionalFormProgramTextBox = form.Controls.OfType<TextBox>().FirstOrDefault()!;
                    string additionalFormProgram = additionalFormProgramTextBox.Text;
                    if (!string.IsNullOrWhiteSpace(additionalFormProgram))
                    {
                        ExecuteProgramOnUIThread(additionalFormProgram);
                    }
                }));

            await Task.WhenAll(mainFormTask, Task.WhenAll(additionalFormTasks));

            Point currentPosition = parser.GetCurrentPosition();
            bool isFillOn = parser.IsFillOn();
            string currentColor = parser.GetCurrentColor();


            statusLabel.Text = $"Position:"+currentPosition;
        }
        else
        {
            if (!parser.SyntaxCheckLine(command))
            {
                return;
            }

            int i = 0;
            parser.ExecuteCommand(command, ref i);
        }
    }

    private void ExecuteProgramOnUIThread(string program)
    {
        this.Invoke((MethodInvoker)delegate
        {
            // create a new parser for each program
            CommandParserNew parser = new CommandParserNew(resultBoxGraphics);

            if (!parser.SyntaxCheckProgram(program))
            {
                return;
            }

            parser.ExecuteProgram(program);
        });
    }

    private void SyntaxCheckButton_Click(object? sender, EventArgs e)
    {
        string programText = txtMultiline.Text;

        if (programText.Trim() == "")
        {
            // try to syntax check the command
            string command = txtcmd.Text.Trim();

            if (command == "")
            {
                MessageBox.Show("Please enter a command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (parser.SyntaxCheckLine(command))
            {
                MessageBox.Show("Syntax check successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Syntax was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return;
        }

        if (parser.SyntaxCheckProgram(programText))
        {
            MessageBox.Show("Syntax check successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Syntax was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            txtcmd.Text = string.Empty;
            txtMultiline.Text = string.Empty;
            pictureBox1.Image = null;
        }

        private void SaveButton_Click(object? sender, EventArgs e, TextBox programTextBox)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    File.WriteAllText(filePath, programTextBox.Text);
                    MessageBox.Show("Program saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void LoadButton_Click(object? sender, EventArgs e, TextBox programTextBox)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string program = File.ReadAllText(filePath);
                    programTextBox.Text = program;
                    MessageBox.Show("Program loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
}
