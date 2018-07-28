using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public class BinaryTree
    {
        public Node Root { get; set; }

        public Node Find(int value)
        {
            return Find(Root, value);
        }

        public Node Find(Node current, int value)
        {
            if (current == null)
                return null;

            if (current.Value == value)
                return current;

            if (current.Value < value)
                return Find(current.Right, value);

            return Find(current.Right, value);
        }


        public Node Add(int value)
        {
            Node node = Add(Root, value);
            if (Root == null)
                Root = node;

            return node;
        }

        public Node Add(Node current, int value)
        {
            // In case of root
            if (current == null)
                return new Node { Value = value };

            Node node = null;

            if (value < current.Value)
            {
                if (current.Left != null)
                    node = Add(current.Left, value);
                else
                {
                    node = new Node { Value = value };
                    current.Left = node;
                }
            }
            else
            {
                if (current.Right != null)
                    node = Add(current.Right, value);
                else
                {
                    node = new Node { Value = value };
                    current.Right = node;
                }
            }
            return node;
        }

        // Pre-Order serialization
        public IEnumerable<int> Serialize()
        {
            List<int> results = new List<int>();
            Serialize(Root, results);

            return results;
        }

        private void Serialize(Node node, List<int> results)
        {
            if (node == null)
                return;

            results.Add(node.Value);
            Serialize(node.Left, results);
            Serialize(node.Right, results);
        }


        public static BinaryTree Load(IEnumerable<int> values)
        {
            BinaryTree tree = new BinaryTree();
            foreach (var i in values)
                tree.Add(i);

            return tree;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            BinaryTree tree = BinaryTree.Load(new int[] { 4, 2, 1, 3, 6, 5, 7 });

            Console.WriteLine();
            Console.WriteLine("BST serialization");
            var serialize = tree.Serialize().ToArray();
            Console.WriteLine(string.Join<int>(", ", serialize));

            Console.WriteLine();
            Console.WriteLine("BST print");
            PrintBinaryTreePerLayer(tree);


            Console.WriteLine();
            int valueForSearch = 2;
            Console.WriteLine($"Find node layer of {valueForSearch}");
            int layer = FindLayer(tree, valueForSearch);
            Console.WriteLine("Layer: " + layer);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ANY key top continue");
            Console.ReadKey();
        }

        private static void PrintBinaryTreePerLayer(BinaryTree tree)
        {
            if ((tree == null) || (tree.Root == null))
                throw new NullReferenceException();

            List<Node> currentLayer = new List<Node>();
            currentLayer.Add(tree.Root);
            PrintBinaryTreePerLayer(currentLayer);
        }

        private static void PrintBinaryTreePerLayer(List<Node> currentLayer)
        {
            if (currentLayer == null)
                throw new NullReferenceException();

            if (currentLayer.Count == 0)
                return;

            List<Node> nextLayer = new List<Node>();
            foreach (Node node in currentLayer)
            {
                Console.Write(node.Value + " ");
                if (node.Left != null)
                    nextLayer.Add(node.Left);

                if (node.Right != null)
                    nextLayer.Add(node.Right);
            }

            Console.WriteLine();
            PrintBinaryTreePerLayer(nextLayer);
        }

        public static int FindLayer(BinaryTree tree, int value)
        {
            if (tree == null)
                throw new NullReferenceException();

            if (tree.Root == null)
                return -1;

            return FindLayer(tree.Root, value, 0);
        }

        public static int FindLayer(Node node, int value, int level)
        {
            if (node == null)
                return -1;

            if (node.Value == value)
                return level;

            if (node.Value > value)
                return FindLayer(node.Left, value, level + 1);

            return FindLayer(node.Right, value, level + 1);
        }
    }
}
