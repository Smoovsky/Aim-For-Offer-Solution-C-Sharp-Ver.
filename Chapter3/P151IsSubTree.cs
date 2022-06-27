namespace Algorithm.Chapter3;

public static partial class Solution
{
    public static bool P151HasSubTree<T>(
        TreeNode<T>? tree1,
        TreeNode<T>? tree2)
    where T : IComparable
    {
        if (tree1 == null || tree2 == null)
        {
            return false;
        }

        if (P151IsSubTree(tree1, tree2))
        {
            return true;
        }
        else
        {
            return P151HasSubTree(tree1.Left, tree2)
                || P151HasSubTree(tree1.Right, tree2);
        }
    }

    public static bool P151IsSubTree<T>(
        TreeNode<T>? tree1,
        TreeNode<T>? tree2)
    {
        if (tree1 == null)
        {
            return false;
        }

        if (tree2 == null)
        {
            return true;
        }

        if (tree1.Value?.Equals(tree2.Value) != true
            && !(tree1.Value == null && tree2.Value == null))
        {
            return false;
        }

        return P151IsSubTree(tree1.Left, tree2.Left) 
            && P151IsSubTree(tree1.Right, tree2.Right);
    }
}