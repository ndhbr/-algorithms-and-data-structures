using System; 

namespace Exercise1
{
    public class Node { 
        public int value; 
        public Node left;
        public Node right; 
  
        public Node(int item) 
        { 
            value = item; 
            left = right = null; 
        } 
    } 
  
    class BinaryTree { 
        public static int preIndex = 0; 
    
        public virtual Node buildTree(int[] inOrder, int[] preOrder, int inStrt, int inEnd) 
        { 
            if (inStrt > inEnd) { 
                return null; 
            } 
    
            Node tNode = new Node(preOrder[preIndex++]); 
    
            if (inStrt == inEnd) { 
                return tNode; 
            } 
    
            int inIndex = search(inOrder, inStrt, inEnd, tNode.value); 
    
            tNode.left = buildTree(inOrder, preOrder, inStrt, inIndex - 1); 
            tNode.right = buildTree(inOrder, preOrder, inIndex + 1, inEnd); 
    
            return tNode; 
        } 
    
        public virtual int search(int[] arr, int strt, int end, int value) 
        { 
            int i; 
            for (i = strt; i <= end; i++) { 
                if (arr[i] == value) { 
                    return i; 
                } 
            } 

            return i; 
        } 
    
        public virtual void printInorder(Node node) 
        { 
            if (node == null) { 
                return; 
            } 
    
            printInorder(node.left); 
            Console.Write(node.value + " "); 
            printInorder(node.right); 
        } 
    } 
}