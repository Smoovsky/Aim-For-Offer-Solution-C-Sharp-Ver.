namespace Algorithm.Chapter6;

public static partial class Solution
{
    public delegate int Termial(int n);

    public static readonly Termial P307TermialConstrained = (int n) =>
    {
        Termial[] func = new Termial[]
        {
            (n) => 0,
            P307TermialConstrained!
        };

        return n + func[Convert.ToInt32(Convert.ToBoolean(n - 1))](n - 1);
    };
}
