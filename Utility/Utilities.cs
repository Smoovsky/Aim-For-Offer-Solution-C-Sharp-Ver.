namespace Algorithm.Utility;

public static class Utilities
{
    public class LinkedListNode<T>
    {
        public T? Value { get; set; }

        public LinkedListNode<T>? Next { get; set; }

        public static LinkedListNode<TV> Create<TV>(TV val) => new()
        {
            Value = val
        };

        public static void Connect<TV>(
            LinkedListNode<TV> p,
            LinkedListNode<TV> c)
        {
            if (p == null)
            {
                return;
            }

            p.Next = c;
        }

        public static void Print<TV>(LinkedListNode<TV>? node)
        {
            while (node != null)
            {
                Console.Write($"{node.Value}\t");
                node = node.Next;
            }

            Console.Write("\n");
        }
    }

    public class TreeNode<T>
    {
        public TreeNode()
        {

        }

        public TreeNode(T? value) => Value = value;

        public T? Value { get; set; }

        public TreeNode<T>? Parent { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }

        public static readonly int COUNT = 10;

        public static void Print2DUtil<K>(TreeNode<K>? root, int space)
        {
            // Base case
            if (root == null)
                return;

            // Increase distance between levels
            space += COUNT;

            // Process right child first
            Print2DUtil(root.Right, space);

            // Print current node after space
            // count
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            // Process left child
            Print2DUtil(root.Left, space);
        }

        // Wrapper over print2DUtil()
        public static void Print2D<K>(TreeNode<K>? root)
        {
            // Pass initial space count as 0
            Print2DUtil(root, 0);
        }
    }
}
