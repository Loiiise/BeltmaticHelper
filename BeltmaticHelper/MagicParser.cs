using BeltmaticHelper.DataTypes;
using System.Diagnostics.CodeAnalysis;

namespace BeltmaticHelper;

/// <summary>
/// This is a quick and dirty parser that does the job and is suited for the size of this project.
/// Succesfully not over engineered :)
/// </summary>
internal static class MagicParser
{
    internal static bool TryParseConfiguration(string[] args, [NotNullWhen(true), MaybeNullWhen(false)] out ExecutionConfiguration executionConfiguration)
    {
        if (!MagicParser.TryParseOnlyHelpToken(args) &&
            args.Length >= 2 && args.Length <= 3 &&
            int.TryParse(args[0], out var highestNumber) &&
            GameKnowledgeMagicValues.TryGetOperatorFromDisplayString(args[1], out var highestOperator))
        {
            executionConfiguration = args.Length == 3 && int.TryParse(args[2], out var onlyNumberToFind)
                ? new ExecutionConfiguration(highestNumber, (Operator)highestOperator!, onlyNumberToFind)
                : new ExecutionConfiguration(highestNumber, (Operator)highestOperator!, null);

            return true;
        }

        executionConfiguration = null;
        return false;
    }

    internal static bool TryParseOnlyHelpToken(string[] args) => args.Length == 1 && args[0] == _helpToken;

    private const string _helpToken = "--help";
}

internal sealed record ExecutionConfiguration(int HighestNumber, Operator HighestOperator, int? OnlyNumberToFind);
