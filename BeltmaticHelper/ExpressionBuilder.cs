using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;

public class ExpressionBuilder
{
    public ExpressionBuilder(Number[] availableNumbers, Operator[] availableOperators)
    {
        _availableOperators = availableOperators;
        _expressionPerAmountOfOperators.Add(availableNumbers);

        foreach (var availableNumber in availableNumbers)
        {
            _knownSolutions[availableNumber.Value] = availableNumber;
        }
    }

    public Expression Find(int numberToFind)
    {
        while (_knownSolutions[numberToFind] == null)
        {
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

                            if (!operatorToApply.IsSymmetrical())
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

        return _knownSolutions[numberToFind];
    }

    private IEnumerable<(int, int)> FindIndexCombinations(int amountOfOperatorsLayerToAdd)
    {
        for (int i = 0; i < amountOfOperatorsLayerToAdd; i++)
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
            expression.Result() <= _highestNumber &&
            _knownSolutions[expression.Result()] == null)
        {
            _knownSolutions[expression.Result()] = expression;
            list.Add(expression);
        }
    }

    // todo #7: this number could be dynamic 
    private const int _highestNumber = 10_000_000;

    private readonly Operator[] _availableOperators;
    private List<Expression[]> _expressionPerAmountOfOperators = new();
    private Expression[] _knownSolutions = new Expression[_highestNumber + 1];
}
