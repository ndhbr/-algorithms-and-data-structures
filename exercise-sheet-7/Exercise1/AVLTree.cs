using System;

namespace Exercise1
{
    public class AVLTree
    {
        private AVLNode root;

        public AVLTree() {
            root = null;
        }

        public void Insert(int val) {
            Insert(ref root, val);
        }
        public void Print()
        {
            Print(root);
            Console.WriteLine();
        }

        public void Delete(int val)
        {
            Delete(ref root, val);
        }

        private int Max(int a, int b) {
            return (a > b) ? a : b;
        }
        private int GetHeight(AVLNode element) {
            if (element == null)
                return -1;
            else
                return element.height;
        }
        private void UpdateHeight(AVLNode element) {
            element.height = 1 + Max(
                GetHeight(element.left),
                GetHeight(element.right)
            );
        }
        private void Insert(ref AVLNode element, int val) {
            if (element == null)
            {
                element = new AVLNode();
                element.height = 0;
                element.value = val;
                element.left = null;
                element.right = null;
            }
            else
            {
                if (val <= element.value)
                {
                    Insert(ref element.left, val);
                    CheckRotationRight(ref element);
                }
                else
                {
                    Insert(ref element.right, val);
                    CheckRotationLeft(ref element);
                }
            }
        }
        private void DeleteTree(AVLNode root) {}

        private AVLNode Delete(ref AVLNode element, int val)
        {
            if (element == null)
                return element;
            
            if (element.value > val)
            {
                element.left = Delete(ref element.left, val);
            }
            else if (element.value < val)
            {
                element.right = Delete(ref element.right, val);
            }
            else // element == val
            {
                if (element.left == null && element.right == null) // keine Nachfolger
                {
                    element = null;
                    return element;
                }
                else if (element.left == null) // Rechter Nachfolger
                {
                    element = element.right;
                }
                else if (element.right == null) // Linker Nachfolger
                {
                    element = element.left;
                }
                else // Zwei Nachfolger
                {
                    AVLNode min = element.right;

                    while (min.left != null)
                    {
                        min = min.left;                
                    }

                    element.value = min.value;

                    element.right = Delete(ref element.right, min.value);
                }

                CheckRotationLeft(ref element);
                CheckRotationRight(ref element);
            }

            return element;
        }

        private void CheckRotationRight(ref AVLNode element) {
            if (element != null)
            {
                if(element.left != null)
                {
                    if ((GetHeight(element.left) - GetHeight(element.right)) == 2)
                    {
                        if (GetHeight(element.left.right) >
                            GetHeight(element.left.left))
                        {
                            DoubleRotationRight(ref element);
                        }
                        else
                        {
                            RotateRight(ref element);
                        }
                    }
                    else
                    {
                        UpdateHeight(element);
                    }
                }
                else
                {
                    UpdateHeight(element);
                }
            }
        }
        private void CheckRotationLeft(ref AVLNode element) {
            if (element != null)
            {
                if(element.right != null)
                {
                    if ((GetHeight(element.right) - GetHeight(element.left)) == 2)
                    {
                        if (GetHeight(element.right.left) >
                            GetHeight(element.right.right))
                        {
                            DoubleRotationLeft(ref element);
                        }
                        else
                        {
                            RotateLeft(ref element);
                        }
                    }
                    else
                    {
                        UpdateHeight(element);
                    }
                }
                else
                {
                    UpdateHeight(element);
                }
            }            
        }
        private void Print(AVLNode curr) {
            if (curr != null)
            {
                Console.Write("(");
                Print(curr.left);
                Console.Write("," + curr.value + ",");
                Print(curr.right);
                Console.Write(")");
            }
            else
            {
                Console.Write("n");
            }
        }
        private void RotateLeft(ref AVLNode a) {
            AVLNode b = a.right;

            a.right = b.left;
            b.left = a;
            a = b;

            UpdateHeight(a.left);
            UpdateHeight(a);
        }
        private void RotateRight(ref AVLNode a) {
            AVLNode b = a.left;

            a.left = b.right;
            b.right = a;
            a = b;

            UpdateHeight(a.right);
            UpdateHeight(a);
        }
        private void DoubleRotationLeft(ref AVLNode a) {
            RotateRight(ref a.right);
            RotateLeft(ref a);
        }
        private void DoubleRotationRight(ref AVLNode a) {
            RotateLeft(ref a.left);
            RotateRight(ref a);
        }
    }
}