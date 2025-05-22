using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamHelper
{
    public static class PriorityQueueTaskHelper
    {
        public static string Execute(IList<int> list, string commandInput) 
        {
            IEnumerable<Command> commands = CommandParser.ParseCommands(commandInput);

            foreach (Command command in commands)
            {
                ExecuteCommand(command, list);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(list[i]);
                if (i < list.Count - 1) builder.Append(',');
            }

            return builder.ToString();
        }

        private static void ExecuteCommand(Command command, IList<int> list)
        {
            switch (command.Name)
            {
                case "Insert":
                    if (command.Argument is null || command.Argument is not string parsed) throw new Exception("Insert must have an argument");
                    list.Add(int.Parse(parsed));
                    break;
                case "ExtractMax":
                    if (command.Argument is not null) throw new Exception("ExtractMax must not have an argument");
                    ExtractMax();
                    break;
                case "print":
                    if (command.Argument is null || command.Argument is not string argumentParsed || argumentParsed != "ExtractMax()") 
                    {
                        throw new Exception("print must have an argument of 'ExtractMax()'");
                    }

                    ExtractMax();
                    break;
                default:
                    throw new Exception($"{command.Name} is not recognized as a valid command");
            }

            void ExtractMax() 
            {
                int max = list.Max();
                list.Remove(max);
            }
        }
    }
}
