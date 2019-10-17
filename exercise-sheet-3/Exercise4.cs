using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace exercise_sheet_3
{
    public static class Extensions
    {
        public static List<T> Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;

            return list;
        }
    }

    public class Exercise4
    {
        List<int> numbers = new List<int>(); 

        public Exercise4()
        {
            FillWithRandomNumbers(90000);
            
            //PrintNumbers();
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSort(); // 90000 = 55 Sekunden
            //QuickSort(0, numbers.Count-1); // 800000 = 53 Sekunden
            
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;

            Console.WriteLine("Funktion brauchte: " + Convert.ToInt32(stopwatchElapsed.TotalSeconds) + " s");

            //PrintNumbers();
        }

        public void BubbleSort()
        {
            int i, j;

            for(i = 0; i < numbers.Count; i++)
            {
                for(j = numbers.Count -2; j >= i; j--)
                {
                    if(numbers[j] > numbers[j+1])
                    {
                        int h = numbers[j];
                        numbers[j] = numbers[j+1];
                        numbers[j+1] = h;
                    }
                }
            }
        }

        public void QuickSort(int f, int l)
        {
            int part = 0;

            if(f < l)
            {
                part = this.PreparePartition(f, l, part);
                QuickSort(f, part-1);
                QuickSort(part+1, l);
            }
        }

        private int PreparePartition(int f, int l, int p)
        {
            int i;
            int pivot = numbers[f];
            p = f - 1;
            
            for(i = f; i <= l; i++)
            {
                if(numbers[i] <= pivot)
                {
                    p++;
                    numbers = numbers.Swap(i, p);
                }
            }

            numbers = numbers.Swap(f, p);

            return p;
        }

        public void FillWithRandomNumbers(int n)
        {
            int i;
            Random random = new Random();

            for(i = 0; i < n; i++)
            {
                numbers.Add(random.Next(0, 100));
            }
        }

        public void PrintNumbers()
        {
            Console.WriteLine("Print Numbers:");

            foreach(var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("");
        }
    }
}