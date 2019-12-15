using System;
using System.Collections.Generic;

namespace exercise_sheet_11
{
    public class Exercise2
    {
        int[,] matrix;
        Knoten2[] knoten;
        int time;
        int count;

        public Exercise2()
        {
            // matrix = new int[,] {
            //     {0, 1, 1, 0, 0, 0, 1, 0, 0},
            //     {0, 0, 0, 1, 0, 0, 0, 0, 0},
            //     {1, 0, 0, 1, 1, 0, 0, 0, 0},
            //     {0, 0, 0, 0, 0, 0, 1, 0, 0},
            //     {1, 0, 0, 0, 0, 1, 0, 0, 1},
            //     {0, 0, 1, 1, 1, 0, 0, 1, 0},
            //     {0, 0, 0, 0, 0, 0, 0, 1, 0},
            //     {0, 0, 0, 1, 0, 0, 0, 0, 1},
            //     {0, 0, 0, 0, 0, 1, 0, 0, 0},
            // };
            matrix = new int[,] {
                {0, 1, 0, 1},
                {0, 0, 1, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };
            knoten = new Knoten2[matrix.GetLength(0)];

            Print(matrix);
            // DFS();
            topologischeSortierung();
        }

        public void topologischeSortierung()
        {
            int i, j;
            int[] vorgaenger = new int[knoten.Length];

            // Vorereitung: O(|V| + |V|^2)
            for (i = 0; i < vorgaenger.Length; i++)
            {
                vorgaenger[i] = 0;
            }

            for (j = 0; j < knoten.Length; j++)
            {
                for (i = 0; i < knoten.Length; i++)
                {
                    if (matrix[j,i] == 1)
                        vorgaenger[i] += 1;
                }
            }

            // Sortierung
            Console.Write("Topologische Sortierung: ");
            int count = 0;

            while (count < knoten.Length)
            {
                for (i = 0; i < vorgaenger.Length; i++)
                {                    
                    if (vorgaenger[i] == 0)
                    {
                        vorgaenger[i] = -1;
                        Console.Write(i + " ");
                        count++;
                        break;
                    }
                }

                for (j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        vorgaenger[j] -= 1;
                    }
                }
            }
        }

        public void DFS()
        {
            int i;

            Console.Write("Tiefensuche: ");

            for (i = 0; i < knoten.Length; i++)
            {
                knoten[i] = new Knoten2();
                knoten[i].color = "weiß";
                knoten[i].pred = null;
            }

            for (i = 0; i < 1; i++)
            {
                if (knoten[i].color == "weiß")
                {
                    DFSVisit(knoten[i], i, (i + " - "));
                } 
            }

            Console.WriteLine();
        }

        private void DFSVisit(Knoten2 v, int index, string zyklus)
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
                    {
                        knoten[i].pred = v;
                        DFSVisit(knoten[i], i, zyklus + i + " - ");
                    }
                    else if (knoten[i].color == "grau" && knoten[i] != v && knoten[i] != v.pred)
                    {
                        zyklus += Array.IndexOf(knoten, knoten[i]);
                        int test = Array.IndexOf(knoten, knoten[i]);
                        zyklus = zyklus.Substring(zyklus.IndexOf(test.ToString()));
                        Console.WriteLine("Zyklus gefunden: " + zyklus);
                        break;
                    }
                }
            }

            v.color = "schwarz";
            time += 1;
            v.lastTime = time;
            // Console.Write(index + " ");
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

    public class Knoten2
    {
        public string color;
        public Knoten2 pred;

        public int dist;

        public int firstTime;

        public int lastTime;

        public int index;

        public Knoten2() {}

        public Knoten2(int index) {
            this.index = index;
        }
    }
}