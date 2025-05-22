namespace _2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] argsLine1 = Console.ReadLine().Split();
            string[] argsLine2 = Console.ReadLine().Split();

            int n = int.Parse(argsLine1[0]), m = int.Parse(argsLine1[1]);
            int[] jobTimes = new int[m];

            for (int i = 0; i < m; i++)
            {
                jobTimes[i] = int.Parse(argsLine2[i]);
            }

            StartThreads(n, jobTimes);

            Console.ReadLine();
        }

        private static void StartThreads(int amountOfThreads, int[] jobTimes)
        {
            object jobIndexLock = new();
            int jobIndex = 0;

            DateTime time = DateTime.Now;

            Thread[] threads = new Thread[amountOfThreads];
            for (int i = 0; i < threads.Length; i++)
            {
                int index = i;

                threads[i] = new(() =>
                {
                    while (true)
                    {
                        int seconds;
                        lock (jobIndexLock)
                        {
                            if (jobIndex >= jobTimes.Length) return;

                            seconds = jobTimes[jobIndex];
                            jobIndex++;
                        }

                        DateTime startTime = DateTime.Now;

                        Thread.Sleep(seconds * 1000);
                        Console.WriteLine($"{index} {Math.Round((startTime - time).TotalSeconds)}");
                    }
                });

                threads[i].Start();
                Thread.Sleep(1);
            }
        }
    }
}