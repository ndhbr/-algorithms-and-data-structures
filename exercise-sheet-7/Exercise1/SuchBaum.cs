using System;

namespace Exercise1
{
    public class SuchBaum
    {
        private BaumElement wurzel;

        public SuchBaum()
        {
            wurzel = null;
        }

        public void PreorderReadTree(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Insert(a[i]);
            }
        }

        public void Insert(int a)
        {
            BaumElement element = new BaumElement();
            element.value = a;
            element.left = null;
            element.right = null;

            if (wurzel == null)
            {
                wurzel = element;
            }
            else
            {
                Insert(wurzel, element);
            }
        }

        public bool Contains(int a)
        {
            BaumElement curr = wurzel;

            while (curr != null)
            {
                if (curr.value == a)
                {
                    return true;
                }
                else
                {
                    if (a <= curr.value)
                        curr = curr.left;
                    else
                        curr = curr.right;
                }
            }

            return false;
        }

        public BaumElement DeleteValueRecursive(int a)
        {
            return DeleteValueRecursive(wurzel, a);
        }

        private BaumElement DeleteValueRecursive(BaumElement wurzel, int a)
        {
            if (wurzel == null)
                return wurzel;
            
            if (wurzel.value > a)
            {
                wurzel.left = DeleteValueRecursive(wurzel.left, a);
            }
            else if (wurzel.value < a)
            {
                wurzel.right = DeleteValueRecursive(wurzel.right, a);
            }
            else // wurzel == a
            {
                if (wurzel.left == null && wurzel.right == null) // keine Nachfolger
                {
                    wurzel = null;
                    return wurzel;
                }
                else if (wurzel.left == null) // Rechter Nachfolger
                {
                    wurzel = wurzel.right;
                }
                else if (wurzel.right == null) // Linker Nachfolger
                {
                    wurzel = wurzel.left;
                }
                else // Zwei Nachfolger
                {
                    BaumElement min = wurzel.right;

                    while (min.left != null)
                    {
                        min = min.left;                
                    }

                    wurzel.value = min.value;

                    wurzel.right = DeleteValueRecursive(wurzel.right, min.value);
                }
            }

            return wurzel;
        }

        public void DeleteValueIterative(int a)
        {
            DeleteValueIterative(wurzel, a);
        }

        public void DeleteValueIterative(BaumElement wurzel, int a)
        {
            BaumElement curr = wurzel;
            BaumElement pre = curr;
            bool left = true;

            while (curr != null)
            {
                if (curr.value == a)
                {
                    if (curr.left == null && curr.right == null) // kein Nachfolger
                    {
                        curr = null;
                    }
                    else if (curr.left == null && curr.right != null) // ein Nachfolger rechts
                    {
                        curr = curr.right;
                    }
                    else if (curr.left != null && curr.right == null) // ein Nachfolger links
                    {
                        curr = curr.left;
                    }
                    else // zwei Nachfolger
                    {
                        BaumElement smallest = curr.left;
                        BaumElement tmp = curr;

                        while (smallest.left != null)
                        {
                            smallest = smallest.left;
                        }

                        curr = smallest;
                        DeleteValueIterative(tmp, smallest.value);
                        curr.right = tmp.right;
                        curr.left = tmp.left;
                        smallest = null;
                    }

                    if (left)
                        pre.left = curr;
                    else
                        pre.right = curr;
                }
                else
                {
                    if (a <= curr.value)
                    {
                        pre = curr;
                        curr = curr.left;
                        left = true;
                    }
                    else
                    {
                        pre = curr;
                        curr = curr.right;
                        left = false;
                    }
                }
            }
        }

        public void Print()
        {
            Print(wurzel);
            Console.WriteLine();
        }

        private void Insert(BaumElement aktuelleWurzel, BaumElement element)
        {
            if (element.value <= aktuelleWurzel.value)
            {
                if (aktuelleWurzel.left == null)
                {
                    aktuelleWurzel.left = element;
                }
                else
                {
                    Insert(aktuelleWurzel.left, element);
                }
            }
            else
            {
                if (aktuelleWurzel.right == null)
                {
                    aktuelleWurzel.right = element;
                }
                else
                {
                    Insert(aktuelleWurzel.right, element);
                }
            }
        }

        private void DeleteTree(BaumElement wurzel)
        {
            if (wurzel != null)
            {
                if (wurzel.left != null)
                    DeleteTree(wurzel.left);

                if (wurzel.right != null)
                    DeleteTree(wurzel.right);

                wurzel = null;
            }
        }

        private void Print(BaumElement wurzel)
        {
            if (wurzel != null)
            {
                Console.Write("(");
                Print(wurzel.left);
                Console.Write("," + wurzel.value + ",");
                Print(wurzel.right);
                Console.Write(")");
            }
            else
            {
                Console.Write("n");
            }
        }

        public void PrintInOrder()
        {
            Console.Write("Inorder: ");
            PrintInOrder(wurzel);
            Console.WriteLine();
        }

        public void PrintPreOrder()
        {
            Console.Write("Preorder: ");
            PrintPreOrder(wurzel);
            Console.WriteLine();
        }

        private void PrintInOrder(BaumElement wurzel)
        {
            if (wurzel != null)
            {
                PrintInOrder(wurzel.left);
                Console.Write(wurzel.value + " ");
                PrintInOrder(wurzel.right);
            }
        }

        private void PrintPreOrder(BaumElement wurzel)
        {
            if (wurzel != null)
            {
                Console.Write(wurzel.value + " ");
                PrintPreOrder(wurzel.left);
                PrintPreOrder(wurzel.right);
            }
        }
    }
}