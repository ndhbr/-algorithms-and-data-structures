using System;

namespace exercise_sheet_3
{
    public class Exercise1_2
    {
        const int n = 4;

        public Exercise1_2()
        {
            int [,] a;
            int max;

            a = new int [n,n]
            {
                {2, 7, -2, 2},
                {1, -3, 8, 2},
                {-5, -7, -1, 2},
                {4, 1, 9, -3}
            };

            PrintMatrix(a);
            max = MaxTeilSum2d(a, n);
            Console.WriteLine("Max Teilsumme: {0}", max);
        }

        private void PrintMatrix(int[,] a)
        {
            int i, j;

            for(i = 0; i < n; i++)
            {
                for(j = 0; j < n; j++)
                {
                    Console.Write("{0} ", a[i,j]);
                }
                
                Console.Write("\n");
            }

            Console.WriteLine("------------------------");
        }

        private int MaxTeilSum(int[] a, int size)
        {
            int i, s, max = int.MinValue, aktSum = 0;

            for (i = 0; i < size; i++)
            {
                s = aktSum + a[i];
                if (s > a[i]) aktSum = s;
                else aktSum = a[i];
                if (aktSum > max) max = aktSum;
            }

            return max;
        }

        private int MaxTeilSum2d(int[,] a, int size)
        {
            int i,
                j,
                k,
                max,
                rowMax;
            int[] row;

            max = int.MinValue;

            for (i = 0; i < size; i++)
            {
                row = new int[size];

                for (j = i; j < size; j++)
                {
                    for(k = 0; k < size; k++)
                    {
                        row[k] += a[j,k];
                    }

                    rowMax = MaxTeilSum(row, size);

                    if (rowMax > max)
                        max = rowMax;
                }
            }

            return max;
        }
    }
}