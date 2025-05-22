namespace ExamHelper
{
    public readonly struct Command
    {
        public string Name { get; }
        public object? Argument { get; }

        public Command(string command, object? argument) 
        {
            Name = command;
            Argument = argument;
        }
    }
}
