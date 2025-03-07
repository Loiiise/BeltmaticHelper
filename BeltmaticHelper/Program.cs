using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;

internal class Program
{
    static void Main(string[] args)
    {
        var expressionBuilder = new ExpressionBuilder(
            GameKnowledgeMagicValues.GetNumberExpressionsUpToAndIncluding(13).ToArray(),
            GameKnowledgeMagicValues.GetOperatorsUpToAndIncluding(Operator.Exponentiator).ToArray());

        while (true)
        {
            Console.WriteLine("What number would you like to find an expression for?");
            if (int.TryParse(Console.ReadLine(), out var numberToFind))
            {
                Console.WriteLine($"Finding an expression for {numberToFind}...");

                var result = expressionBuilder.Find(numberToFind);

                Console.WriteLine(result.ToString());
                Console.WriteLine("Good luck building the factory!");
            }
            else
            {
                Console.WriteLine("That's not a number silly :)");
            }
        }
    }
}
