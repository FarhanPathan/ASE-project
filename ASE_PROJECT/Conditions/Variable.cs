using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Represents a command to set a variable.
/// </summary>
public class VariableCommand: ISpecialCommand
{
    /// <summary>
    /// Checks the syntax of the Variable command.
    /// </summary>
    /// <param name="commandParts">An array of command parts.</param>
    /// <returns>True if the syntax is correct, otherwise false.</returns>
    /// <remarks>
    /// The Variable command should have 3 arguments: variable name, = sign and value.
    /// The variable name should be a string.
    /// The variable must have a = sign between the name and value.
    /// The value should be an integer.
    /// </remarks>
    /// <example>
    /// Count = 50
    /// </example>
    public bool SyntaxCheck(
        string[] commandParts,
        ref Dictionary<string, int> variables,
        ref Dictionary<string, string[]> methods,
        bool showError = true
    )
    {
        // The Variable command should have at least 3 parts: variable name, = sign and value
        if (commandParts.Length < 3)
        {
            string errorMessage = "Syntax error: Variable command should have at least 3 arguments. Variable name, = sign and value (e.g. Count = 50)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // The variable name should be a string
        if (double.TryParse(commandParts[0], out double variableName))
        {
            string errorMessage = "Syntax error: Variable command variable name argument should be a string (e.g. VAR Count = 50)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // The variable name should have an invalid word
        if (HasInvalidWord(commandParts[0]))
        {
            string errorMessage = "Syntax error: Variable command variable name argument should not contain a invalid word or symbol (e.g. VAR Count = 50)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // The variable must have a = sign between the name and value
        if (commandParts[1] != "=")
        {
            string errorMessage = "Syntax error: Variable command should have = sign between the variable name and value (e.g. VAR Count = 50)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // The value should be an integer
        if (!int.TryParse(commandParts[2], out int value))
        {
            string errorMessage = "Syntax error: Variable command value argument should be an integer (e.g. VAR Count = 50)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // If there is a 4th part, it should be an operator
        if (commandParts.Length > 3 && !"+-*/".Contains(commandParts[3]))
        {
            string errorMessage = "Syntax error: Variable command operator argument should be +, -, * or / (e.g. Count = 1 + 1)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // If there is a 5th part, it should be an integer
        if (commandParts.Length > 4 && !int.TryParse(commandParts[4], out int value2))
        {
            string errorMessage = "Syntax error: Variable command value argument should be an integer (e.g. Count = 1 + 1)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Command parts can not exceed 5 i.e variable = 1 + 1
        if (commandParts.Length > 5)
        {
            string errorMessage = "Syntax error: Variable command should have at most 5 arguments. Variable name, = sign, value, operator and value (e.g. Count = 1 + 1)";
            if (showError)
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Executes the Variable command to set a variable.
    /// </summary>
    /// <param name="commandParts">An array of command parts.</param>
    /// <param name="variables">A dictionary of variables.</param>
    /// <param name="methods">A dictionary of methods.</param>
	/// <param name="isExecutingSpecialCommandStack">A Stack of flags that indicates if a special command is being executed.</param>
    /// <param name="specialCommandsStack">A stack of special commands.</param>
	/// <param name="currentLineIndex">The index of the current special command.</param>
    
    ///

   
}
