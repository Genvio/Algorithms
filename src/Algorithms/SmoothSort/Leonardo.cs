using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothSort
{
    public class Leonardo
    {
        public int Number { get; private set; }
        public int Index { get; private set; }

        public Leonardo()
        {
            Number = 1;
            Index = 1;
        }

        public int Next()
        {
            Index++;
            Number = GetLeonardoNumber(Index);
            return Number;
        }
        public int Prev()
        {
            Index--;
            Number = GetLeonardoNumber(Index);
            return Number;
        }
        public int Difference()
        {
            return GetLeonardoNumber(Index + 1) - Number;
        }

        static double GetGoldenRatioP()
        {
            return (1 + Math.Sqrt(5)) / 2;
        }
        static double GetGoldenRatioM()
        {
            return (1 - Math.Sqrt(5)) / 2;
        }
        static int GetLeonardoNumber(int number)
        {
            if (number <= 1)
                return 1;

            return (int)((2 / Math.Sqrt(5)) * (Math.Pow(GetGoldenRatioP(), number + 1) - Math.Pow(GetGoldenRatioM(), number + 1)) - 1);
        }
    }
}
