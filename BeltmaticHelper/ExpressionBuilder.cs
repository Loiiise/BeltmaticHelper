using BeltmaticHelper.DataTypes;

namespace BeltmaticHelper;
public class ExpressionBuilder
{
    public Expression Find(int numberToFind, int[] availableNumbers, Operator availableOperators)
    {        
        _availableOperators = availableOperators;
        for (int i = availableNumbers.Length - 1; i >= 0; i--)
        {
            _expressionQueue.Enqueue(new Number
            {
                Value = availableNumbers[i],
            });
        }

        while (true)
        {
            var item = _expressionQueue.Dequeue();

            if (item.Result() == numberToFind)
            {
                return item;
            }

            throw new NotImplementedException();
        }
    }

    private Queue<Expression> _expressionQueue = new();
    private Operator _availableOperators;
}
