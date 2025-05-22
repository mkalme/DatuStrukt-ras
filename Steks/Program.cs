namespace Steks
{
    internal class Program
    {
        private static Stack<object> _list;
        private static object[] Input = { 10, 15, 12, 14 };

        static void Main(string[] args)
        {
            _list = new Stack<object>(Input);

            PasteHere();

            object[] items = _list.ToArray().Reverse().ToArray();

            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i]);
                if (i < _list.Count - 1) Console.Write(",");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void PasteHere()
        {
            Push(15);
            Pop();
            Top();
            Push(9);
            Top();
            Top();
            Pop();
            Push(3);
        }

        private static void Push(object obj)
        {
            _list.Push(obj);
        }
        private static void Pop()
        {
            _list.Pop();
        }
        private static void Top()
        {
            
        }
    }
}