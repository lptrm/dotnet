using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace String.Calculator;

// https://tddmanifesto.com/exercises/
// TODO: 6, 7, 8
public class StringCalculator
{
    public static int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        string[] delimiters = [",", "\n"];

        var match = Regex.Match(numbers, @"^//(.*)\n");

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

        foreach (var token in tokens)
        {
            if (!Regex.IsMatch(token, @"^\d+$"))
            {
                if (Regex.IsMatch(token, @"^\d+[^0-9]\d+"))
                {
                    var falseSeparatorMatch = Regex.Match(token, "[^0-9]");
                    var exceptionString = $"The input String does not have the expected format. Expected {delimiters[0][..1]} but instead {falseSeparatorMatch.Value} found at position {position + 1}.";
                    throw new FormatException(exceptionString);
                }
                throw new FormatException("The input string does not have the expected format.");
            }
            position += token.Length + 1;
        }


        var result = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            result += int.Parse(tokens[i]);
        }


        return result;
    }
}
