using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var expressionBuilder = new ExpressionBuilder(
            new int[] { 1, 2, 3, 4, 5, 6, 8, 7, 9, 11, 12, 13 },
            new Operator[] { Operator.Adder, Operator.Multiplier, Operator.Subtractor, Operator.Divider, Operator.Exponentiator });

        while (true)
        {
            while (int.TryParse(Console.ReadLine(), out var numberToFind))
            {
                var result = expressionBuilder.Find(numberToFind);

                Console.WriteLine(result.ToString());

            }
            Console.WriteLine("That's not a number silly :)");
        }
    }
}
