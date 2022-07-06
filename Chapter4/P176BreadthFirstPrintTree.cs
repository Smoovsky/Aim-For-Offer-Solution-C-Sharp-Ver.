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

        var queue = new Queue<TreeNode<int>>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            var current = queue.Dequeue();

            Console.Write($"{current.Value} ");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        Console.WriteLine(string.Empty);
    }

    public static void P176LayeredBreadthFirstPrintTree(
        TreeNode<int>? root)
    {
        if (root == null)
        {
            return;
        }

        var currentLayerPendingCount = 1;
        var nextLayerCount = 0;

        var queue = new Queue<TreeNode<int>>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            var current = queue.Dequeue();
            Console.Write($"{current.Value} ");

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
                nextLayerCount++;
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
                nextLayerCount++;
            }

            if (--currentLayerPendingCount == 0)
            {
                currentLayerPendingCount = nextLayerCount;
                nextLayerCount = 0;
                Console.WriteLine(string.Empty);
            }
        }

        Console.WriteLine(string.Empty);
    }

    public static void P176ZigZagBreadthFirstPrintTree(
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
            if (currentLayer % 2 == 1)
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
                    Console.WriteLine(string.Empty);
                    currentLayerPendingCount = nextLayerCount;
                    nextLayerCount = 0;
                    currentLayer++;
                }
            }
            else
            {
                var popped = stackEven.Pop();

                Console.Write($"{popped.Value} ");

                if (popped.Right != null)
                {
                    stackOdd.Push(popped.Right);
                    nextLayerCount++;
                }

                if (popped.Left != null)
                {
                    stackOdd.Push(popped.Left);
                    nextLayerCount++;
                }

                if (--currentLayerPendingCount == 0)
                {
                    Console.WriteLine(string.Empty);
                    currentLayerPendingCount = nextLayerCount;
                    nextLayerCount = 0;
                    currentLayer++;
                }
            }
        }
    }

    // ====================测试代码====================
    public static void P176BreadthFirstTest(string testName, TreeNode<int>? pRoot)
    {
        if (testName != null)
            Console.WriteLine($"{testName} begins:");

        TreeNode<int>.Print2D(pRoot);

        Console.WriteLine("The nodes from top to bottom, from left to right are:");
        P176BreadthFirstPrintTree(pRoot);

        Console.WriteLine("\n");
    }

    //            10
    //         /      \
    //        6        14
    //       /\        /\
    //      4  8     12  16
    public static void P176BreadthFirstTest1()
    {
        var pNode10 = new TreeNode<int>(10);
        var pNode6 = new TreeNode<int>(6);
        var pNode14 = new TreeNode<int>(14);
        var pNode4 = new TreeNode<int>(4);
        var pNode8 = new TreeNode<int>(8);
        var pNode12 = new TreeNode<int>(12);
        var pNode16 = new TreeNode<int>(16);

        TreeNode<int>.ConnectTreeNodes(pNode10, pNode6, pNode14);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode4, pNode8);
        TreeNode<int>.ConnectTreeNodes(pNode14, pNode12, pNode16);

        P176BreadthFirstTest("Test1", pNode10);


    }

    //               5
    //              /
    //             4
    //            /
    //           3
    //          /
    //         2
    //        /
    //       1
    public static void P176BreadthFirstTest2()
    {
        var pNode5 = new TreeNode<int>(5);
        var pNode4 = new TreeNode<int>(4);
        var pNode3 = new TreeNode<int>(3);
        var pNode2 = new TreeNode<int>(2);
        var pNode1 = new TreeNode<int>(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode1, null);

        P176BreadthFirstTest("Test2", pNode5);


    }

    // 1
    //  \
    //   2
    //    \
    //     3
    //      \
    //       4
    //        \
    //         5
    public static void P176BreadthFirstTest3()
    {
        var pNode1 = new TreeNode<int>(1);
        var pNode2 = new TreeNode<int>(2);
        var pNode3 = new TreeNode<int>(3);
        var pNode4 = new TreeNode<int>(4);
        var pNode5 = new TreeNode<int>(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, null, pNode2);
        TreeNode<int>.ConnectTreeNodes(pNode2, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode5);

        P176BreadthFirstTest("Test3", pNode1);


    }

    // 树中只有1个结点
    public static void P176BreadthFirstTest4()
    {
        var pNode1 = new TreeNode<int>(1);
        P176BreadthFirstTest("Test4", pNode1);
    }

    // 树中没有结点
    public static void P176BreadthFirstTest5()
    {
        P176BreadthFirstTest("Test5", null);
    }

    // ====================测试代码====================
    //            8
    //        6      10
    //       5 7    9  11
    public static void P176LayeredBreadthFirstPrintTreeTest1()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode10 = new(10);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode7 = new(7);
        TreeNode<int> pNode9 = new(9);
        TreeNode<int> pNode11 = new(11);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode6, pNode10);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, pNode7);
        TreeNode<int>.ConnectTreeNodes(pNode10, pNode9, pNode11);

        Console.Write("====Test1 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("8 \n");
        Console.Write("6 10 \n");
        Console.Write("5 7 9 11 \n\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(pNode8);
        Console.Write("\n");


    }

    //            5
    //          4
    //        3
    //      2
    public static void P176LayeredBreadthFirstPrintTreeTest2()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);

        Console.Write("====Test2 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n");
        Console.Write("4 \n");
        Console.Write("3 \n");
        Console.Write("2 \n\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    //        5
    //         4
    //          3
    //           2
    public static void P176LayeredBreadthFirstPrintTreeTest3()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode2);

        Console.Write("====Test3 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n");
        Console.Write("4 \n");
        Console.Write("3 \n");
        Console.Write("2 \n\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    public static void P176LayeredBreadthFirstPrintTreeTest4()
    {
        TreeNode<int> pNode5 = new(5);

        Console.Write("====Test4 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    public static void P176LayeredBreadthFirstPrintTreeTest5()
    {
        Console.Write("====Test5 Begins: ====\n");
        Console.Write("Expected Result is:\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(null);
        Console.Write("\n");
    }

    //        100
    //        /
    //       50   
    //         \
    //         150
    public static void P176LayeredBreadthFirstPrintTreeTest6()
    {
        TreeNode<int> pNode100 = new(100);
        TreeNode<int> pNode50 = new(50);
        TreeNode<int> pNode150 = new(150);

        TreeNode<int>.ConnectTreeNodes(pNode100, pNode50, null);
        TreeNode<int>.ConnectTreeNodes(pNode50, null, pNode150);

        Console.Write("====Test6 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("100 \n");
        Console.Write("50 \n");
        Console.Write("150 \n\n");

        Console.Write("Actual Result is: \n");
        P176LayeredBreadthFirstPrintTree(pNode100);
        Console.Write("\n");
    }

    // ====================测试代码====================
    //            8
    //        6      10
    //       5 7    9  11
    public static void P176ZigZagBreadthFirstPrintTreeTest1()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode10 = new(10);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode7 = new(7);
        TreeNode<int> pNode9 = new(9);
        TreeNode<int> pNode11 = new(11);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode6, pNode10);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, pNode7);
        TreeNode<int>.ConnectTreeNodes(pNode10, pNode9, pNode11);

        Console.Write("====Test1 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("8 \n");
        Console.Write("10 6 \n");
        Console.Write("5 7 9 11 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode8);
        Console.Write("\n");


    }

    //            5
    //          4
    //        3
    //      2
    public static void P176ZigZagBreadthFirstPrintTreeTest2()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);

        Console.Write("====Test2 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n");
        Console.Write("4 \n");
        Console.Write("3 \n");
        Console.Write("2 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    //        5
    //         4
    //          3
    //           2
    public static void P176ZigZagBreadthFirstPrintTreeTest3()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode2);

        Console.Write("====Test3 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n");
        Console.Write("4 \n");
        Console.Write("3 \n");
        Console.Write("2 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    public static void P176ZigZagBreadthFirstPrintTreeTest4()
    {
        TreeNode<int> pNode5 = new(5);

        Console.Write("====Test4 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("5 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode5);
        Console.Write("\n");


    }

    public static void P176ZigZagBreadthFirstPrintTreeTest5()
    {
        Console.Write("====Test5 Begins: ====\n");
        Console.Write("Expected Result is:\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(null);
        Console.Write("\n");
    }

    //        100
    //        /
    //       50   
    //         \
    //         150
    public static void P176ZigZagBreadthFirstPrintTreeTest6()
    {
        TreeNode<int> pNode100 = new(100);
        TreeNode<int> pNode50 = new(50);
        TreeNode<int> pNode150 = new(150);

        TreeNode<int>.ConnectTreeNodes(pNode100, pNode50, null);
        TreeNode<int>.ConnectTreeNodes(pNode50, null, pNode150);

        Console.Write("====Test6 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("100 \n");
        Console.Write("50 \n");
        Console.Write("150 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode100);
        Console.Write("\n");
    }

    //                8
    //        4              12
    //     2     6       10      14
    //   1  3  5  7     9 11   13  15
    public static void P176ZigZagBreadthFirstPrintTreeTest7()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode12 = new(12);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode10 = new(10);
        TreeNode<int> pNode14 = new(14);
        TreeNode<int> pNode1 = new(1);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode7 = new(7);
        TreeNode<int> pNode9 = new(9);
        TreeNode<int> pNode11 = new(11);
        TreeNode<int> pNode13 = new(13);
        TreeNode<int> pNode15 = new(15);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode4, pNode12);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode2, pNode6);
        TreeNode<int>.ConnectTreeNodes(pNode12, pNode10, pNode14);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode1, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, pNode7);
        TreeNode<int>.ConnectTreeNodes(pNode10, pNode9, pNode11);
        TreeNode<int>.ConnectTreeNodes(pNode14, pNode13, pNode15);

        Console.Write("====Test7 Begins: ====\n");
        Console.Write("Expected Result is:\n");
        Console.Write("8 \n");
        Console.Write("12 4 \n");
        Console.Write("2 6 10 14 \n");
        Console.Write("15 13 11 9 7 5 3 1 \n\n");

        Console.Write("Actual Result is: \n");
        P176ZigZagBreadthFirstPrintTree(pNode8);
        Console.Write("\n");


    }
}
