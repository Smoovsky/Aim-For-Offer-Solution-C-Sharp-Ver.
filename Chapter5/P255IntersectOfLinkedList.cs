namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static LinkedListNode<T> P255CountInversePairs<T>(
        LinkedListNode<T> root1,
        LinkedListNode<T> root2)
    {
        if (root1 == null || root2 == null)
        {
            return null;
        }

        var count1 = 1;
        LinkedListNode<T> cursor1 = root1.Next;

        while (cursor1 != null)
        {
            cursor1 = cursor1.Next;
            count1++;
        }

        var count2 = 1;
        LinkedListNode<T> cursor2 = root2.Next;

        while (cursor2 != null)
        {
            cursor2 = cursor2.Next;
            count2++;
        }

        var lengthDiff = Math.Abs(count1 - count2);

        var longerList = count1 > count2 ? root1 : root2;
        var shorterList = count1 > count2 ? root2 : root1;

        cursor1 = longerList;
        cursor2 = shorterList;

        while (lengthDiff > 0)
        {
            cursor1 = cursor1!.Next;
            lengthDiff--;
        }

        if (cursor1 == cursor2)
        {
            return cursor1;
        }

        while (cursor1!.Next != null)
        {
            if (cursor1 == cursor2)
            {
                return cursor1;
            }

            cursor1 = cursor1.Next;
            cursor2 = cursor2!.Next;
        }

        return null;
    }


    // 第一个公共结点在链表中间
    // 1 - 2 - 3 \
    //            6 - 7
    //     4 - 5 /
    public static void P255Test1()
    {
        var pNode1 = LinkedListNode<int>.Create(1);
        var pNode2 = LinkedListNode<int>.Create(2);
        var pNode3 = LinkedListNode<int>.Create(3);
        var pNode4 = LinkedListNode<int>.Create(4);
        var pNode5 = LinkedListNode<int>.Create(5);
        var pNode6 = LinkedListNode<int>.Create(6);
        var pNode7 = LinkedListNode<int>.Create(7);

        LinkedListNode<int>.Connect(pNode1, pNode2);
        LinkedListNode<int>.Connect(pNode2, pNode3);
        LinkedListNode<int>.Connect(pNode3, pNode6);
        LinkedListNode<int>.Connect(pNode4, pNode5);
        LinkedListNode<int>.Connect(pNode5, pNode6);
        LinkedListNode<int>.Connect(pNode6, pNode7);

        P255Test("Test1", pNode1, pNode4, pNode6);








    }

    // 没有公共结点
    // 1 - 2 - 3 - 4
    //            
    // 5 - 6 - 7
    public static void P255Test2()
    {
        var pNode1 = LinkedListNode<int>.Create(1);
        var pNode2 = LinkedListNode<int>.Create(2);
        var pNode3 = LinkedListNode<int>.Create(3);
        var pNode4 = LinkedListNode<int>.Create(4);
        var pNode5 = LinkedListNode<int>.Create(5);
        var pNode6 = LinkedListNode<int>.Create(6);
        var pNode7 = LinkedListNode<int>.Create(7);

        LinkedListNode<int>.Connect(pNode1, pNode2);
        LinkedListNode<int>.Connect(pNode2, pNode3);
        LinkedListNode<int>.Connect(pNode3, pNode4);
        LinkedListNode<int>.Connect(pNode5, pNode6);
        LinkedListNode<int>.Connect(pNode6, pNode7);

        P255Test("Test2", pNode1, pNode5, null);



    }

    // 公共结点是最后一个结点
    // 1 - 2 - 3 - 4 \
    //                7
    //         5 - 6 /
    public static void P255Test3()
    {
        var pNode1 = LinkedListNode<int>.Create(1);
        var pNode2 = LinkedListNode<int>.Create(2);
        var pNode3 = LinkedListNode<int>.Create(3);
        var pNode4 = LinkedListNode<int>.Create(4);
        var pNode5 = LinkedListNode<int>.Create(5);
        var pNode6 = LinkedListNode<int>.Create(6);
        var pNode7 = LinkedListNode<int>.Create(7);

        LinkedListNode<int>.Connect(pNode1, pNode2);
        LinkedListNode<int>.Connect(pNode2, pNode3);
        LinkedListNode<int>.Connect(pNode3, pNode4);
        LinkedListNode<int>.Connect(pNode4, pNode7);
        LinkedListNode<int>.Connect(pNode5, pNode6);
        LinkedListNode<int>.Connect(pNode6, pNode7);

        P255Test("Test3", pNode1, pNode5, pNode7);








    }

    // 公共结点是第一个结点
    // 1 - 2 - 3 - 4 - 5
    // 两个链表完全重合   
    public static void P255Test4()
    {
        var pNode1 = LinkedListNode<int>.Create(1);
        var pNode2 = LinkedListNode<int>.Create(2);
        var pNode3 = LinkedListNode<int>.Create(3);
        var pNode4 = LinkedListNode<int>.Create(4);
        var pNode5 = LinkedListNode<int>.Create(5);

        LinkedListNode<int>.Connect(pNode1, pNode2);
        LinkedListNode<int>.Connect(pNode2, pNode3);
        LinkedListNode<int>.Connect(pNode3, pNode4);
        LinkedListNode<int>.Connect(pNode4, pNode5);

        P255Test("Test4", pNode1, pNode1, pNode1);


    }

    // 输入的两个链表有一个空链表
    public static void P255Test5()
    {
        var pNode1 = LinkedListNode<int>.Create(1);
        var pNode2 = LinkedListNode<int>.Create(2);
        var pNode3 = LinkedListNode<int>.Create(3);
        var pNode4 = LinkedListNode<int>.Create(4);
        var pNode5 = LinkedListNode<int>.Create(5);

        LinkedListNode<int>.Connect(pNode1, pNode2);
        LinkedListNode<int>.Connect(pNode2, pNode3);
        LinkedListNode<int>.Connect(pNode3, pNode4);
        LinkedListNode<int>.Connect(pNode4, pNode5);

        P255Test("Test5", null, pNode1, null);


    }

    // 输入的两个链表有一个空链表
    public static void P255Test6()
    {
        P255Test("Test6", null, null, null);
    }

    public static void P255Test(string testName, LinkedListNode<int> pHead1, LinkedListNode<int> pHead2, LinkedListNode<int> pExpected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        var pResult = P255CountInversePairs(pHead1, pHead2);

        if (pResult == pExpected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    public static void P255Test()
    {
        P255Test1();
        P255Test2();
        P255Test3();
        P255Test4();
        P255Test5();
        P255Test6();
    }
}
