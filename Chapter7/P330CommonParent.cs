using System.Collections.Generic;

namespace Algorithm.Chapter7;

public static partial class Solution
{
    public class MultiChildNode<T>
    {
        public T Value { get; set; }

        public ICollection<MultiChildNode<T>> Children { get; set; } = new List<MultiChildNode<T>>();

        public static void Connect(MultiChildNode<T> root, MultiChildNode<T> child)
        {
            if (root == null || child == null)
            {
                return;
            }

            root.Children ??= new List<MultiChildNode<T>>();

            root.Children.Add(child);
        }

        public MultiChildNode(T val) => Value = val;
    }

    public static MultiChildNode<T> P330CommonParent<T>(
        MultiChildNode<T> root,
        MultiChildNode<T> node1,
        MultiChildNode<T> node2)
    {
        if (root == null || node1 == null || node2 == null)
        {
            return null;
        }

        bool found1 = false, found2 = false;

        var path1 = GetPath(root, node1, ref found1);
        var path2 = GetPath(root, node2, ref found2);

        if (!found1 || !found2)
        {
            return null;
        }

        var current1 = root;
        var current2 = root;
        var idx1 = 0;
        var idx2 = 0;

        var lastSame = root;

        while (current1 == current2)
        {
            if (idx1 == path1.Count - 1
                || idx2 == path2.Count - 1)
            {
                break;
            }

            lastSame = current1;

            current1 = path1[++idx1];
            current2 = path2[++idx2];
        }

        return lastSame;
    }

    public static List<MultiChildNode<T>> GetPath<T>(
        MultiChildNode<T> current,
        MultiChildNode<T> node,
        ref bool found,
        List<MultiChildNode<T>> path = null)
    {
        path ??= new List<MultiChildNode<T>>();

        path.Add(current);

        if (current == node)
        {
            found = true;

            return path;
        }

        if (current.Children?.Any() != true)
        {
            path.RemoveAt(path.Count - 1);

            return path;
        }

        foreach (var child in current.Children)
        {
            GetPath(child, node, ref found, path);

            if (found)
            {
                break;
            }
        }

        if (!found)
        {
            path.RemoveAt(path.Count - 1);
        }

        return path;
    }


    // ====================测试代码====================
    public static void Test(string testName, MultiChildNode<int> pRoot, MultiChildNode<int> pNode1, MultiChildNode<int> pNode2, MultiChildNode<int> pExpected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        MultiChildNode<int> pResult = P330CommonParent(pRoot, pNode1, pNode2);

        if ((pExpected == null && pResult == null) ||
            (pExpected != null && pResult != null && pResult.Value == pExpected.Value))
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    // 形状普通的树
    //              1
    //            /   \
    //           2     3
    //       /       \
    //      4         5
    //     / \      / |  \
    //    6   7    8  9  10
    public static void P330Test1()
    {
        MultiChildNode<int> pNode1 = new(1);
        MultiChildNode<int> pNode2 = new(2);
        MultiChildNode<int> pNode3 = new(3);
        MultiChildNode<int> pNode4 = new(4);
        MultiChildNode<int> pNode5 = new(5);
        MultiChildNode<int> pNode6 = new(6);
        MultiChildNode<int> pNode7 = new(7);
        MultiChildNode<int> pNode8 = new(8);
        MultiChildNode<int> pNode9 = new(9);
        MultiChildNode<int> pNode10 = new(10);

        MultiChildNode<int>.Connect(pNode1, pNode2);
        MultiChildNode<int>.Connect(pNode1, pNode3);

        MultiChildNode<int>.Connect(pNode2, pNode4);
        MultiChildNode<int>.Connect(pNode2, pNode5);

        MultiChildNode<int>.Connect(pNode4, pNode6);
        MultiChildNode<int>.Connect(pNode4, pNode7);

        MultiChildNode<int>.Connect(pNode5, pNode8);
        MultiChildNode<int>.Connect(pNode5, pNode9);
        MultiChildNode<int>.Connect(pNode5, pNode10);

        Test("P330Test1", pNode1, pNode6, pNode8, pNode2);
    }

    // 树退化成一个链表
    //               1
    //              /
    //             2
    //            /
    //           3
    //          /
    //         4
    //        /
    //       5
    public static void P330Test2()
    {
        MultiChildNode<int> pNode1 = new(1);
        MultiChildNode<int> pNode2 = new(2);
        MultiChildNode<int> pNode3 = new(3);
        MultiChildNode<int> pNode4 = new(4);
        MultiChildNode<int> pNode5 = new(5);

        MultiChildNode<int>.Connect(pNode1, pNode2);
        MultiChildNode<int>.Connect(pNode2, pNode3);
        MultiChildNode<int>.Connect(pNode3, pNode4);
        MultiChildNode<int>.Connect(pNode4, pNode5);

        Test("P330Test2", pNode1, pNode5, pNode4, pNode3);
    }

    // 树退化成一个链表，一个结点不在树中
    //               1
    //              /
    //             2
    //            /
    //           3
    //          /
    //         4
    //        /
    //       5
    public static void P330Test3()
    {
        MultiChildNode<int> pNode1 = new(1);
        MultiChildNode<int> pNode2 = new(2);
        MultiChildNode<int> pNode3 = new(3);
        MultiChildNode<int> pNode4 = new(4);
        MultiChildNode<int> pNode5 = new(5);

        MultiChildNode<int>.Connect(pNode1, pNode2);
        MultiChildNode<int>.Connect(pNode2, pNode3);
        MultiChildNode<int>.Connect(pNode3, pNode4);
        MultiChildNode<int>.Connect(pNode4, pNode5);

        MultiChildNode<int> pNode6 = new(6);

        Test("P330Test3", pNode1, pNode5, pNode6, null);
    }

    // 输入null
    public static void P330Test4()
    {
        Test("P330Test4", null, null, null, null);
    }

    public static void P330Test()
    {
        P330Test1();
        P330Test2();
        P330Test3();
        P330Test4();
    }
}
