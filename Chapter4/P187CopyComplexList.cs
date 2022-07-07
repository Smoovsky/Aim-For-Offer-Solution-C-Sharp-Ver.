namespace Algorithm.Chapter4;

public static partial class Solution
{
    public class ComplexListNode
    {
        public int Value { get; set; }

        public ComplexListNode Next { get; set; }

        public ComplexListNode Other { get; set; }

        public ComplexListNode(int val) => Value = val;

        public ComplexListNode() { }

        public ComplexListNode Copy() => new()
        {
            Value = Value,
            Next = Next,
            Other = Other
        };

        public static void PrintList(ComplexListNode pHead)
        {
            ComplexListNode pNode = pHead;

            while (pNode != null)
            {
                Console.Write($"The value of this node is: {pNode.Value}.\n");

                if (pNode.Other != null)
                    Console.Write($"The value of its sibling is: {pNode.Other.Value}.\n");
                else
                    Console.Write("This node does not have a sibling.\n");

                Console.Write("\n");

                pNode = pNode.Next;
            }
        }

        public static void BuildNodes(
            ComplexListNode pNode,
            ComplexListNode pNext,
            ComplexListNode pSibling)
        {
            if (pNode != null)
            {
                pNode.Next = pNext;
                pNode.Other = pSibling;
            }
        }
    }

    public static ComplexListNode P187CopyComplexList(
        ComplexListNode source)
    {
        if (source == null)
        {
            return null;
        }

        var current = source;

        while (current != null)
        {
            var temp = current.Next;

            current.Next = current.Copy();
            current.Next.Next = temp;

            current = temp;
        }

        current = source;
        int i = 0;

        while (current != null)
        {
            if ((i & 1) == 1
                && current.Other != null)
            {
                current.Other = current.Other.Next;
            }

            current = current.Next;

            i++;
        }

        var original = source;
        var result = source.Next;

        var originalIteration = original;
        var resultIteration = result;

        current = source;
        i = 0;

        while (current != null)
        {
            if (i > 1)
            {
                if ((i & 1) == 0)
                {
                    originalIteration.Next = current;
                    originalIteration = originalIteration.Next;
                }
                else
                {
                    resultIteration.Next = current;
                    resultIteration = resultIteration.Next;
                }
            }

            current = current.Next;
            i++;
        }

        return result;
    }

    //          -----------------
    //         \|/              |
    //  1-------2-------3-------4-------5
    //  |       |      /|\             /|\
    //  --------+--------               |
    //          -------------------------
    public static void P187Test1()
    {
        ComplexListNode pNode1 = new(1);
        ComplexListNode pNode2 = new(2);
        ComplexListNode pNode3 = new(3);
        ComplexListNode pNode4 = new(4);
        ComplexListNode pNode5 = new(5);

        ComplexListNode.BuildNodes(pNode1, pNode2, pNode3);
        ComplexListNode.BuildNodes(pNode2, pNode3, pNode5);
        ComplexListNode.BuildNodes(pNode3, pNode4, null);
        ComplexListNode.BuildNodes(pNode4, pNode5, pNode2);

        P187Test("P187Test1", pNode1);
    }

    // m_pSibling指向结点自身
    //          -----------------
    //         \|/              |
    //  1-------2-------3-------4-------5
    //         |       | /|\           /|\
    //         |       | --             |
    //         |------------------------|
    public static void P187Test2()
    {
        ComplexListNode pNode1 = new(1);
        ComplexListNode pNode2 = new(2);
        ComplexListNode pNode3 = new(3);
        ComplexListNode pNode4 = new(4);
        ComplexListNode pNode5 = new(5);

        ComplexListNode.BuildNodes(pNode1, pNode2, null);
        ComplexListNode.BuildNodes(pNode2, pNode3, pNode5);
        ComplexListNode.BuildNodes(pNode3, pNode4, pNode3);
        ComplexListNode.BuildNodes(pNode4, pNode5, pNode2);

        P187Test("P187Test2", pNode1);
    }

    // m_pSibling形成环
    //          -----------------
    //         \|/              |
    //  1-------2-------3-------4-------5
    //          |              /|\
    //          |               |
    //          |---------------|
    public static void P187Test3()
    {
        ComplexListNode pNode1 = new(1);
        ComplexListNode pNode2 = new(2);
        ComplexListNode pNode3 = new(3);
        ComplexListNode pNode4 = new(4);
        ComplexListNode pNode5 = new(5);

        ComplexListNode.BuildNodes(pNode1, pNode2, null);
        ComplexListNode.BuildNodes(pNode2, pNode3, pNode4);
        ComplexListNode.BuildNodes(pNode3, pNode4, null);
        ComplexListNode.BuildNodes(pNode4, pNode5, pNode2);

        P187Test("P187Test3", pNode1);
    }

    // 只有一个结点
    public static void P187Test4()
    {
        ComplexListNode pNode1 = new(1);
        ComplexListNode.BuildNodes(pNode1, null, pNode1);

        P187Test("P187Test4", pNode1);
    }

    // 鲁棒性测试
    public static void P187Test5()
    {
        P187Test("P187Test5", null);
    }

    public static void P187Test(string testName, ComplexListNode pHead)
    {
        if (testName != null)
            Console.Write($"{testName} begins:\n");

        Console.Write("The original list is:\n");
        ComplexListNode.PrintList(pHead);

        ComplexListNode pClonedHead = P187CopyComplexList(pHead);

        Console.Write("The cloned list is:\n");
        ComplexListNode.PrintList(pClonedHead);
    }
}
