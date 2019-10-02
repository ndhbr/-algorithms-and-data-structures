using System;

namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ggt(33, 21);
            ggtRecursive(33, 21, 0);
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

            Console.WriteLine("Größter gemeinsamer Teiler: " + a);
        }

        public static int ggtRecursive(int a, int b, int r)
        {
            r = a % b;
            a = b;
            b = r;

            if(r == 0)
            {
                Console.WriteLine("Größter gemeinsamer Teiler: " + a);
                return a;
            }
            else
            {
                return ggtRecursive(a, b, r);
            }
        }
    }
}