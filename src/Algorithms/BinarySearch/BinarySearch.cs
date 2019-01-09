namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int? Search(int[] array, int searchItem)
        {
            if (array.Length == 0)
                return null;

            if (searchItem < array[0])
                return null;

            if (searchItem > array[array.Length - 1])
                return null;

            int firstIndex = 0;
            int lastIndex = array.Length;

            while (firstIndex < lastIndex)
            {
                int middleIndex = firstIndex + (lastIndex - firstIndex) / 2;

                if (searchItem <= array[middleIndex])
                    lastIndex = middleIndex;
                else
                    firstIndex = middleIndex + 1;
            }

            return (array[lastIndex] == searchItem) ? lastIndex : (int?)null;
        }
    }
}
