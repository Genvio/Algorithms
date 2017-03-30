using System;
using System.Diagnostics;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int LEFT = 0;
            int RIGHT = 99;
            Stopwatch stopWatch = new Stopwatch();
            string answer = "n";
            bool display;
            bool retry = true;

            while (retry)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Selection Sort O(N^2). Verloka Vadim, 2017");
                Console.WriteLine(new string('-', 50));
                //input
                int n = 0;
                Console.Write("Size of array, N=");
                int.TryParse(Console.ReadLine(), out n);
                Console.WriteLine($"Array[{n}] was created.");
                Console.Write("Display array?[y/n] ");
                display = Console.ReadLine() == "y" ? true : false;

                //array
                int[] arr = new int[n];
                Random random = new Random((int)DateTime.Now.Ticks);
                for (int i = 0; i < n; i++)
                {
                    arr[i] = random.Next(LEFT, RIGHT);
                    if (display)
                        Console.Write($"{arr[i]} ");
                }
                if (display)
                    Console.Write("\n");
                //sorting
                Console.Write("Start sort? [y/n] ");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    stopWatch.Start();
                    SelectionSort.Sort(ref arr);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Algorithm runtime (H:M:S:mS) - {elapsedTime}");

                    if (display)
                    {
                        Console.WriteLine("Sorted array:");
                        foreach (var item in arr)
                            Console.Write($"{item} ");
                        Console.Write('\n');
                    }

                    Console.Write("Retry?[y/n] ");
                    retry = Console.ReadLine() == "y" ? true : false;
                }
                else
                    return;
            }
        }
    }
}
