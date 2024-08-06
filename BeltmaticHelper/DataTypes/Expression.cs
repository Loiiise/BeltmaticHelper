namespace BeltmaticHelper.DataTypes;

public abstract record Expression
{
    public abstract int Result();
    public abstract int AmountOfOperators { get; }
}

public sealed record Number : Expression
{
    public int Value { get; init; }
    public override int AmountOfOperators => 0;

    public override int Result() => Value;

    public override string ToString() => Value.ToString();
}

public sealed record Operation : Expression
{
    public override int AmountOfOperators => A.AmountOfOperators + B.AmountOfOperators + 1;
    public Operator Operator { get; init; }
    public Expression A { get; init; }
    public Expression B { get; init; }

    public override int Result()
    {
        _result = _result ?? Operator switch
        {
            Operator.Adder => A.Result() + B.Result(),
            Operator.Multiplier => A.Result() * B.Result(),
            Operator.Subtractor => A.Result() - B.Result(),
            Operator.Divider => A.Result() / B.Result(),
            Operator.Exponentiator => (int)Math.Pow(A.Result(), B.Result()),
            _ => throw new NotSupportedException(),
        };

        return (int)_result;
    }

    public override string ToString() => $"({A.ToString()} {OperatorAsString(Operator)} {B.ToString()})";

    private string OperatorAsString(Operator operatorToStringify) => operatorToStringify switch
    {
        Operator.Adder => "+",
        Operator.Multiplier => "*",
        Operator.Subtractor => "-",
        Operator.Divider => "/",
        Operator.Exponentiator => "^",
        _ => throw new NotSupportedException(),
    };

    private int? _result;
}