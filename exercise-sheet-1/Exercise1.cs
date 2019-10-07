using System;

namespace exercise_sheet_1
{
    public class Exercise1
    {
        public Exercise1() {
            int a = 21;
            int b = 33;
            int result = 0;

            result = GgT(a, b);
            Console.WriteLine("Highest Common Factor (w/ Loop): " + result);
            
            //result = GgTRecursive(21, 33); rekursiv vermutlich schlechter, da bei großen Zahlen der Callstack stark belastet wird.
            //Console.WriteLine("Highest Common Factor (w/ Recursion): " + result);

            result = KgV(a, b);
            Console.WriteLine("Smallest Common Multiple: " + result);

            Console.WriteLine(a + " * " + b + " = " + (a*b));
            // Kleinstes gemeinsames Vielfaches mal größter gemeinsamer Teiler entspricht a * b
        }

        public int GgT(int a, int b)
        {
            int r = 0;

            do
            {
                r = a % b;
                a = b;
                b = r;
            } while (r != 0);

            return a;
        }

        public int GgTRecursive(int a, int b, int r = 0)
        {
            r = a % b;
            a = b;
            b = r;

            if(r == 0)
            {
                return a;
            }
            else
            {
                return GgTRecursive(a, b, r);
            }
        }

         public int KgV(int a, int b)
         {   
            int c = GgT(a, b);
            int result = (a * b) / c;

            return result;
        }
    }
}