namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static void ReversePrintLinkedListStackP58<T>(LinkedList<T> linkedList)
        {
            if (linkedList == null)
            {
                return;
            }

            var stack = new Stack<T>();

            var enumerator = linkedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                stack.Push(enumerator.Current);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        public static void ReversePrintLinkedListRecursiveP58<T>(
            LinkedList<T> linkedList)
        {
            if (linkedList == null)
            {
                return;
            }

            var enume = linkedList.GetEnumerator();

            if (enume.MoveNext())
            {
                ReversePrintLinkedListRecursiveP58(enume);
            }
        }

        public static void ReversePrintLinkedListRecursiveP58<T>(
            IEnumerator<T> linkedList)
        {
            if (linkedList == null)
            {
                return;
            }

            var current = linkedList.Current;

            if (linkedList.MoveNext())
            {
                ReversePrintLinkedListRecursiveP58(linkedList);
            }

            Console.WriteLine(current);
        }
    }

    // public class LinkedList
    // { 
    //     public string Value { get; set; }

    //     public LinkedList Next { get; set; }
    // }
}