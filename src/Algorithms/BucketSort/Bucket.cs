using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    public static class Bucket
    {
        public static void Sort(ref int [] array)
        {
            int min = array[0];
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
                if (array[i] < min) min = array[i];
            }

            List<int>[] bucket = new List<int>[max - min + 1];

            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();

            for (int i = 0; i < array.Length; i++)
                bucket[array[i] - min].Add(array[i]);

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
                if (bucket[i].Count > 0)
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        array[k] = bucket[i][j];
                        k++;
                    }
        }
    }
}
