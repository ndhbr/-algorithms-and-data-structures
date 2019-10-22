using System;

namespace exercise_sheet_3
{
    /*
     * Geht nicht! Does not work!
     * Exercise1_2.cs works!
     *
     */

    public class Exercise1
    {
        int [,] a;
        const int n = 3;

        public Exercise1()
        {
            a = new int [n,n]
            {
                {2, 7, -2},
                {1, -3, 8},
                {-5, -7, -1}
            };

            // MaxTeilSum();
            MaxTeilSum2();
        }

        private void MaxTeilSum()
        {
            int rowCount = 0;
            int i, s, max = int.MinValue, aktSumme = 0;

            for(i = 0; i < n; i++)
            {                
                if(i+1 == n && rowCount < n)
                    rowCount++;

                s = aktSumme + a[rowCount,i];
                
                if(s > a[rowCount,i])
                    aktSumme = s;
                else
                    aktSumme = a[rowCount,i];

                if(aktSumme > max)
                    max = aktSumme;
            }

            Console.WriteLine("MaxSumme " + max);
        }

        private void MaxTeilSum2()
        {
            int i, j;

            for(i = 0; i < n; i++)
            {
                int[,] tmpA = a;
                int maxRowSum = 0;
                int rowSum = 0;

                for(j = i; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        tmpA[i,k] += a[i,j];
                    }

                    rowSum = MaxTeilSum1d(tmpA, i, n);

                    if(rowSum > maxRowSum)
                        maxRowSum = rowSum;
                }

                Console.WriteLine("MaxSumme Zeile " + i + ": " + maxRowSum);
            }
        }

        private int MaxTeilSum1d(int[,] a, int row, int n)
        {
            int i, s, max = int.MinValue, aktSum = 0;

            for (i = 0; i < n; i++)
            {
                s = aktSum + a[row,i];

                if (s > a[row,i])
                    aktSum = s;
                else
                    aktSum = a[row,i];

                if (aktSum > max)
                    max = aktSum;
            }

            return max;
        }
    }
}