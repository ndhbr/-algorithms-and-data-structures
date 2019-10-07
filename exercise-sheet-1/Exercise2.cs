using System;

namespace exercise_sheet_1
{
    public class Exercise2
    {
        public Exercise2() {
            Eratosthenes(100000);
        }

        public void Eratosthenes(int k)
        {
            bool[] prime = new bool[k+1];
            int i = 0;

            for(i = 0; i < prime.Length; i++)
            {
                prime[i] = true;
            }

            prime[0] = false;
            prime[1] = false;

            for(i = 2; i*i <= k; i++)
            {
                if(prime[i])
                {
                    int j = i + i;

                    while(j <= k)
                    {
                        prime[j] = false;
                        j += i;
                    }
                }
            }

            for(i = 0; i < prime.Length; i++)
            {
                if(prime[i])
                    Console.WriteLine("Prim " + i);
            }
        }
    }
}