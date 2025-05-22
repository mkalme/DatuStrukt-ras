namespace SaistītsSaraksts
{
    internal class Program
    {
        private static readonly IList<object> _list = new List<object>();
        private static readonly char a = 'a', b = 'b', c = 'c', d = 'd', e = 'e', f = 'f';

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
            PushFront(a);
            PushBack(b);
            PushFront(c);
            PushFront(d);
            PushBack(e);
            PopFront();
        }

        private static void PushFront(object obj)
        {
            _list.Insert(0, obj);
        }
        private static void PushBack(object obj)
        {
            _list.Add(obj);
        }
        private static void PopBack() 
        {
            _list.RemoveAt(_list.Count - 1);
        }
        private static void PopFront()
        {
            _list.RemoveAt(0);
        }
    }
}