using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace String.Calculator;

// https://tddmanifesto.com/exercises/
// TODO: 6, 7, 8
public partial class StringCalculator
{
    public static int Add(string numbers)
    {
        var result = 0;

        if (string.IsNullOrWhiteSpace(numbers))
        {
            return result;
        }

        string[] delimiters = [",", "\n"];

        var match = delimiterRegex().Match(numbers);

        if (match.Success)
        {
            delimiters = [Regex.Escape(match.Groups[1].Value)];
            numbers = numbers[match.Length..];
        }

        var pattern = string.Join("|", delimiters);

        var tokens = Regex.Split(numbers, pattern);

        var delimitersAmount = 0;

        foreach (var delimiter in delimiters)
        {
            delimitersAmount += Regex.Matches(numbers, delimiter).Count;
        }

        var position = 0;
        var stringBuilder = new StringBuilder();
        var negatives = new List<string>();

        foreach (var token in tokens)
        {
            if (!validTokenRegex().IsMatch(token))
            {
                var errorReason = false;
                if (delimiterErrorRegex().IsMatch(token))
                {
                    stringBuilder.Append($"Expected {delimiters[0][..1]} but instead {noNumberRegex().Match(token).Value} found at position {position + 1}.");
                    errorReason = true;
                }

                var negativeMatches = negativeErrorRegex().Matches(token);
                if (negativeMatches.Count != 0)
                {
                    foreach (var negativeMatch in negativeMatches)
                    {
                        negatives.Add(negativeMatch.ToString());
                    }
                    errorReason = true;
                }
                if (!errorReason)
                {
                    stringBuilder.Append("Format does not fit!");
                }
            }
            else
            {
                var intRepresentation = int.Parse(token);
                if (intRepresentation < 1000)
                {
                    result += intRepresentation;
                }
            }
            position += token.Length + 1;
        }

        if (negatives.Count != 0)
        {
            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                stringBuilder.Append('\n');
            }
            stringBuilder.Append($"Negative numbers are not allowed: ");
            stringBuilder.Append(string.Join(", ", negatives));
        }

        var errorMessage = stringBuilder.ToString();

        if (!string.IsNullOrEmpty(errorMessage))
        {
            throw new FormatException(errorMessage);
        }

        return result;
    }

    [GeneratedRegex(@"^//(.*)\n")]
    private static partial Regex delimiterRegex();
    [GeneratedRegex(@"^\d+$")]
    private static partial Regex validTokenRegex();
    [GeneratedRegex(@"^-?\d+[^0-9]-?\d+$")]
    private static partial Regex delimiterErrorRegex();
    [GeneratedRegex(@"-\d+")]
    private static partial Regex negativeErrorRegex();
    [GeneratedRegex("[^0-9]")]
    private static partial Regex noNumberRegex();
}
