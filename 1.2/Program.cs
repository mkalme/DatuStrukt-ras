namespace _1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line0 = Console.ReadLine();
            string line1 = Console.ReadLine();

            string[] argsLine2 = line1.Split();

            int nodes = int.Parse(line0);
            int[] edges = new int[nodes];

            for (int i = 0; i < nodes; i++)
            {
                edges[i] = int.Parse(argsLine2[i]);
            }

            Console.WriteLine(CountDepth(nodes, edges));

            Console.ReadLine();
        }

        private static int CountDepth(int nodes, int[] edges)
        {
            int output = 0;

            for (int i = 0; i < nodes; i++)
            {
                int depthOfNode = CountDepthOfNode(i, edges);
                if (depthOfNode > output) output = depthOfNode;
            }

            return output;
        }
        private static int CountDepthOfNode(int node, int[] edges)
        {
            int output = 0;
            while (true)
            {
                output++;
                node = edges[node];

                if (node == -1) return output;
            }
        }
    }
}