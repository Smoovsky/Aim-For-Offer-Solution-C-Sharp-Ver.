namespace Chapter4;

public static partial class Solution
{
    public static bool P160IsTreeSymmetric<T>(TreeNode<T>? root)
    {

    }

    public static bool P160IsTreeSymmetricCore<T>(
        TreeNode<T>? tree1,
        TreeNode<T>? tree2)
    {
        if (tree1 == null && tree2 == null)
        {
            return true;
        }

        if (tree1 == null || tree2 == null)
        {
            return false;
        }

        if (tree1.Value?.Equals(tree2.Value) != true
            || (tree1.Value == null && tree2.Value != null)
            || (tree1.Value != null && tree2.Value == null))
        {
            return false;
        }

        return P160IsTreeSymmetricCore(tree1.Left, tree2.Right)
            && P160IsTreeSymmetricCore(tree1.Right, tree2.Left);
    }
}
