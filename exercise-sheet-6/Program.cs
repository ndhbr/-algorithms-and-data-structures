using System;

namespace exercise_sheet_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            ListElement first = list.Append(3);
            ListElement element = list.Append(-1);
            list.Append(22);
            list.Append(8);
            list.Append(-3);
            ListElement last = list.Append(2);
            list.Print();
            // list.Delete(element);
            list.QuickSort(list, list.getHead(), list.getTail());
            list.Print();

            // Ring r = new Ring();

            // for (int i = 0; i < 49; i++)
            // {
            //     r.Append(i+1);
            // }

            // for (int i = 0; i < 6; i++)
            // {
            //     RingElement element = r.PopRandom();
            //     Console.WriteLine("Zahl " + (i+1) + " gezogen: " + element);
            // }

            // r.Print();
            // Exercise1 ex1 = new Exercise1();
        }
    }
}
