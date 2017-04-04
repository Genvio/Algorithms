namespace QuickSort
{
    public static class QuickSort
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Sort(ref int[] arr, int l, int r)
        {
            if (l >= r)
                return;

            int pivot = Partition(ref arr, l, r);
            Sort(ref arr, l, pivot - 1);
            Sort(ref arr, pivot + 1, r);
        }
        static int Partition(ref int[]arr, int l, int r)
        {
            int mark = l;

            for (int i = l; i <= r; i++)
            {
                if(arr[i] < arr[r])
                {
                    Swap(ref arr[i], ref arr[mark]);
                    mark++;
                }
            }

            Swap(ref arr[mark], ref arr[r]);

            return mark;
        }
    }
}
