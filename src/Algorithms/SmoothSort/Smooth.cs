using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothSort
{
    public class Smooth
    {
        static int q, r, p, b, c, r1, b1, c1;

        static bool IsAscending(int A, int B)
        {
            return A < B;
        }
        static void UP(ref int IA, ref int IB, ref int temp)
        {
            temp = IA;
            IA += IB + 1;
            IB = temp;
        }
        private static void DOWN(ref int IA, ref int IB, ref int temp)
        {
            temp = IB;
            IB = IA - IB - 1;
            IA = temp;
        }
        static void Sift(ref int [] A)
        {
            int r0, r2, temp = 0;
            int t;
            r0 = r1;
            t = A[r0];

            while (b1 >= 3)
            {
                r2 = r1 - b1 + c1;

                if (!IsAscending(A[r1 - 1], A[r2]))
                {
                    r2 = r1 - 1;
                    DOWN(ref b1, ref c1, ref temp);
                }

                if (IsAscending(A[r2], t))
                {
                    b1 = 1;
                }
                else
                {
                    A[r1] = A[r2];
                    r1 = r2;
                    DOWN(ref b1, ref c1, ref temp);
                }
            }

            if (Convert.ToBoolean(r1 - r0))
                A[r1] = t;
        }
        static void Trinkle(ref int [] A)
        {
            int p1, r2, r3, r0, temp = 0;
            int t;
            p1 = p;
            b1 = b;
            c1 = c;
            r0 = r1;
            t = A[r0];

            while (p1 > 0)
            {
                while ((p1 & 1) == 0)
                {
                    p1 >>= 1;
                    UP(ref b1, ref c1, ref temp);
                }

                r3 = r1 - b1;

                if ((p1 == 1) || IsAscending(A[r3], t))
                {
                    p1 = 0;
                }
                else
                {
                    --p1;

                    if (b1 == 1)
                    {
                        A[r1] = A[r3];
                        r1 = r3;
                    }
                    else
                    {
                        if (b1 >= 3)
                        {
                            r2 = r1 - b1 + c1;

                            if (!IsAscending(A[r1 - 1], A[r2]))
                            {
                                r2 = r1 - 1;
                                DOWN(ref b1, ref c1, ref temp);
                                p1 <<= 1;
                            }
                            if (IsAscending(A[r2], A[r3]))
                            {
                                A[r1] = A[r3]; r1 = r3;
                            }
                            else
                            {
                                A[r1] = A[r2];
                                r1 = r2;
                                DOWN(ref b1, ref c1, ref temp);
                                p1 = 0;
                            }
                        }
                    }
                }
            }

            if (Convert.ToBoolean(r0 - r1))
                A[r1] = t;

            Sift(ref A);
        }
        static void SemiTrinkle(ref int [] A)
        {
            int T;
            r1 = r - c;

            if (!IsAscending(A[r1], A[r]))
            {
                T = A[r];
                A[r] = A[r1];
                A[r1] = T;
                Trinkle(ref A);
            }
        }

        public static void SmoothSort(ref int[] array)
        {
            int temp = 0;
            q = 1;
            r = 0;
            p = 1;
            b = 1;
            c = 1;

            while (q < array.Length)
            {
                r1 = r;
                if ((p & 7) == 3)
                {
                    b1 = b;
                    c1 = c;
                    Sift(ref array);
                    p = (p + 1) >> 2;
                    UP(ref b, ref c, ref temp);
                    UP(ref b, ref c, ref temp);
                }
                else if ((p & 3) == 1)
                {
                    if (q + c < array.Length)
                    {
                        b1 = b;
                        c1 = c;
                        Sift(ref array);
                    }
                    else
                    {
                        Trinkle(ref array);
                    }

                    DOWN(ref b, ref c, ref temp);
                    p <<= 1;

                    while (b > 1)
                    {
                        DOWN(ref b, ref c, ref temp);
                        p <<= 1;
                    }

                    ++p;
                }

                ++q;
                ++r;
            }

            r1 = r;
            Trinkle(ref array);

            while (q > 1)
            {
                --q;

                if (b == 1)
                {
                    --r;
                    --p;

                    while ((p & 1) == 0)
                    {
                        p >>= 1;
                        UP(ref b, ref c, ref temp);
                    }
                }
                else
                {
                    if (b >= 3)
                    {
                        --p;
                        r = r - b + c;
                        if (p > 0)
                            SemiTrinkle(ref array);

                        DOWN(ref b, ref c, ref temp);
                        p = (p << 1) + 1;
                        r = r + c;
                        SemiTrinkle(ref array);
                        DOWN(ref b, ref c, ref temp);
                        p = (p << 1) + 1;
                    }
                }
            }
        }
    }
}
