namespace InsertionSort
{
    public static class InsertionSort
    {
        public static void Sort(ref int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int tmp = arr[i];
                int j = i;
                for (; j > 0 && tmp < arr[j-1]; j--)
                    arr[j] = arr[j - 1];
                arr[j] = tmp;
            }
        }
    }
}
