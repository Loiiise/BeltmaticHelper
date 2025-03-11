namespace BeltmaticHelper.DataTypes;

public abstract record Expression
{
    public abstract int Result();
}

public sealed record Number : Expression
{
    public int Value { get; init; }

    public override int Result() => Value;

    public override string ToString() => Value.ToString();
}

public sealed record Operation : Expression
{
    public required Operator Operator { get; init; }
    public required Expression A { get; init; }
    public required Expression B { get; init; }

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

    public override string ToString() => $"({A.ToString()} {Operator.ToDisplayString()} {B.ToString()})";

    private int? _result;
}