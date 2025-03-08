namespace BeltmaticHelper;

internal class Program
{
    static void Main(string[] args)
    {
        if (!MagicParser.TryParseConfiguration(args, out var configuration))
        {
            PrintHelpMessage();
            return;
        }

        var expressionBuilder = new ExpressionBuilder(
            GameKnowledgeMagicValues.GetNumberExpressionsUpToAndIncluding(configuration.HighestNumber).ToArray(),
            GameKnowledgeMagicValues.GetOperatorsUpToAndIncluding(configuration.HighestOperator).ToArray());

        if (configuration.OnlyNumberToFind != null)
        {
            var result = expressionBuilder.Find((int)configuration.OnlyNumberToFind);
            Console.WriteLine(result.ToString());
            Console.WriteLine("Good luck building the factory!");
            return;
        }

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


    static void PrintHelpMessage()
    {
        throw new NotImplementedException();
    }
}
