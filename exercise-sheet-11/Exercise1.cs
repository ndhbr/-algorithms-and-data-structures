using System;
using System.Collections.Generic;

namespace exercise_sheet_11
{
    public class Exercise1
    {
        int[,] matrix;
        Knoten[] knoten;
        int time;
        int count;

        public Exercise1()
        {
            matrix = new int[,] {
                {0, 1, 1, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0},
                {1, 0, 0, 1, 1, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 1, 0, 0},
                {1, 0, 0, 0, 0, 1, 0, 0, 1},
                {0, 0, 1, 1, 1, 0, 0, 1, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0, 1, 0, 0, 0},
            };
            knoten = new Knoten[9];

            Print(matrix);
            DFS();
            BFS();
        }

        public void DFS()
        {
            int i;

            Console.Write("Tiefensuche: ");

            for (i = 0; i < knoten.Length; i++)
            {
                knoten[i] = new Knoten();
                knoten[i].color = "weiß";
                knoten[i].pred = null;
            }

            for (i = 0; i < knoten.Length; i++)
            {
                if (knoten[i].color == "weiß")
                    DFSVisit(knoten[i], i);
            }

            Console.WriteLine();
        }

        private void DFSVisit(Knoten v, int index)
        {
            int i;

            time += 1;
            v.firstTime = time;
            v.color = "grau";

            for (i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[index,i] == 1)
                {
                    if (knoten[i].color == "weiß")
                        knoten[i].pred = v;
                }
            }

            v.color = "schwarz";
            time += 1;
            v.lastTime = time;
            Console.Write(index + " ");
        }

        public void BFS()
        {
            Queue<Knoten> schlange = new Queue<Knoten>();
            Knoten v0 = knoten[0];
            int i;
            int count = 0;

            Console.Write("Breitensuche: ");

            for (i = 0; i < knoten.Length; i++)
            {
                knoten[i] = new Knoten(count++);
                knoten[i].color = "weiß";
                knoten[i].dist = int.MaxValue;
                knoten[i].pred = null;
            }

            v0.color = "grau";
            v0.dist = 0;
            v0.pred = null;

            schlange.Enqueue(v0);

            while (schlange.Count > 0)
            {
                Knoten u = schlange.Dequeue();

                for (i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[u.index,i] == 1)
                    {
                        if (knoten[i].color == "weiß")
                        {
                            knoten[i].color = "grau";
                            knoten[i].dist = u.dist + 1;
                            knoten[i].pred = u;
                            schlange.Enqueue(knoten[i]);
                        }
                    }
                }

                u.color = "schwarz";
                Console.Write(u.index + " ");
            }

            Console.WriteLine();
        }

        public void Print(int[,] matrix)
        {
            int i, j;

            Console.WriteLine("----------------------");

            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("----------------------");
        }
    }

    public class Knoten
    {
        public string color;
        public Knoten pred;

        public int dist;

        public int firstTime;

        public int lastTime;

        public int index;

        public Knoten() {}

        public Knoten(int index) {
            this.index = index;
        }
    }
}