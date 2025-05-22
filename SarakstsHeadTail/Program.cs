namespace SarakstsHeadTail
{
    internal class Program // E.G.: head-6-1-2-3-4-tail
    {
        private static int[] Input = {  };

        private static Node head, tail;

        static void Main(string[] args)
        {
            Load();
            PasteHere();

            Node node = head;
            while (node is not null) 
            {
                if(node.value is not null) Console.Write(node.value);
                node = node.next;
                if (node is not null) Console.Write("-");
            }

            Console.ReadLine();
        }

        private static void Load() 
        {
            Node[] nodes = new Node[Input.Length];

            for (int i = 0; i < Input.Length; i++)
            {
                nodes[i] = new Node(Input[i], i > 0 ? nodes[i - 1] : null, null);
            }

            for (int i = 0; i < nodes.Length - 1; i++)
            {
                nodes[i].next = nodes[i + 1];
            }

            head = new Node("head", null, nodes[0]);
            tail = new Node("tail", nodes[nodes.Length - 1], null);

            head.next.prev = head;
            tail.prev.next = tail;
        }
        private static void PasteHere() 
        {

        }
    }

    class Node 
    {
        public Node prev;
        public Node getPrev() 
        {
            return prev;
        }
        public void setPrev(Node node) 
        {
            prev = node;
        }

        public Node next;
        public Node getNext() 
        {
            return next;
        }
        public void setNext(Node node) 
        {
            next = node;
        }

        public object? value;

        public Node(object? value, Node prev, Node next) 
        {
            this.prev = prev;
            this.next = next;
            this.value = value;
        }
    }
}