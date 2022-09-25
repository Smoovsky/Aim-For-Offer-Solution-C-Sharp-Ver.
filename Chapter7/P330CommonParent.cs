using System.Collections.Generic;

namespace Algorithm.Chapter7;

public static partial class Solution
{
    public class MultiChildNode<T>
    {
        public T Value { get; set; }

        public ICollection<MultiChildNode<T>> Children { get; set; } = new List<MultiChildNode<T>>();
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

        
    }

    public static ICollection<MultiChildNode<T>> GetPath<T>(
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
