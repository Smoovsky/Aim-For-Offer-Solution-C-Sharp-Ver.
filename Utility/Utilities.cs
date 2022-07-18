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

        public TreeNode<T?>? Parent { get; set; }

        public TreeNode<T?>? Left { get; set; }

        public TreeNode<T?>? Right { get; set; }

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

        public static void ConnectTreeNodes<K>(
            TreeNode<K?> pParent,
            TreeNode<K?> pLeft,
            TreeNode<K?> pRight)
        {
            if (pParent == null)
            {
                return;
            }

            pParent.Left = pLeft;
            pParent.Right = pRight;

            if (pLeft != null)
                pLeft.Parent = pParent;

            if (pRight != null)
                pRight.Parent = pParent;
        }

        public static void LeftRotate<K>(TreeNode<K?>? pNode)
        {
            var c = pNode?.Right;

            if (c == null)
            {
                throw new ArgumentException("Invalid Node.");
            }

            var cl = c?.Left;

            if (cl != null)
            {
                cl.Parent = pNode;
                pNode!.Right = cl;
            }

            var pP = pNode!.Parent;

            if (pP != null)
            {
                if (pP.Left == pNode)
                {
                    pP.Left = c;
                }
                else
                {
                    pP.Right = c;
                }

                c!.Parent = pP;
            }

            c!.Left = pNode;
            pNode.Parent = c;
        }

        public static void RightRotate<K>(TreeNode<K?>? pNode)
        {
            var c = pNode?.Left;

            if (c == null)
            {
                throw new ArgumentException("Invalid Node.");
            }

            var cr = c?.Right;

            if (cr != null)
            {
                cr.Parent = pNode;
                pNode!.Left = cr;
            }

            var pP = pNode!.Parent;

            if (pP != null)
            {
                if (pP.Left == pNode)
                {
                    pP.Left = c;
                }
                else
                {
                    pP.Right = c;
                }

                c!.Parent = pP;
            }

            c!.Right = pNode;
            pNode.Parent = c;
        }

        public static void LeftRightRotate<K>(TreeNode<K?>? pNode)
        {
            LeftRotate(pNode?.Left);
            RightRotate(pNode);
        }

        public static void RightLeftRotate<K>(TreeNode<K?>? pNode)
        {
            RightRotate(pNode?.Right);
            LeftRotate(pNode);
        }
    }

    public class RBTreeNode<T> : TreeNode<T>
        where T : IComparable
    {
        public enum RBTreeNodeColor
        {
            Red = 1,
            Black = 2
        }

        public RBTreeNodeColor Color { get; set; }

        public static void Insert(ref RBTreeNode<T>? root, T valueToInsert)
        {
            var nodeToInsert = new RBTreeNode<T>
            {
                Value = valueToInsert,
                Color = RBTreeNodeColor.Red
            };

            if (root == null)
            {
                root = nodeToInsert;
                root.Color = RBTreeNodeColor.Black;

                return;
            }

            var current = root as TreeNode<T?>;
            var next = current.Value!.CompareTo(valueToInsert) > 0
                ? root.Left
                : root.Right;

            while (next != null)
            {
                current = next;
                next = current.Value!.CompareTo(valueToInsert) > 0
                    ? current.Left
                    : current.Right;
            }

            _ = current.Value!.CompareTo(valueToInsert) > 0
                ? current.Left = nodeToInsert!
                : current.Right = nodeToInsert!;
            nodeToInsert.Parent = current;

            FixInsertion(nodeToInsert);
        }

        public static void FixInsertion(RBTreeNode<T> insertedNode)
        {
            if (insertedNode?.Parent?.Parent == null)
            {
                return;
            }

            var p = insertedNode.Parent! as RBTreeNode<T>;
            var g = p!.Parent as RBTreeNode<T>;

            var u = (g!.Left == p
                ? g.Right
                : g.Left) as RBTreeNode<T>;

            var uC = u?.Color ?? RBTreeNodeColor.Black;

            if (p.Color == RBTreeNodeColor.Black)
            {
                return;
            }
            else
            {
                if (uC == RBTreeNodeColor.Red)
                {
                    while (g != null)
                    {
                        u!.Color = RBTreeNodeColor.Black;
                        p!.Color = RBTreeNodeColor.Black;
                        g.Color = RBTreeNodeColor.Red;

                        p = g.Parent as RBTreeNode<T>;
                        g = p?.Parent as RBTreeNode<T>;

                        if (g != null)
                        {
                            u = (g!.Left == p
                                ? g.Right
                                : g.Left) as RBTreeNode<T>;
                        }
                    }
                }
                else
                {
                    if (g.Left == p && p.Left == insertedNode)
                    {
                        RightRotate(g!);

                        (p.Color, g.Color) = (g.Color, p.Color);
                    }

                    if (g.Left == p && p.Right == insertedNode)
                    {
                        LeftRotate(p!);
                        RightRotate(insertedNode!);

                        (insertedNode.Color, g.Color) = (g.Color, insertedNode.Color);
                    }

                    if (g.Right == p && p.Right == insertedNode)
                    {
                        RightRotate(g!);

                        (p.Color, g.Color) = (g.Color, p.Color);
                    }

                    if (g.Right == p && p.Left == insertedNode)
                    {
                        RightRotate(p!);
                        LeftRotate(insertedNode!);

                        (insertedNode.Color, g.Color) = (g.Color, insertedNode.Color);
                    }
                }
            }
        }
    }

    public static void Swap<T>(
        ref T char1,
        ref T char2) => (char1, char2) = (char2, char1);

    public static int Partition(
        int[] source,
        int? start = null,
        int? end = null)
    {
        start ??= 0;
        end ??= source.Length - 1;

        var index = new Random().Next(start.Value, end.Value);

        Swap(ref source[index], ref source[end.Value]);

        var small = start.Value - 1;

        for (index = start.Value; index < end; index++)
        {
            if (source[index] < source[end.Value])
            {
                small++;

                if (small != index)
                {
                    Swap(ref source[small], ref source[index]);
                }
            }
        }

        Swap(ref source[++small], ref source[end.Value]);

        return small;
    }
}
