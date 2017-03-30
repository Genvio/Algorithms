namespace SelectionSort
{
    public static class SelectionSort
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Sort(ref int [] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }
    }
}
