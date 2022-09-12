namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P300JosephuseBrutal(int count, int seqToDel)
    {
        if (count < 1 || seqToDel < 1)
        {
            return -1;
        }

        var head = LinkedListNode<int>.Create(0);
        var current = head;

        for (var i = 1; i < count; i++)
        {
            current.Next = LinkedListNode<int>.Create(i);
            current = current!.Next;
        }

        current.Next = head;
        current = head;
        while (count > 1)
        {
            var prev = current;

            for (var i = 1; i < seqToDel; i++)
            {
                prev = current;
                current = current!.Next;
            }

            prev!.Next = current!.Next;
            current = current!.Next;
            count--;
        }

        return current!.Value;
    }

    public static int P300JosephuseAlgebra(int count, int seqToDel)
    {
        if (count < 1 || seqToDel < 1)
        {
            return -1;
        }

        var last = 0;

        for (var i = 2; i <= count; i++)
        {
            last = (last + seqToDel) % i;
        }

        return last;
    }
}
