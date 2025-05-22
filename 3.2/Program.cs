namespace _3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            FindOccurances(pattern, text);

            Console.ReadLine();
        }

        private static void FindOccurances(string pattern, string text)
        {
            if (pattern.Length > text.Length || pattern.Length == 0) return;

            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (Matches(pattern, text, i)) Console.Write(i + " ");
            }
        }

        private static bool Matches(string pattern, string text, int posInText)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (text[posInText + i] != pattern[i]) return false;
            }

            return true;
        }
    }
}