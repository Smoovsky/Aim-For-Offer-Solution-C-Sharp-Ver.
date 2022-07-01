namespace Algorithm.Chapter3;

public static partial class Solution
{
    public static bool P151HasSubTree<T>(
        TreeNode<T?>? tree1,
        TreeNode<T?>? tree2)
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
        TreeNode<T?>? tree1,
        TreeNode<T?>? tree2)
    {
        if (tree2 == null)
        {
            return true;
        }

        if (tree1 == null)
        {
            return false;
        }

        if (tree1.Value?.Equals(tree2.Value) != true
            && !(tree1.Value == null && tree2.Value == null))
        {
            return false;
        }

        return P151IsSubTree(tree1.Left, tree2.Left)
            && P151IsSubTree(tree1.Right, tree2.Right);
    }

    // ====================测试代码====================
    public static void P151Test(string P151testName, TreeNode<int>? pRoot1, TreeNode<int>? pRoot2, bool expected)
    {
        if (P151HasSubTree(pRoot1, pRoot2) == expected)
            Console.WriteLine($"{P151testName} passed.\n", P151testName);
        else
            Console.WriteLine($"{P151testName} failed.\n");
    }

    // 树中结点含有分叉，树B是树A的子结构
    //                  8                8
    //              /       \           / \
    //             8         7         9   2
    //           /   \
    //          9     2
    //               / \
    //              4   7
    public static void P151Test1()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(7);
        TreeNode<int>? pNodeA4 = new(9);
        TreeNode<int>? pNodeA5 = new(2);
        TreeNode<int>? pNodeA6 = new(4);
        TreeNode<int>? pNodeA7 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, pNodeA2, pNodeA3);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, pNodeA4, pNodeA5);
        TreeNode<int>.ConnectTreeNodes(pNodeA5, pNodeA6, pNodeA7);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, pNodeB2, pNodeB3);

        P151Test("P151Test1", pNodeA1, pNodeB1, true);
    }

    // 树中结点含有分叉，树B不是树A的子结构
    //                  8                8
    //              /       \           / \
    //             8         7         9   2
    //           /   \
    //          9     3
    //               / \
    //              4   7
    public static void P151Test2()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(7);
        TreeNode<int>? pNodeA4 = new(9);
        TreeNode<int>? pNodeA5 = new(3);
        TreeNode<int>? pNodeA6 = new(4);
        TreeNode<int>? pNodeA7 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, pNodeA2, pNodeA3);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, pNodeA4, pNodeA5);
        TreeNode<int>.ConnectTreeNodes(pNodeA5, pNodeA6, pNodeA7);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, pNodeB2, pNodeB3);

        P151Test("P151Test2", pNodeA1, pNodeB1, false);

        
        
    }

    // 树中结点只有左子结点，树B是树A的子结构
    //                8                  8
    //              /                   / 
    //             8                   9   
    //           /                    /
    //          9                    2
    //         /      
    //        2        
    //       /
    //      5
    public static void P151Test3()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(9);
        TreeNode<int>? pNodeA4 = new(2);
        TreeNode<int>? pNodeA5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, pNodeA2, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, pNodeA3, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA3, pNodeA4, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA4, pNodeA5, null);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, pNodeB2, null);
        TreeNode<int>.ConnectTreeNodes(pNodeB2, pNodeB3, null);

        P151Test("P151Test3", pNodeA1, pNodeB1, true);

        
        
    }

    // 树中结点只有左子结点，树B不是树A的子结构
    //                8                  8
    //              /                   / 
    //             8                   9   
    //           /                    /
    //          9                    3
    //         /      
    //        2        
    //       /
    //      5
    public static void P151Test4()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(9);
        TreeNode<int>? pNodeA4 = new(2);
        TreeNode<int>? pNodeA5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, pNodeA2, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, pNodeA3, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA3, pNodeA4, null);
        TreeNode<int>.ConnectTreeNodes(pNodeA4, pNodeA5, null);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(3);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, pNodeB2, null);
        TreeNode<int>.ConnectTreeNodes(pNodeB2, pNodeB3, null);

        P151Test("P151Test4", pNodeA1, pNodeB1, false);

        
        
    }

    // 树中结点只有右子结点，树B是树A的子结构
    //       8                   8
    //        \                   \ 
    //         8                   9   
    //          \                   \
    //           9                   2
    //            \      
    //             2        
    //              \
    //               5
    public static void P151Test5()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(9);
        TreeNode<int>? pNodeA4 = new(2);
        TreeNode<int>? pNodeA5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, null, pNodeA2);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, null, pNodeA3);
        TreeNode<int>.ConnectTreeNodes(pNodeA3, null, pNodeA4);
        TreeNode<int>.ConnectTreeNodes(pNodeA4, null, pNodeA5);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, null, pNodeB2);
        TreeNode<int>.ConnectTreeNodes(pNodeB2, null, pNodeB3);

        P151Test("P151Test5", pNodeA1, pNodeB1, true);

        
        
    }

    // 树A中结点只有右子结点，树B不是树A的子结构
    //       8                   8
    //        \                   \ 
    //         8                   9   
    //          \                 / \
    //           9               3   2
    //            \      
    //             2        
    //              \
    //               5
    public static void P151Test6()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(8);
        TreeNode<int>? pNodeA3 = new(9);
        TreeNode<int>? pNodeA4 = new(2);
        TreeNode<int>? pNodeA5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, null, pNodeA2);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, null, pNodeA3);
        TreeNode<int>.ConnectTreeNodes(pNodeA3, null, pNodeA4);
        TreeNode<int>.ConnectTreeNodes(pNodeA4, null, pNodeA5);

        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(3);
        TreeNode<int>? pNodeB4 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, null, pNodeB2);
        TreeNode<int>.ConnectTreeNodes(pNodeB2, pNodeB3, pNodeB4);

        P151Test("P151Test6", pNodeA1, pNodeB1, false);

        
        
    }

    // 树A为空树
    public static void P151Test7()
    {
        TreeNode<int>? pNodeB1 = new(8);
        TreeNode<int>? pNodeB2 = new(9);
        TreeNode<int>? pNodeB3 = new(3);
        TreeNode<int>? pNodeB4 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeB1, null, pNodeB2);
        TreeNode<int>.ConnectTreeNodes(pNodeB2, pNodeB3, pNodeB4);

        P151Test("P151Test7", null, pNodeB1, false);

        
    }

    // 树B为空树
    public static void P151Test8()
    {
        TreeNode<int>? pNodeA1 = new(8);
        TreeNode<int>? pNodeA2 = new(9);
        TreeNode<int>? pNodeA3 = new(3);
        TreeNode<int>? pNodeA4 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNodeA1, null, pNodeA2);
        TreeNode<int>.ConnectTreeNodes(pNodeA2, pNodeA3, pNodeA4);

        P151Test("P151Test8", pNodeA1, null, false);

        
    }

    // 树A和树B都为空
    public static void P151Test9()
    {
        P151Test("P151Test9", null, null, false);
    }
}