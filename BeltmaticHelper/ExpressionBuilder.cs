using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;
public class ExpressionBuilder
{
    public ExpressionBuilder(int[] availableNumbers, Operator[] availableOperators)
    {
        _availableOperators = availableOperators;

        var availableNumbersExpressions = availableNumbers
            .Select(n => new Number
            {
                Value = n,
            });

        _expressionPerAmountOfOperators.Add(availableNumbersExpressions.ToArray());

        foreach (var availableNumber in availableNumbersExpressions)
        {
            _knownSolutions[availableNumber.Value] = availableNumber;
        }
    }

    public Expression Find(int numberToFind)
    {
        while (true)
        {
            if (_knownSolutions[numberToFind] != null)
            {
                return _knownSolutions[numberToFind];
            }

            var amountOfOperatorsLayerToAdd = _expressionPerAmountOfOperators.Count();
            var nextLayerExpressions = new List<Expression>();

            foreach (var (indexA, indexB) in FindIndexCombinations(amountOfOperatorsLayerToAdd))
                foreach (var operatorToApply in _availableOperators)
                    foreach (var a in _expressionPerAmountOfOperators[indexA])
                        foreach (var b in _expressionPerAmountOfOperators[indexB])
                        {
                            AddIfNew(new Operation
                            {
                                Operator = operatorToApply,
                                A = a,
                                B = b,
                            }, nextLayerExpressions);

                            if (!IsSymmetrical(operatorToApply))
                            {
                                AddIfNew(new Operation
                                {
                                    Operator = operatorToApply,
                                    A = b,
                                    B = a,
                                }, nextLayerExpressions);
                            }
                        }
             
            _expressionPerAmountOfOperators.Add(nextLayerExpressions.ToArray());
        }
    }

    private IEnumerable<(int, int)> FindIndexCombinations(int amountOfOperatorsLayerToAdd)
    {
        for (int  i = 0; i < amountOfOperatorsLayerToAdd; i++)
        {
            for (int j = i; j < amountOfOperatorsLayerToAdd; j++)
            {
                if (i + j + 1 == amountOfOperatorsLayerToAdd)
                {
                    yield return (i, j);
                }
            }
        }
    }

    private void AddIfNew(Expression expression, List<Expression> list)
    {
        if (expression.Result() > 0 &&
            expression.Result() <+ _highestNumber && 
            _knownSolutions[expression.Result()] == null)
        {
            _knownSolutions[expression.Result()] = expression;
            list.Add(expression);
        }
    }

    private bool IsSymmetrical(Operator Operator) => Operator is Operator.Adder or Operator.Multiplier;

    private const int _highestNumber = 10_000_000;

    private readonly Operator[] _availableOperators;
    private List<Expression[]> _expressionPerAmountOfOperators = new();
    private Expression[] _knownSolutions = new Expression[_highestNumber + 1];
}

public class ExpressionQueue : PriorityQueue<Expression, int>
{
    public ExpressionQueue() : base(Comparer<int>.Create((x, y) => x - y))
    { }
}
