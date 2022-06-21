using System;

namespace CuctomBinaryTree 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(new int[]{7, 3, 1, 9, 4, 6, 8, 10, 12});
            /*             7          
             *         3   |    9
             *       1   4 |  8   10
             *            6|        12
             */

            //Console.WriteLine("In-order traversal:");
            //tree.InOrderTraversal();
            //Console.WriteLine("Pre-order traversal:");
            //tree.PreOrderTraversal();
            //Console.WriteLine("Post-order traversal:");
            //tree.PostOrderTraversal();

            for(int i = 0; i < 13; i++)
            {
                Console.WriteLine($"Value {i} exists: '{tree.Contains(i)}'");    
            }
            
        }

        public class Node
        {
            public Node(int i) 
            {
                data = i;
            }
            public Node left { get; set; }
            public Node right { get; set; }
            public int data { get; set; } 
        }

        class BinaryTree
        {
            Node root;

            public BinaryTree(int[] arr)
            {
                foreach(int i in arr)
                {
                    root = Insert(root, i);
                }
            }
            public Node Insert(Node root, int value)
            {
                if (root == null)
                {
                    root = new Node(value);
                }
                else
                {
                    if (value < root.data)
                    {
                        root.left = Insert(root.left, value);
                    }
                    else if (value > root.data)
                    {
                        root.right = Insert(root.right, value);
                    }
                }
                return root;
            }

            //Traverses through the tree visiting roots before leaves starting from the left
            public void PreOrderTraversal()
            {
                PreOrderTraversal(root);
            }
            public void PreOrderTraversal(Node root)
            {
                if (root == null) return;
                
                Console.WriteLine($"-->{root.data}");
                PreOrderTraversal(root.left);
                PreOrderTraversal(root.right);
            }

            //traverses throught the tree visiting left -> root -> right nodes sequentially
            public void InOrderTraversal()
            {
                InOrderTraversal(root);
            }
            public void InOrderTraversal(Node root)
            {
                if (root == null) return;

                InOrderTraversal(root.left);
                Console.WriteLine($"-->{root.data}");
                InOrderTraversal(root.right);
            }
            //Traverses through the tree visiting leaves first, followed by root
            public void PostOrderTraversal()
            {
                PostOrderTraversal(root);
            }
            public void PostOrderTraversal(Node root)
            {
                if (root == null) return;

                PostOrderTraversal(root.left);
                PostOrderTraversal(root.right);
                Console.WriteLine($"-->{root.data}");

            }

            //returns true if given value exists in the tree, otherwise returns false
            public bool Contains(int value)
            {
                return Contains(root, value);
            }
            public bool Contains(Node root, int value)
            {
                if(root == null) return false;
                if(root.data == value) return true;
                else
                return (value < root.data) ? Contains(root.left, value): Contains(root.right, value);
            }
        }
    }
}
