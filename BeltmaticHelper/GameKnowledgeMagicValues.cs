using BeltmaticHelper.DataTypes;
using System.Diagnostics.CodeAnalysis;

namespace BeltmaticHelper;

internal static class GameKnowledgeMagicValues
{
    internal static IEnumerable<Number> GetNumberExpressionsUpToAndIncluding(int number)
        => Enumerable.Range(1, number)
            .Where(n => n != 10) // Number 10 does not exist in the game
            .Select(n => new Number { Value = n });

    internal static IEnumerable<Operator> GetOperatorsUpToAndIncluding(Operator @operator) => @operator switch
    {
        Operator.Adder => new[] { Operator.Adder },
        Operator.Multiplier => new[] { Operator.Adder, Operator.Multiplier },
        Operator.Subtractor => new[] { Operator.Adder, Operator.Multiplier, Operator.Subtractor },
        Operator.Divider => new[] { Operator.Adder, Operator.Multiplier, Operator.Subtractor, Operator.Divider },
        Operator.Exponentiator => new[] { Operator.Adder, Operator.Multiplier, Operator.Subtractor, Operator.Divider, Operator.Exponentiator },
        _ => throw new NotImplementedException(),
    };

    internal static bool IsSymmetrical(this Operator @operator) => @operator is Operator.Adder or Operator.Multiplier;

    internal static bool TryGetOperatorFromDisplayString(string operatorString, [MaybeNullWhen(false), NotNullWhen(true)] out Operator? @operator)
    {
        @operator = operatorString switch
        {
            "+" => Operator.Adder,
            "*" => Operator.Multiplier,
            "-" => Operator.Subtractor,
            "/" => Operator.Divider,
            "^" => Operator.Exponentiator,
            _ => null,
        };

        return @operator != null;
    }

    internal static string ToDisplayString(this Operator @operator) => @operator switch
    {
        Operator.Adder => "+",
        Operator.Multiplier => "*",
        Operator.Subtractor => "-",
        Operator.Divider => "/",
        Operator.Exponentiator => "^",
        _ => throw new NotImplementedException(),
    };
}
