using System;

namespace exercise_sheet_1
{
    public class Exercise3
    {
        public Exercise3()
        {
            Matrix m = new Matrix(3, 2);
            m.Init();
            m.Input();
            /*m.matrix = new int[,]{
                {1,2,3,4,5,6,7,8},
                {9,10,11,12,13,14,15,16},
                {17,18,19,20,21,22,23,24},
                {25,26,27,28,29,30,31,32}              
            };*/

            Matrix m1 = new Matrix(2, 3);
            m1.Init();
            m1.Input();
            /*m1.matrix = new int[,]{
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16},
                {17,18,19,20}
            };*/

            /*Matrix r = m.Add(m1);
            r.Print();*/
            Matrix r = m.Mult(m1);
            r.Print();
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

            for(i = 0; i < this.matrix.GetLength(0); i++)
            {
                for(j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i,j] = 0;
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
                int i, j;

                Matrix result = new Matrix(mLengthM, mLengthN);
                result.Init();

                for(i = 0; i < mLengthN; i++)
                {
                    for(j = 0; j < mLengthM; j++)
                    {
                        result.matrix[i,j] = m.matrix[i,j] + this.matrix[i,j];
                    }
                }

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
                int i, j, k, summe;

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
    }
}