using System;
using System.Collections.Generic;

namespace exercise_sheet_5
{
    public class Exercise4
    {
        public Exercise4()
        {
            int[] a = new int[] {-5, 13, -32, 7, -3, 17, 23, 12, -35, 19};
            Print(a);
            bool test = Algo(a, 299);
            Console.WriteLine("Test was: " + test);
        }

        public bool Algo(int[] a, int s)
        {
            int i;

            MergeSort(a, 0, a.Length-1);

            for (i = 0; i < a.Length; i++)
            {}

            return false;
        }

        public void MergeSort(int[] a, int f, int l)
        {
            if (f < l)
            {
                int m = (f + l + 1) / 2;

                MergeSort(a, f, m-1);
                MergeSort(a, m, l);
                Merge(a, f, l, m);
            }
        }

        private void Merge(int[] a, int f, int l, int m)
        {
            int i, n = l - f + 1;
            int a1f = f,
                a1l = m - 1;
            int a2f = m, a2l = l;
            int[] anew = new int[n];

            for (i = 0; i < n; i++)
            {
                if (a1f <= a1l)
                {
                    if (a2f <= a2l)
                    {
                        if (a[a1f] <= a[a2f])
                            anew[i] = a[a1f++];
                        else
                            anew[i] = a[a2f++];
                    }
                    else
                    {
                        anew[i] = a[a1f++];
                    }
                }
                else
                {
                    anew[i] = a[a2f++];
                }
            }

            for (i = 0; i < n; i++)
                a[f+i] = anew[i];
        }

        private void Print(int[] a)
        {
            int i = 0;

            for(i = 0; i < a.Length-1; i++)
            {
                Console.Write(a[i] + ", ");
            }

            Console.Write(a[i] + "\n");
        }
    }
}