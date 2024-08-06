using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var expressionBuilder = new ExpressionBuilder();

        var result = expressionBuilder.Find(57, new int[] { 1, 2, 3, 4 }, new Operator[] { Operator.Adder, Operator.Multiplier });

        Console.WriteLine(result.ToString());
        Console.ReadLine();
    }
}
