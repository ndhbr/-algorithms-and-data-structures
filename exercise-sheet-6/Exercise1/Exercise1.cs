using System;

namespace exercise_sheet_6
{
    public class Exercise1
    {
        public Exercise1()
        {
            Random random = new Random();
            int[] a = new int[10];
            int highest = 1000;

            for (int i = 0; i < a.Length; i++)
            {
                int tmp = random.Next(1000, 10000);

                if(tmp > highest)
                    highest = tmp;

                a[i] = tmp;
            }

            Print(a);
            Console.WriteLine("Highest: " + highest);
            a = CountSortImproved(a, highest);
            Print(a);
        }

        public void CountSort(int[] a, int n, int k)
        {
            int i, j = 1;
            int[] bin = new int[k + 1];

            for (i = 1; i <= k; i++) // k
                bin[i] = 0;

            for (i = 0; i < n; i++) // n
                bin[a[i]] += 1;

            for (i = 0; i < n; i++) // n
            {
                while (bin[j] == 0) // k
                {
                    j += 1;
                }

                a[i] = j;
                bin[j] -= 1;
            }
        }

        public int[] CountSortImproved(int[] a, int k)
        {
            int i;
            int[] c = new int[k + 1];
            int[] b = new int[a.Length];

            for (i = 0; i < c.Length; i++)
                c[i] = 0;

            for (i = 0; i < a.Length; i++)
                c[a[i]] += 1;

            for (i = 1; i < c.Length; i++)
                c[i] += c[i - 1];  

            for (i = 0; i < a.Length; i++)
            {
                b[c[a[i]] - 1] = a[i];
                c[a[i]] -= 1;
            }

            return b;
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

        public void MapSort(int[] a, int n, double c)
        {
            int newn = (int) ((double) n*c), i, j = 0;

            int[] bin = new int[newn];
            int max = int.MaxValue;
            int min = int.MinValue;

            for (i = 0; i < newn; i++)
                bin[i] -= 1;

            for (i = 0; i < n; i++)
            {
                if (a[i] < min)
                    min = a[i];

                if (a[i] > max)
                    max = a[i];
            }

            double dist = (double) (max-min) / (double) (newn - 1);

            for (i = 0; i < n; i++)
            {
                int t = (int) ((double) (a[i] - min) / dist);
                int insert = a[i];
                int left = 0;

                if (bin[t] != -1 && insert <= bin[t])
                    left = 1;

                while (bin[t] != -1)
                {
                    if (left == 1)
                    {
                        if (insert > bin[t])
                            Swap(a, bin[t], insert);

                        if (t > 0)
                            t--;
                        else
                            left = 0;
                    }
                    else
                    {
                        if (insert <= bin[t])
                            Swap(a, bin[t], insert);

                        if (t < newn-1)
                            t++;
                        else
                            left = 1;
                    }
                }
                
                bin[t] = insert;
            }

            for (i = 0; i < newn; i++)
            {
                if (bin[i] != -1)
                    a[j++] = bin[i];
            }
        }

        private void Swap(int[] a, int pos1, int pos2)
        {
            int tmp = a[pos1];

            a[pos1] = a[pos2];
            a[pos2] = tmp;
        }

        public void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(" " + a[i] + " ");
            }

            Console.Write("\n");
        }
    }
}