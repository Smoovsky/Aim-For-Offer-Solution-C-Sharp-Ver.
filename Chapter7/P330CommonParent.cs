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
}
