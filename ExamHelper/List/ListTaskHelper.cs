using System;
using System.Collections.Generic;
using System.Text;

namespace ExamHelper
{
    public static class ListTaskHelper
    {
        public static string Execute(List<object> list, string commandInput) 
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

        private static void ExecuteCommand(Command command, List<object> list)
        {
            switch (command.Name)
            {
                case "PushFront":
                    if (command.Argument is null) throw new Exception("PushFront must have an argument");
                    list.Insert(0, command.Argument);
                    break;
                case "PushBack":
                    if (command.Argument is null) throw new Exception("PushBack must have an argument");
                    list.Add(command.Argument);
                    break;
                case "PopFront":
                    if (command.Argument is not null) throw new Exception("PopFront cannot have an argument");
                    list.RemoveAt(0);
                    break;
                case "PopBack":
                    if (command.Argument is not null) throw new Exception("PopBack cannot have an argument");
                    list.RemoveAt(list.Count - 1);
                    break;
                default:
                    throw new Exception($"{command.Name} is not recognized as a valid command");
            }
        }
    }
}
