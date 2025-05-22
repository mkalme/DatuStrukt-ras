using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamHelper
{
    public static class StackTaskHelper
    {
        public static string Execute(Stack<object> stack, string commandInput) 
        {
            IEnumerable<Command> commands = CommandParser.ParseCommands(commandInput);

            foreach (Command command in commands) 
            {
                ExecuteCommand(command, stack);
            }

            StringBuilder builder = new StringBuilder();
            object[] input = stack.ToArray().Reverse().ToArray();
            
            for (int i = 0; i < input.Length; i++) 
            {
                builder.Append(input[i]);
                if(i < input.Length - 1) builder.Append(',');
            }

            return builder.ToString();
        }

        private static void ExecuteCommand(Command command, Stack<object> stack) 
        {
            switch (command.Name) 
            {
                case "Push":
                    if (command.Argument is null) throw new Exception("Push must have an argument");
                    stack.Push(command.Argument);
                    break;
                case "Pop":
                    if (command.Argument is not null) throw new Exception("Pop cannot have an argument");
                    stack.Pop();
                    break;
                case "Top":
                    if (command.Argument is not null) throw new Exception("Top cannot have an argument");
                    break;
                default:
                    throw new Exception($"{command.Name} is not recognized as a valid command");
            }
        }
    }
}
