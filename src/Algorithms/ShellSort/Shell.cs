using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    public static class Shell
    {
        //A033622
        public static int GetGape(int n)
        {
            return n % 2 == 0 ?
                9 * (int)Math.Pow(2, n) - 9 * (int)Math.Pow(2, n / 2) + 1 :
                8 * (int)Math.Pow(2, n) - 6 * (int)Math.Pow(2, (n + 1) / 2) + 1;
        }
        public static void Sort(ref int[] arr)
        {
            int gap = 1;
            int offset = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int g = GetGape(i);
                if (g > arr.Length)
                    break;

                gap = g;
                offset = i;
            }


            while (gap > 0)
            {
                for (int i = 0; i + gap < arr.Length; i++)
                {
                    int j = i + gap;
                    int temp = arr[j];

                    while (j - gap >= 0 && temp < arr[j - gap])
                    {
                        arr[j] = arr[j - gap];
                        j = j - gap;
                    }

                    arr[j] = temp;
                }

                gap = GetGape(--offset);
            }
        }
    }
}
