using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASE_PROJECT;
using System.Windows.Forms;

// <summary>
// This class work is to split the inputs then parse and execute command for shapes and other commands.
// </summary>
public class CommandParserNew
{
    private Dictionary<string, Shape> commandDictionary;
    private Graphics graphics;
    private int x;
    private int y;
    private Color penColor = Color.Black;
    private bool fillShapes = false;
    

    /// <summary>
    /// Initializes a new instance of the CommandParser class.
    /// </summary>
    /// <param name="graphics">The Graphics object for drawing.</param>
    /// <param name="X">Use to get X-coordinate.</param>
    /// <param name="Y">Use to get Y-coordinate.</param>
    public CommandParserNew(Graphics graphics, int initialX = 0, int initialY = 0)
    {
        this.graphics = graphics;
        this.x = initialX;
        this.y = initialY;

        // Initialize the command dictionary with command names and their respective Shape Iterations
        commandDictionary = new Dictionary<string, Shape>
        {
            { "RECTANGLE", new Rectangle() },
            { "CIRCLE", new Circle() },
            { "TRIANGLE", new Triangle() },
            { "MOVE", new Move() },
            { "COLOR", new ColorCommand() },
            { "FILL", new Fill() },
            { "DRAW", new Draw() },
            { "RESET", new Reset() }
        };
    }

    /// <summary>
    /// Executes a single line command based on the inputs.
    /// </summary>
    /// <param name="commandText">The text of the command to execute.</param>
    public void ExecuteCommand(string commandText)
    {
        string[] parts = commandText.Split(' ');

        if (parts.Length == 0)
        {
            return;
        }

        // Initial one is the command name or shape name
        string commandName = parts[0].ToUpper();

        if (commandDictionary.ContainsKey(commandName))
        {
            Shape command = commandDictionary[commandName];

            if (command.SyntaxCheck(parts))
            {
                command.Execute(parts, ref x, ref y, ref penColor, ref fillShapes, graphics);
            }
            else
            {
                // Handle syntax error
                MessageBox.Show("Syntax error: " + commandName + " command format proper.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            // Handle run-time command
            MessageBox.Show("Error: Unsupported command - " + commandName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Executes a multi-line command based on the inputs.
    /// </summary>
    /// <param name="program">The program to execute.</param>
    public void ExecuteProgram(string program)
    {
        graphics.Clear(Color.LightGray);
        x = 0;
        y = 0;
        penColor = Color.Black;
        fillShapes = false;

        string[] lines = program.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            ExecuteCommand(line);
        }
    }

    /// <summary>
    /// Checks the syntax of the multi-line commands.
    /// </summary>
    /// <param name="program">The program to check.</param>
    public bool SyntaxCheckProgram(string program)
    {
        string[] lines = program.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < lines.Length; i++)
        {
            if (!SyntaxCheckLine(lines[i], i + 1))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Checks the syntax of a multi-line command.
    /// </summary>
    /// <param name="line">The command to check.</param>
    /// <param name="lineNumber">The line number of the command.</param>
    public bool SyntaxCheckLine(string line, int lineNumber = 0)
    {
        // Syntax rules
        string[] validCommands = commandDictionary.Keys.ToArray();

        // Split the line into words
        string[] words = line.Split(' ');

        if (words.Length == 0)
        {
            // Empty line
            return true;
        }

        // Check if the initial word is a valid command and it's in uppercase
        string firstWord = words[0].Trim();
        if (!validCommands.Contains(firstWord) || firstWord != firstWord.ToUpper())
        {
            // Invalid commands
            SyntaxErrorException(lineNumber, line, "Invalid command: (command must be in uppercase)");
            
            return false;
        }

        if (commandDictionary.ContainsKey(firstWord))
        {
            Shape command = commandDictionary[firstWord];

            if (command.SyntaxCheck(words))
            {
                return true;
            }
            else
            {
                SyntaxErrorException(lineNumber, line, "Syntax error in " + firstWord + " command.");
                return false;
            }
        }
        else
        {
            // Handle unsupported command
            SyntaxErrorException(lineNumber, line, "Unsupported command: " + firstWord);
            return false;
        }
    }

    /// <summary>
    /// Displays a syntax error message.
    /// </summary>
    /// <param name="line">The line number of the command.</param>
    /// <param name="command">The command text.</param>
    /// <param name="message">The error message.</param>
    private void SyntaxErrorException(int line, string command, string message = "")
    {
        //Alert shown in box
        MessageBox.Show("Syntax error at line " + line + ": " + command + "\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // utility functions to provide current settings of the resulting drawing
    public Point GetCurrentPosition()
    {
        return new Point(x, y);
    }

    public bool IsFillOn()
    {
        return fillShapes;
    }

    // return the current pen color as a string (e.g. "Black")
    public string GetCurrentColor()
    {
        return penColor.Name;
    }
}
