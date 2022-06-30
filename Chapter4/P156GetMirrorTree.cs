namespace Chapter4;

public static partial class Solution
{
    public static void P156GetMirrorTree<T>(TreeNode<T>? root)
    { 
        if(root == null)
        {
            return;
        }

        (root.Left, root.Right) = (root.Right, root.Left);

        P156GetMirrorTree(root.Left);
        P156GetMirrorTree(root.Right);
    }
}
