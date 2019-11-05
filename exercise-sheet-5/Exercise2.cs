using System;
using System.Collections.Generic;

namespace exercise_sheet_5
{
    public class Exercise2
    {

        public Exercise2()
        {
            int[] a = new int[] {-5, 13, -32, 7, -3, 17, 23, 12, -35, 19};        

            Print(a);

            // MergeSort(a, a.Length-1);
            // InsertionSortIterative(a, a.Length);
            InsertionSortRecursive(a, 1, a.Length);

            Print(a);
        }

        public void InsertionSortIterative(int[] a, int n)
        {
            int i = 0, j, key = 0;

            for (j = 1; j < n; j++)
            {
                key = a[j];
                i = j - 1;
                while (i >= 0 && a[i] > key)
                {
                    a[i+1] = a[i];
                    i = i - 1;
                }

                a[i+1] = key;
            }
        }

        public int[] InsertionSortRecursive(int[] a, int j, int n)
        {
            int i = 0, key = 0;

            if(j < n)
            {
                key = a[j];
                i = j - 1;

                while(i >= 0 && a[i] > key)
                {
                    a[i+1] = a[i];
                    i--;
                }

                a[i+1] = key;
                j++;

                return InsertionSortRecursive(a, j, n);
            }

            return a;
        }

        private void MergeSort(int[] a, int n) 
        { 
            int currSize;  
            int leftStart;                     
            
            for (currSize = 1; currSize <= n-1;  currSize = 2*currSize) 
            { 
                for (leftStart = 0; leftStart < n-1; leftStart += 2*currSize) 
                { 
                    int mid = leftStart + currSize - 1; 
            
                    int rightEnd = Math.Min(leftStart + 2*currSize - 1, n-1); 
            
                    Merge(a, leftStart, rightEnd, mid); 
                } 
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