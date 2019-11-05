using System;
using System.Collections.Generic;

namespace exercise_sheet_4
{
    public class Exercise1
    {
        public Exercise1()
        {
            int n = 5;
            int m = 3;

            //Console.WriteLine("Ackermann Rekursiv: " + AckermannRec(n, m));
            Console.WriteLine("Ackermann Iterativ: " + AckermannItRight(n, m));
        }

        private int AckermannItOld(int n, int m)
        {
            Stack<Int32[]> numbers = new Stack<Int32[]>();

            numbers.Push(new int[] {n, m});

            while (numbers.Count > 0)
            {
                int[] popped = numbers.Pop();
                n = popped[0];
                m = popped[1];

                if (n == 0)
                {
                    return m + 1;
                }
                else if (n >= 1 && m == 0)
                {
                    numbers.Push(new int[] {n - 1, 1});
                }
                else
                {
                    numbers.Push(new int[] {n - 1, m});
                    numbers.Push(new int[] {n, m - 1});
                }
            }

            return m + 1;
        }

        private int AckermannItOld2(int n, int m)
        {
            Stack<Int32[]> numbers = new Stack<Int32[]>();

            numbers.Push(new int[] {n,m});

            do
            {
                int[] nr = numbers.Pop();
                
                n = nr[0];
                m = nr[1];

                if (n == 0)
                {
                    m++;
                }
                else if (n >= 1 && m == 0)
                {
                    numbers.Push(new int[] {n-1, 1});
                }
                else
                {
                    numbers.Push(new int[] {n-1, m});
                    numbers.Push(new int[] {n, m-1});
                }
            } while (numbers.Count > 0 || n > 0);

            return m + 1;
        }

        private int AckermannIt(int n, int m)
        {
            Stack<Int32> numbers = new Stack<Int32>();

            do
            {
                m += (numbers.Count > 0) ? numbers.Pop() : 0;

                if (n == 0)
                {
                    return m + 1;
                }
                else if (n >= 1 && m == 0)
                {
                    n = n - 1;
                    numbers.Push(1);
                }
                else
                {
                    n = n - 1;
                    numbers.Push(m - 1);
                    numbers.Push(m);
                }
            } while (numbers.Count > 0);

            return 0;
        }

        private int AckermannItRight(int n, int m)
        {
            Stack<Int32> s = new Stack<Int32>();

            s.Push(n);

            while(s.Count > 0)
            {
                if (n == 0)
                {
                    n = s.Pop();
                    m += 1;
                }
                else if (m == 0)
                {
                    n -= 1;
                    m = 1;
                }
                else
                {
                    s.Push(n - 1);
                    m -= 1;
                }
            }

            return m;
        }

        private int AckermannRec(int n, int m)
        {
            if(n == 0)
            {
                return m + 1;
            }
            else if(m == 0 && n >= 1)
            {
                return AckermannRec((n - 1), 1);
            }
            else
            {
                return AckermannRec((n - 1), AckermannRec(n, (m - 1)));
            }
        }
    }
}