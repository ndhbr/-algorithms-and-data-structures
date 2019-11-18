using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise1();
            Exercise2();
        }

        static void Exercise2()
        {
            AVLTree baum = new AVLTree();
            baum.Insert(5);
            baum.Insert(6);
            baum.Insert(9);
            baum.Insert(12);
            baum.Insert(13);
            baum.Insert(3);
            baum.Insert(8);
            baum.Insert(10);
            baum.Insert(11);
            baum.Insert(16);
            baum.Insert(15);
            baum.Insert(14);
            baum.Insert(4);
            baum.Insert(2);
            baum.Insert(1);
            baum.Print();
            baum.Delete(12);
            baum.Delete(8);
            baum.Delete(5);
            baum.Delete(4);
            baum.Delete(3);
            baum.Delete(6);
            baum.Delete(15);
            baum.Delete(14);
            baum.Print();
        }

        static void Exercise1()
        {
            SuchBaum baum = new SuchBaum();
            baum.Insert(3);
            baum.Insert(-3);
            baum.Insert(12);
            baum.Insert(9);
            baum.Insert(13);
            baum.Insert(7);
            baum.Insert(2);

            baum.Print();
            baum.DeleteValueIterative(12);
            // baum.Insert(-2);
            // baum.Insert(4);
            // baum.Insert(5);
            // baum.Insert(6);
            // baum.Insert(20);
            // baum.Insert(22);
            // baum.Insert(23);
            baum.Print();
        }
    }
}
