using System;
using System.Collections.Generic;

namespace ExamHelper
{
    public static class CommandParser
    {
        public static IEnumerable<Command> ParseCommands(string commandInput)
        {
            string[] commands = commandInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            Command[] output = new Command[commands.Length];

            for (int i = 0; i < output.Length; i++) 
            {
                output[i] = Parse(commands[i]);
            }

            return output;
        }

        public static Command Parse(string command) 
        {
            int indexOfFirstParentheses = command.IndexOf("(");
            if (indexOfFirstParentheses <= 0) throw new Exception($"There was an issue with parsing {command}");

            object? argument = ParseArgument(command, indexOfFirstParentheses);

            string name = command.Substring(0, indexOfFirstParentheses);
            return new Command(name, argument);
        }

        private static object? ParseArgument(string command, int indexOfFirstParentheses) 
        {
            int indexOfLastParentheses = command.LastIndexOf(")");
            if (indexOfLastParentheses <= indexOfFirstParentheses) throw new Exception($"There was an issue with parsing {command}");

            string argument = command.Substring(indexOfFirstParentheses + 1, indexOfLastParentheses - indexOfFirstParentheses - 1);
            return string.IsNullOrEmpty(argument) ? null : argument;
        }
    }
}
