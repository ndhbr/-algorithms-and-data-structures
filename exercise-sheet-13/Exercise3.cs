using System;

namespace exercise_sheet_13
{
    class Exercise3
    {
        int inf;
        int[,] w;

        int vertices;

        public Exercise3()
        {
            inf = int.MaxValue;

            w = new int[,]{
                {0, inf, inf, inf, -1, inf},
                {1, 0, inf, 2, inf, inf},
                {inf, 2, 0, inf, inf, -8},
                {-4, inf, inf, 0, 3, inf},
                {inf, 7, inf, inf, 0, inf},
                {inf, 5, 10, inf, inf, 0}
            };

            vertices = w.GetLength(1);

            FloydWarshall();
        }

        public void FloydWarshall()
        {
            int k, i, j, min, sum;
            int n = vertices;
            int[][,] d = new int[n][,];

            d[0] = w;

            for (k = 1; k < n; k++)
            {
                d[k] = new int[n,n];

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        min = d[k-1][i,j];

                        try {
                            sum = inf;

                            if (d[k-1][i,k] != inf && d[k-1][k,j] != inf)
                                sum = checked(d[k-1][i,k] + d[k-1][k,j]);

                            if (sum < min)
                                min = sum;
                        } catch (System.OverflowException e) {}
                        
                        d[k][i,j] = min;
                    }
                }
            }

            PrintMatrix(d[n-1]);
        }

        public void PrintMatrix(int[,] m)
        {
            int i, j, num;

            Console.WriteLine();

            for (i = 0; i < m.GetLength(0); i++)
            {
                for (j = 0; j < m.GetLength(1); j++)
                {
                    num = m[i,j];

                    if (num == int.MaxValue)
                        Console.Write("∞ ");
                    else
                        Console.Write(num + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
