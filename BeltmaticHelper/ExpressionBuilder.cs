using BeltmaticHelper.DataTypes;
using System.Diagnostics;

namespace BeltmaticHelper;
public class ExpressionBuilder
{
    public Expression Find(int numberToFind, int[] availableNumbers, Operator[] availableOperators)
    {
        _availableOperators = availableOperators;
        for (int i = 0; i < availableNumbers.Length; ++i)
        {
            var newNumber = new Number
            {
                Value = availableNumbers[i],

            };
            _expressionQueue.Enqueue(newNumber, 0);
            _seenNumbers[availableNumbers[i]] = true;
            _availableExpressions.Add(newNumber);
        }


        /*
        int previousAmountOfSteps = 0;

        while (true)
        {
            var item = _expressionQueue.Dequeue();

            if (item.Result() == numberToFind)
            {
                return item;
            }

            var nextSteps = GenerateSuccessors(item).ToArray();
            
            Debug.Assert(item.AmountOfOperators == previousAmountOfSteps ||
                item.AmountOfOperators == previousAmountOfSteps + 1);

            foreach (var nextStep in nextSteps)
            {

                //Debug.Assert(nextStep.AmountOfOperators <= item.AmountOfOperators * 2 + 1 || item.AmountOfOperators == 0);

                var stepResult = nextStep.Result();

                if (stepResult < 1 || _seenNumbers[stepResult])
                {
                    continue;
                }
                _seenNumbers[stepResult] = true;

                _availableExpressions.Add(nextStep);
                _expressionQueue.Enqueue(nextStep, nextStep.AmountOfOperators);
            }

            previousAmountOfSteps = item.AmountOfOperators;
        }
        */
    }




    private IEnumerable<Expression> GenerateSuccessors(Expression expression)
    {
        foreach (var otherExpression in _availableExpressions)
        {
            foreach (var operatorToApply in _availableOperators)
            {
                yield return new Operation
                {
                    Operator = operatorToApply,
                    A = expression,
                    B = otherExpression,
                };

                if (!IsSymmetrical(operatorToApply))
                {
                    yield return new Operation
                    {
                        Operator = operatorToApply,
                        A = otherExpression,
                        B = expression,
                    };

                }
            }
        }
    }


    private bool IsSymmetrical(Operator Operator) => Operator is Operator.Adder or Operator.Multiplier;

    private bool[] _seenNumbers = new bool[int.MaxValue / 2];
    private List<Expression> _availableExpressions = new();
    private ExpressionQueue _expressionQueue = new();
    private Operator[] _availableOperators;
}

public class ExpressionQueue : PriorityQueue<Expression, int>
{
    public ExpressionQueue() : base(Comparer<int>.Create((x, y) => x - y)) 
    { }
}
