using System;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int LEFT = 0;
            int RIGHT = 99;
            string answer = "n";
            bool display;
            bool retry = true;

            while (retry)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Quick Sort. Verloka Vadim, 2017");
                Console.WriteLine(new string('-', 50));
                //input
                int n = 0;
                Console.Write("Size of array, N=");
                int.TryParse(Console.ReadLine(), out n);
                Console.Write("Display array?[y/n] ");
                display = Console.ReadLine() == "y" ? true : false;

                //sorting
                Console.Write("Start sort? [y/n] ");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    long Avrg = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        //array
                        if (display)
                            Console.Write($"\nArray - {i + 1}: ");
                        Random random = new Random((int)DateTime.Now.Ticks);
                        int[] arr = new int[n];
                        for (int j = 0; j < n; j++)
                        {
                            arr[j] = random.Next(LEFT, RIGHT);
                            if (display)
                                Console.Write($"{arr[j]} ");
                        }
                        if (display)
                            Console.Write("\n");

                        //sort
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        /*Start*/
                        QuickSort.Sort(ref arr, 0, n - 1);
                        /*STOP*/
                        stopWatch.Stop();
                        long ts = stopWatch.ElapsedMilliseconds;
                        Console.WriteLine($"{i}. Algorithm runtime [Milliseconds] - {ts}");
                        Avrg += ts;

                        if (display)
                        {
                            Console.WriteLine("Sorted array:");
                            foreach (var item in arr)
                                Console.Write($"{item} ");
                            Console.Write('\n');
                        }
                    }
                    Console.WriteLine($"Algorithm runtime, 9 iteration - {Avrg}");
                    Console.WriteLine($"Algorithm runtime, Avrg - {Avrg / 9}");

                    Console.Write("Retry?[y/n] ");
                    retry = Console.ReadLine() == "y" ? true : false;
                }
                else
                    return;
            }
        }
    }
}
