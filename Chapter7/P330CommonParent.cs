using System.Collections.Generic;

namespace Algorithm.Chapter7;

public static partial class Solution
{
    public class MultiChildNode<T>
    {
        public T Value { get; set; }

        public ICollection<T> Children { get; set; } = new List<T>();
    }

    // public static int? P330CommonParent(string source)
    // {
        
    // }
}
