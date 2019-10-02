using System;

namespace blatt1
{
    class Program
    {
        static void Main(string[] args)
        {
            ggt(21, 33);
            ggtRecursive(21, 33);
        }

        public static void ggt(int a, int b)
        {
            int r = 0;

            do
            {
                r = a % b;
                a = b;
                b = r;
            } while (r != 0);

            Console.WriteLine("Highest Common Factor (w/ Loop): " + a);
        }

        public static int ggtRecursive(int a, int b, int r = 0)
        {
            r = a % b;
            a = b;
            b = r;

            if(r == 0)
            {
                Console.WriteLine("Highest Common Factor (w/ Recursion): " + a);
                return a;
            }
            else
            {
                return ggtRecursive(a, b, r);
            }
        }
    }
}
