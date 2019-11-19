using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise1();
            Exercise2();
            // Exercise3();
        }

        static void Exercise2()
        {
            BinaryTree tree = new BinaryTree(); 
            int[] preOrder = new int[] {3, 4, 9, 1, 7, 5, 6};
            int[] inOrder = new int[] {9, 4, 1, 3, 5, 7, 6};

            Node root = tree.buildTree(inOrder, preOrder, 0, inOrder.Length - 1); 
    
            Console.Write("Reconstructed Tree Printed InOrder: "); 
            tree.printInorder(root); 
            Console.WriteLine();
        }

        static void Exercise1()
        {
            SuchBaum baum = new SuchBaum();
            // Inorder: 1 2 3 4
            // Preorder: 4 3 2 1
            // baum.Insert(4);
            // baum.Insert(3);
            // baum.Insert(2);
            // baum.Insert(1);

            baum.PreorderReadTree(new int[] {4, 3, 2, 1});
            baum.PrintInOrder();
            baum.PrintPreOrder();

            SuchBaum baum2 = new SuchBaum();
            baum2.PreorderReadTree(new int[] {1, 2, 3, 4});
            baum2.PrintInOrder();
            baum2.PrintPreOrder();
        }

        static void Exercise3()
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
    }
}
