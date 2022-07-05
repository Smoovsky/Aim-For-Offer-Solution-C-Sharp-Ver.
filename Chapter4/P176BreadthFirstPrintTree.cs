using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static void P176BreadthFirstPrintTree(
        TreeNode<int>? root)
    {
        if (root == null)
        {
            return;
        }

        int currentLayer = 1;

        var stackOdd = new Stack<TreeNode<int>>();
        var stackEven = new Stack<TreeNode<int>>();

        var currentLayerPendingCount = 1;
        var nextLayerCount = 0;

        stackOdd.Push(root);

        while (stackOdd.Any()
            || stackEven.Any())
        {
            if (currentLayer % 2 == 1) //                         
            {
                var popped = stackOdd.Pop();

                Console.Write($"{popped.Value} ");

                if (popped.Left != null)
                {
                    stackEven.Push(popped.Left);
                    nextLayerCount++;
                }

                if (popped.Right != null)
                {
                    stackEven.Push(popped.Right);
                    nextLayerCount++;
                }

                if (--currentLayerPendingCount == 0)
                {
                    currentLayerPendingCount = nextLayerCount;
                    currentLayer++;
                }
            }
            else
            {
                var popped = stackEven.Pop();

                Console.Write($"{popped.Value} ");

                if (popped.Right != null)
                {
                    stackEven.Push(popped.Right);
                    nextLayerCount++;
                }

                if (popped.Left != null)
                {
                    stackEven.Push(popped.Left);
                    nextLayerCount++;
                }

                if (--currentLayerPendingCount == 0)
                {
                    currentLayerPendingCount = nextLayerCount;
                    currentLayer++;
                }
            }
        }
    }
}
