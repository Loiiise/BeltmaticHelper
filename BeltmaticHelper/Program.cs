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
        Console.WriteLine(_helpMessage);
    }

    const string _helpMessage =
@"Welcome to the Beltmatic helper support. BeltmaticHelper by Loiiise can be called as:
- BeltmaticHelper [highest number available] [highest operator available]
e.g. Beltmatic 4 +
This will setup a state where you can generate as many equations as you want.
- BeltmaticHelper [highest number available] [highest operator available] [number you want to find]
e.g. Beltamtic 23 / 236
Will generate one equasion for the specific number you want to find. Will be less efficient if you want to find multiple equasions.

- Available operators representation
Adder: +
Multiplier: *
Subtractor: -
Divider: /
Exponentiator: ^

For the full documentation, please see: https://github.com/Loiiise/BeltmaticHelper/
";
}
