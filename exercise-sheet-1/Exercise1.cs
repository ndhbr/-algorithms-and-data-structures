using System;

namespace exercise_sheet_1
{
    public class Exercise1
    {
        public Exercise1() {
            int a = 21;
            int b = 33;
            int result = 0;

            result = ggT(a, b);
            Console.WriteLine("Highest Common Factor (w/ Loop): " + result);
            
            //result = ggTRecursive(21, 33); rekursiv vermutlich schlechter, da bei großen Zahlen der Callstack stark belastet wird.
            //Console.WriteLine("Highest Common Factor (w/ Recursion): " + result);

            result = kgV(a, b);
            Console.WriteLine("Smallest Common Multiple: " + result);

            Console.WriteLine(a + " * " + b + " = " + (a*b));
            // Kleinstes gemeinsames Vielfaches mal größter gemeinsamer Teiler entspricht a * b
        }

        public int ggT(int a, int b)
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

        public int ggTRecursive(int a, int b, int r = 0)
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
                return ggTRecursive(a, b, r);
            }
        }

         public int kgV(int a, int b)
         {   
            int c = ggT(a, b);
            int result = (a * b) / c;

            return result;
        }
    }
}