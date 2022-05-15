namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static TreeNode<T> RebuildBinaryTreeP62<T>(
            T[] preOrder,
            T[] inOrder)
        {
            if (preOrder == null)
            {
                throw new ArgumentNullException(nameof(preOrder));
            }

            if (inOrder == null)
            {
                throw new ArgumentNullException(nameof(inOrder));
            }

            if (preOrder.Length != inOrder.Length)
            {
                throw new ArgumentException("Invalid argument.");
            }

            if (preOrder.Except(inOrder).Any())
            {
                throw new ArgumentException("Invalid argument.");
            }

            return RebuildBinaryTreeCoreP62(
                0,
                preOrder.Length - 1,
                0,
                preOrder.Length - 1,
                preOrder,
                inOrder);
        }

        public static TreeNode<T> RebuildBinaryTreeCoreP62<T>(
            int startPreOrder,
            int endPreOrder,
            int startInOrder,
            int endInOrder,
            T[] preOrder,
            T[] inOrder)
        {
            var root = new TreeNode<T>
            {
                Value = preOrder[startPreOrder]
            };

            if (startPreOrder == endPreOrder)
            {
                if (startInOrder == endInOrder
                    && preOrder[startPreOrder]!.Equals(inOrder[endInOrder]))
                {
                    return root;
                }
                else
                {
                    throw new ArgumentException("Invalid argument.");
                }
            }

            var inRootIndex = startInOrder;

            while (!inOrder[inRootIndex]!.Equals(root.Value)
                && inRootIndex <= endInOrder)
            {
                inRootIndex++;
            }

            if (!inOrder[inRootIndex]!.Equals(root.Value))
            {
                throw new ArgumentException("Invalid argument.");
            }

            bool buildLeft = inRootIndex > startInOrder;
            bool buildRight = inRootIndex < endInOrder;

            var leftLen = inRootIndex - startInOrder;

            if (buildLeft)
            {
                root.Left = RebuildBinaryTreeCoreP62(
                    startPreOrder + 1,
                    startPreOrder + leftLen,
                    startInOrder,
                    inRootIndex - 1,
                    preOrder,
                    inOrder);
            }

            if (buildRight)
            {
                root.Right = RebuildBinaryTreeCoreP62<T>(
                    startPreOrder + leftLen + 1,
                    endPreOrder,
                    inRootIndex + 1,
                    endInOrder,
                    preOrder,
                    inOrder);
            }

            return root;
        }

        public class TreeNode<T>
        {
            public TreeNode()
            {
                
            }

            public TreeNode(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public TreeNode<T> Parent { get; set; }

            public TreeNode<T> Left { get; set; }

            public TreeNode<T> Right { get; set; }
        }

        public static readonly int COUNT = 10;

        public static void Print2DUtil<T>(TreeNode<T> root, int space)
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
        public static void Print2D<T>(TreeNode<T> root)
        {
            // Pass initial space count as 0
            Print2DUtil(root, 0);
        }
    }
}