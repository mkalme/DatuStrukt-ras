namespace _3._1
{
    internal class Program
    {
        private static IDictionary<string, int> _book = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            string[] lines = new string[queriesCount];

            for (int i = 0; i < queriesCount; i++)
            {
                lines[i] = Console.ReadLine();
            }

            for (int i = 0; i < queriesCount; i++)
            {
                ExecuteCommand(lines[i]);
            }

            Console.ReadLine();
        }

        private static void ExecuteCommand(string command)
        {
            string[] args = command.Split(" ");
            string type = args[0];

            switch (type)
            {
                case "add":
                    ExecuteAddCommand(args);
                    break;
                case "del":
                    ExecuteDelCommand(args);
                    break;
                case "find":
                    ExecuteFindCommand(args);
                    break;
            }
        }

        private static void ExecuteAddCommand(string[] args)
        {
            int number = int.Parse(args[1]);
            string name = args[2];

            if (_book.ContainsKey(name))
            {
                _book[name] = number;
            }
            else
            {
                _book.Add(name, number);
            }
        }
        private static void ExecuteDelCommand(string[] args)
        {
            int number = int.Parse(args[1]);
            string? name = FindNameFromNumber(number);

            if (name is null) return;

            _book.Remove(name);
        }
        private static void ExecuteFindCommand(string[] args)
        {
            int number = int.Parse(args[1]);
            string? name = FindNameFromNumber(number);

            if (name is null)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine(name);
            }
        }

        private static string? FindNameFromNumber(int number)
        {
            foreach (var pair in _book)
            {
                if (pair.Value == number) return pair.Key;
            }

            return null;
        }
    }
}