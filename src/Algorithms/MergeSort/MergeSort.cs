using System.Linq;

namespace MergeSort
{
    public static class MergeSort
    {
        static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                    if (arr1[a] > arr2[b])
                        merged[i] = arr2[b++];
                    else
                        merged[i] = arr1[a++];
                else
                  if (b < arr2.Length)
                    merged[i] = arr2[b++];
                else
                    merged[i] = arr1[a++];
            }
            return merged;
        }

        public static int[] Sort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;
            int mid = arr.Length / 2;
            
            return Merge(Sort(arr.Take(mid).ToArray()), Sort(arr.Skip(mid).ToArray()));
        }
    }
}
