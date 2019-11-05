using System;

namespace exercise_sheet_5
{
    public class Exercise1
    {
        public Exercise1()
        {
            int[] a = new int[] {-5, 13, -32, 7, -3, 17, 23, 12, -35, 19};

            Print(a);

            //HeapSort(a, 0, a.Length-1);
            MergeSort(a, 0, a.Length-1);

            Print(a);
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

        public void HeapSort(int[] a, int f, int l)
        {
            BuildHeap(a, f, l);

            for (int i = l; i > f; i--)
            {
                Swap(a, f, i);
                Heapify(a, f, i - 1, f);
            }
        }

        private void BuildHeap(int[] a, int f, int l)
        {
            int n = l - f + 1;

            for (int i = f + (n - 2) / 2; i >= f; i--)
                Heapify(a, f, l, i);
        }

        private void Heapify(int[] a, int f, int l, int root)
        {
            int largest,
                left = f + (root - f) * 2 + 1,
                right = f + (root - f) * 2 + 2;
            
            if (left <= l && a[left] > a[root])
                largest = left;
            else
                largest = root;

            if (right <= l && a[right] > a[largest])
                largest = right;

            if (largest != root)
            {
                Swap(a, root, largest);
                Heapify(a, f, l, largest);
            }
        }

        private void Swap(int[] a, int pos1, int pos2)
        {
            int tmp = a[pos1];

            a[pos1] = a[pos2];
            a[pos2] = tmp;
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