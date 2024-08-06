using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var expressionBuilder = new ExpressionBuilder(new int[] { 1, 2, 3, 4,5,6,8,7,9 }, new Operator[] { Operator.Adder, Operator.Multiplier });

        var result = expressionBuilder.Find(35805);

        Console.WriteLine(result.ToString());
        Console.ReadLine();
    }
}
