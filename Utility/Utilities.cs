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

    public class TreeNode<T> where T : struct
    {
        public TreeNode()
        {

        }

        public TreeNode(T value) => Value = value;

        public T Value { get; set; }

        public TreeNode<T>? Parent { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }

        public static readonly int COUNT = 10;

        public static void Print2DUtil(TreeNode<T>? root, int space)
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
        public static void Print2D(TreeNode<T>? root)
        {
            // Pass initial space count as 0
            Print2DUtil(root, 0);
        }

        public static void ConnectTreeNodes(
            TreeNode<T> pParent,
            TreeNode<T> pLeft,
            TreeNode<T> pRight)
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

        public static void LeftRotate(TreeNode<T>? pNode)
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
            }

            pNode!.Right = cl;

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
            }

            c!.Parent = pP;

            c!.Left = pNode;
            pNode.Parent = c;
        }

        public static void RightRotate(TreeNode<T>? pNode)
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
            }

            pNode!.Left = cr;

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
            }

            c!.Parent = pP;

            c!.Right = pNode;
            pNode.Parent = c;
        }

        public static void LeftRightRotate(TreeNode<T>? pNode)
        {
            LeftRotate(pNode?.Left);
            RightRotate(pNode);
        }

        public static void RightLeftRotate(TreeNode<T>? pNode)
        {
            RightRotate(pNode?.Right);
            LeftRotate(pNode);
        }

        public static TreeNode<T> FindMinimum(TreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }

    public class RBTreeNode<T> : TreeNode<T>
        where T : struct, IComparable
    {
        public enum RBTreeNodeColor
        {
            Red = 1,
            Black = 2
        }

        public virtual RBTreeNodeColor Color { get; set; }

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

            var current = root as TreeNode<T>;
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

            while (root!.Parent != null)
            {
                root = root.Parent as RBTreeNode<T>;
            }

            if (root.Color == RBTreeNodeColor.Red)
            {
                root.Color = RBTreeNodeColor.Black;
            }
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
                    u!.Color = RBTreeNodeColor.Black;
                    p!.Color = RBTreeNodeColor.Black;
                    g.Color = RBTreeNodeColor.Red;

                    FixInsertion(g);
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
                        RightRotate(insertedNode.Parent);

                        (insertedNode.Color, g.Color) = (g.Color, insertedNode.Color);
                    }

                    if (g.Right == p && p.Right == insertedNode)
                    {
                        LeftRotate(g!);

                        (p.Color, g.Color) = (g.Color, p.Color);
                    }

                    if (g.Right == p && p.Left == insertedNode)
                    {
                        RightRotate(p!);
                        LeftRotate(insertedNode.Parent);

                        (insertedNode.Color, g.Color) = (g.Color, insertedNode.Color);
                    }
                }
            }
        }

        public static void Delete(ref RBTreeNode<T>? root, T val)
        {
            var node = root;

            while (node != null && node.Value.CompareTo(val) != 0)
            {
                if (node.Value.CompareTo(val) < 0)
                {
                    node = node.Right as RBTreeNode<T>;
                }
                else
                {
                    node = node.Left as RBTreeNode<T>;
                }
            }

            if (node == null)
            {
                return;
            }

            RBTreeNode<T> movedUpNode;
            RBTreeNodeColor deletedNodeColor;

            // Node has zero or one child
            if (node.Left == null || node.Right == null)
            {
                movedUpNode = DeleteNodeWith0or1Child(ref root, node);
                deletedNodeColor = movedUpNode.Color;
            }
            // Node has two children
            else
            {
                // Find minimum node of right subtree ("inorder successor" of current node)
                var inOrderSuccessor = FindMinimum(node.Right);

                // Copy inorder successor's data to current node (keep its color!)
                node.Value = inOrderSuccessor.Value;

                // Delete inorder successor just as we would delete a node with 0 or 1 child
                movedUpNode = DeleteNodeWith0or1Child(ref root, (inOrderSuccessor as RBTreeNode<T>)!);
                deletedNodeColor = (inOrderSuccessor as RBTreeNode<T>)!.Color;
            }

            if (deletedNodeColor == RBTreeNodeColor.Black)
            {
                FixRedBlackPropertiesAfterDelete(movedUpNode);

                // Remove the temporary NIL node
                if (movedUpNode is NilNode<T>)
                {
                    ReplaceParentsChild(ref root, movedUpNode.Parent as RBTreeNode<T>, movedUpNode, null);
                }
            }

            while (root?.Parent != null)
            {
                root = root.Parent as RBTreeNode<T>;
            }
        }

        private static void FixRedBlackPropertiesAfterDelete(RBTreeNode<T> node)
        {
            var parent = node.Parent;

            // Case 1: Parent is null, we've reached the root, the end of the recursion
            if (parent == null)
            {
                // Uncomment the following line if you want to enforce black roots (rule 2):
                node.Color = RBTreeNodeColor.Black;
                return;
            }

            
        }

        private class NilNode<K> : RBTreeNode<K>
            where K : struct, IComparable
        {
            public override RBTreeNodeColor Color { get { return RBTreeNodeColor.Black; } set { } }
        }


        private static RBTreeNode<T> DeleteNodeWith0or1Child(ref RBTreeNode<T>? root, RBTreeNode<T> node)
        {
            // Node has ONLY a left child --> replace by its left child
            if (node.Left != null)
            {
                ReplaceParentsChild(ref root, node.Parent as RBTreeNode<T>, node, node.Left as RBTreeNode<T>);
                return (node.Left as RBTreeNode<T>)!; // moved-up node
            }

            // Node has ONLY a right child --> replace by its right child
            else if (node.Right != null)
            {
                ReplaceParentsChild(ref root, node.Parent as RBTreeNode<T>, node, node.Right as RBTreeNode<T>);
                return (node.Right as RBTreeNode<T>)!; // moved-up node
            }

            // Node has no children -->
            // * node is red --> just remove it
            // * node is black --> replace it by a temporary NIL node (needed to fix the R-B rules)
            else
            {
                var newChild = node.Color == RBTreeNodeColor.Black ? new NilNode<T>() : null;

                ReplaceParentsChild(ref root, node.Parent as RBTreeNode<T>, node, newChild);

                return newChild!;
            }
        }

        private static void ReplaceParentsChild(ref RBTreeNode<T>? root, RBTreeNode<T>? parent, RBTreeNode<T>? oldChild, RBTreeNode<T>? newChild)
        {
            if (parent == null)
            {
                root = newChild;
            }
            else if (parent.Left == oldChild)
            {
                parent.Left = newChild;
            }
            else if (parent.Right == oldChild)
            {
                parent.Right = newChild;
            }
            else
            {
                throw new ArgumentException("Node is not a child of its parent");
            }

            if (newChild != null)
            {
                newChild.Parent = parent;
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
