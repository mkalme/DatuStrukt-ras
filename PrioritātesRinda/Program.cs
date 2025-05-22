namespace PrioritātesRinda
{
    internal class Program
    {
        private static IList<object> _list = new List<object>();

        static void Main(string[] args)
        {
            PasteHere();

            for (int i = 0; i < _list.Count; i++) 
            {
                Console.Write(_list[i]);
                if (i < _list.Count - 1) Console.Write(",");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void PasteHere() 
        {
            Insert(10);
            Insert(5);
            Insert(7);
            ExtractMax();
            Insert(20);
            Insert(15);
            print(ExtractMax());
            Insert(20);
            print(ExtractMax());
            print(ExtractMax());
        }

        private static void Insert(object obj) 
        {
            _list.Add(obj);
        }
        private static object ExtractMax() 
        {
            object obj = _list.Max();
            _list.Remove(obj);

            return obj;
        }

        private static void print(object obj) 
        {
            //Console.Write(obj + ",");
        }
    }
}