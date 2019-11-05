using System;
using System.Diagnostics;

namespace exercise_sheet_4
{
    public class Exercise2
    {
        public Exercise2()
        {
            Matrix m = new Matrix(2, 2);
            m.Init();

            Matrix m1 = new Matrix(2, 2);
            m1.Init();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Matrix r = m.MultVariante2(m1);
            //Matrix r = m.Mult(m1);
    
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;

            if(r != null) {
                r.Print();

                Console.WriteLine("Funktion brauchte: " + Convert.ToInt32(stopwatchElapsed.TotalMilliseconds) + " ms");
            }
        }
    }

    public class Matrix
    {
        public int[,] matrix;

        public Matrix(int m, int n)
        {
            this.matrix = new int[n,m];
        }

        public void Init()
        {
            int i, j;
            Random random = new Random();

            for(i = 0; i < this.matrix.GetLength(0); i++)
            {
                for(j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i,j] = random.Next(0, 10);
                }
            }
        }

        public void Input()
        {
            int i, j, input;

            for(i = 0; i < this.matrix.GetLength(0); i++)
            {
                for(j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.Print(new int[2] {i,j});
                    Console.Write("Geben Sie eine Zahl ein: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    this.matrix[i,j] = input;
                }
            }

            this.Print();
        }

        public void Print(int[] highlight = null)
        {
            int i, j;

            for(i = 0; i < this.matrix.GetLength(0); i++)
            {
                for(j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if(highlight != null && (highlight[0] == i && highlight[1] == j))
                    {
                        Console.Write(">" + this.matrix[i,j] + "<");
                    }
                    else
                    {
                        Console.Write(" " + this.matrix[i,j] + " ");
                    }
                }

                Console.Write("\n");
            }            

            Console.WriteLine("#------------------#");
        }

        public Matrix Add(Matrix m)
        {
            int mLengthM = m.matrix.GetLength(1);
            int mLengthN = m.matrix.GetLength(0);

            if(mLengthN == this.matrix.GetLength(0) &&
                mLengthM == this.matrix.GetLength(1))
            {
                int i = 0, j = 0, actionsPerformed = 0;

                Matrix result = new Matrix(mLengthM, mLengthN);
                result.Init();

                for(i = 0; i < mLengthN; i++)
                {
                    for(j = 0; j < mLengthM; j++)
                    {
                        result.matrix[i,j] = m.matrix[i,j] + this.matrix[i,j];
                    }
                }

                actionsPerformed = i * j;
                Console.WriteLine("Aktionen durchgeführt: " + actionsPerformed);

                return result;
            }
            
            return null;
        }

        public Matrix Mult(Matrix m)
        {

            int mLengthM = m.matrix.GetLength(0);
            int mLengthN = m.matrix.GetLength(1);
            int lengthM = this.matrix.GetLength(0);
            int lengthN = this.matrix.GetLength(1);

            if(mLengthN == lengthM)
            {
                int i = 0, j = 0, k = 0, summe;

                Matrix result = new Matrix(mLengthM, lengthN);
                result.Init();

                for(i = 0; i < lengthN; i++)
                {
                    for(j = 0; j < lengthN; j++)
                    {
                        summe = 0;

                        for(k = 0; k < mLengthN; k++)
                        {
                            summe += this.matrix[k,j] * m.matrix[i,k];
                        }

                        result.matrix[i,j] = summe;
                    }
                }

                return result;
            }

            return null;
        }

        public Matrix MultVariante2(Matrix m)
        {
            Matrix result = new Matrix(this.matrix.GetLength(0), this.matrix.GetLength(1));

            result.matrix[0,0] = (m.matrix[0,0] + m.matrix[1,1]) * (this.matrix[0,0] + this.matrix[1,1])
                + (m.matrix[1,1] * (this.matrix[1,0] - this.matrix[0,0]))
                - ((m.matrix[0,0] + m.matrix[0,1]) * this.matrix[1,1])
                + ((m.matrix[0,1] - m.matrix[1,1]) * (this.matrix[1,0] + this.matrix[1,1]));

            result.matrix[0,1] = (m.matrix[0,0] * (this.matrix[0,1] - this.matrix[1,1]))
                + ((m.matrix[0,0] + m.matrix[0,1]) * this.matrix[1,1]);

            result.matrix[1,0] = ((m.matrix[1,0] + m.matrix[1,1]) * this.matrix[0,0])
                + (m.matrix[1,1] * (this.matrix[1,0] - this.matrix[0,0]));

            result.matrix[1,1] = ((m.matrix[0,0] + m.matrix[1,1]) * (this.matrix[0,0] + this.matrix[1,1]))
                - ((m.matrix[1,0] + m.matrix[1,1]) * this.matrix[0,0])
                + (m.matrix[0,0] * (this.matrix[0,1] - this.matrix[1,1]))
                + ((m.matrix[1,0] - m.matrix[0,0]) * (this.matrix[0,0] + this.matrix[0,1]));

            return result;
        }
    }
}