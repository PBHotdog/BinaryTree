using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**********************************************************************LOG OF ASSIGNMENT 3************************************************
|| Sutton 
|| The project was pretty hard, I had some real difficulty setting uo the delete function. There are a few functions that serve no purpose other than they were good for bug testing
|| Sutton - 100% of project

***********************************************************************END LOG OF ASSIGNMENT 3 *******************************************/
namespace BinaryTree
{
    class Node
    {
        public Node left, right;
        public int value;
        public Node(object val)
        {
            val = value;
            left = null;
            right = null;
        }
        public void printTree(Node root, int space)
        {
            if (root == null)
            {
                return;
            }
        }
        public void displayNode()
        {
            Console.WriteLine(value + " ");
        }
        public bool Search(Node Node, int searcher)
        {
            if (Node == null)
            {
                Console.WriteLine("no node found");
                return false;
            }
            else if (Node.value == searcher)
            {
                Console.WriteLine("Node found at " + searcher);
                return true;
            }
            else if (Node.value > searcher)
            {
                return Search(Node.left, searcher);

            }
            else if (Node.value < searcher)
            {
                return Search(Node.right, searcher);
            }
            else
            {
                return false;
            }
        }
    }

    class BinaryTree
    {
        private Node root;
        private int counter;
        public int depthRight;
        public int depthLeft;

        public BinaryTree()
        {
            root = null;
        }
        public Node returnRoot()
        {
            return root;
        }
        public bool isEmpty()
        {
            return root == null;
        }
        public void insert(int data)
        {
            Node newNode = new Node(data);
            newNode.value = data;
            if (isEmpty())
            {
                root = newNode;
                counter++;
            }
            else
            {
                bool added = false;
                Node current = root;
                Node parent;
                while (!added)
                {
                    parent = current;
                    if (current.value > data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            counter++;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            counter++;
                            return;

                        }
                    }
                }
            }
        }
        public void printCounter()
        {
            Console.WriteLine("Counter is at : " + counter);
        }
        public bool SearchTree(int searcher)
        {
            return root.Search(root, searcher);
        }
        public int minValue(Node root)
        {
            int minv = root.value;
            while (root.left != null)
            {
                minv = root.left.value;
                root = root.left;
            }
            return minv;
        }
        public Node deleteMain(Node root, int value)
        {
            if (root == null)
            {
                return root;

            }
            if (value < root.value)
            {
                root.left = deleteMain(root.left, value);
            }
            else if (value > root.value)
            {
                root.right = deleteMain(root.right, value);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                root.value = minValue(root.right);
                root.right = deleteMain(root.right, root.value);
            }
            return root;
        }
        public void delete(int value)
        {
            root = deleteMain(root, value);
            counter--;
        }

        public void printTree()
        {
            if (root == null)
            {
                return;
            }
        }
        public void inOrderTraversal(Node root)
        {
            if (root != null)
            {
                inOrderTraversal(root.left);
                depthLeft++;
                Console.WriteLine("[ " + root.value + " ]");
                inOrderTraversal(root.right);
                depthRight++;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endConsole = false;
            int insertNumber;
            int deleteNumber;
            Console.WriteLine("Please enter one value at a time, whenever you are done type 'Done'");
            BinaryTree tree = new BinaryTree();
            while (true)
            {
                string values = Console.ReadLine();
                if (values == "Done")
                {
                    break;
                }
                int newValues = Convert.ToInt32(values);
                tree.insert(newValues);
                Console.WriteLine("Inorder traversal ");
                tree.inOrderTraversal(tree.returnRoot());
                tree.printCounter();
            }
            while (endConsole == false)
            {

                Console.WriteLine("Would you like to edit the tree? Reply Y or N");
                string answertwo = Console.ReadLine();
                if (answertwo == "Y")
                {
                    Console.WriteLine("Insert or Delete a value? Type either Insert or Delete depending on what you would like");
                    string answerthree = Console.ReadLine();
                    if (answerthree == "Insert")
                    {
                        Console.WriteLine("Please enter the number you would like to insert:");
                        insertNumber = Convert.ToInt32(Console.ReadLine());
                        tree.insert(insertNumber);
                        Console.WriteLine("Inorder traversal ");
                        tree.inOrderTraversal(tree.returnRoot());

                    }
                    else if (answerthree == "Delete")
                    {
                        Console.WriteLine("Please enter the number you would like to delete");
                        deleteNumber = Convert.ToInt32(Console.ReadLine());
                        tree.delete(deleteNumber);
                        Console.WriteLine("Inorder traversal");
                        tree.inOrderTraversal(tree.returnRoot());
                    }
                    else
                    {
                        Console.WriteLine("Sorry! I didn't recognise your input. Please try again!");
                        Console.WriteLine("---------------");
                        break;
                    }

                }
                else if (answertwo == "N")
                {
                    Console.WriteLine("Alright then, if you change your mind you can go again!");
                    Console.WriteLine("---------------");
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry! I didn't recognise your input. Please try again!");
                    Console.WriteLine("---------------");
                    break;
                }
            }
        }
    }
}
