namespace DatuStruktūras
{
    internal class Program
    {
        private static int[] Input = { };
        private static CustomList list = new CustomList();

        static void Main(string[] args)
        {
            PopulateList();
            PasteHere();

            Console.ReadLine();
        }

        private static void PopulateList() 
        {
            Node[] nodes = new Node[Input.Length];

            for (int i = 0; i < Input.Length; i++) 
            {
                nodes[i] = new Node() 
                {
                    prev = i > 0 ? nodes[i - 1] : null,
                    value = Input[i]
                };
            }

            for (int i = 0; i < nodes.Length - 1; i++) 
            {
                nodes[i].next = nodes[i + 1];
            }

            list.head = nodes[0];
            list.tail = nodes[nodes.Length - 1];
        }

        private static void PasteHere() 
        {
            

            Console.WriteLine(sum);
        }
    }

    class CustomList 
    {
        public Node head;    
        public Node tail;
    }

    class Node 
    {
        public int value;
        public Node next;
        public Node prev;
    }
}