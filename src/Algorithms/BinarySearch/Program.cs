using System;
using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int RIGHT = 0;
            int search = 0;
            string answer = "n";
            bool retry = true;

            while (retry)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Binary Search. Verloka Vadim, 2019");
                Console.WriteLine(new string('-', 50));
                //input
                Console.Write("Size of array, N=");
                int.TryParse(Console.ReadLine(), out RIGHT);

                //sorting
                Console.Write("What element search? Search=");
                int.TryParse(Console.ReadLine(), out search);

                Console.Write("Start search? [y/n] ");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    int[] array = new int[RIGHT];
                    for (int i = 0; i < RIGHT; i++)
                        array[i] = i;

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    /*SORT*/
                    int? searchedIndex = BinarySearch.Search(array, search);
                    stopWatch.Stop();

                    long ts = stopWatch.ElapsedMilliseconds;
                    Console.WriteLine($"Algorithm runtime [Milliseconds] - {ts}");
                    if (searchedIndex != null)
                        Console.WriteLine($"Element is finded, index = {searchedIndex}, value = {array[searchedIndex ?? 0]}");
                    else
                        Console.WriteLine($"Element is not finded!");

                    Console.Write("Retry?[y/n] ");
                    retry = Console.ReadLine() == "y" ? true : false;
                }
                else
                    return;
            }
        }
    }
}
