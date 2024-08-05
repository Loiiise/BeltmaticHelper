namespace BeltmaticHelper.DataTypes;

public abstract record Expression 
{
    public abstract int Result();
}

public sealed record Number : Expression
{
    int Value { get; init; }

    public override int Result() => Value;

    public override string ToString() => Value.ToString();
}

public sealed record Operation : Expression
{
    Operator Operator { get; init; }
    Expression A { get; init; }
    Expression B { get; init; }
    
    public override int Result() => Operator switch
    {
        Operator.Adder => A.Result() + B.Result(),
        Operator.Multiplier => A.Result() * B.Result(),
        Operator.Subtractor => A.Result() - B.Result(),
        Operator.Divider => A.Result() / B.Result(),
        Operator.Exponentiator => (int)Math.Pow(A.Result(), B.Result()),
        _ => throw new NotSupportedException(),
    };

    public override string ToString() => $"({A.ToString()} {Operator.ToString()} {B.ToString()})";

    private string OperatorAsString(Operator operatorToStringify) => operatorToStringify switch
    {
        Operator.Adder => "+",
        Operator.Multiplier => "*",
        Operator.Subtractor => "-",
        Operator.Divider => "/",
        Operator.Exponentiator => "^",
        _ => throw new NotSupportedException(),
    };
}