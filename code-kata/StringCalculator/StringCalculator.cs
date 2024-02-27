using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace String.Calculator;
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

        if (delimitersAmount != tokens.Length - 1){
            throw new FormatException("The input string does not have the expected format.");
        }

        var result = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            result += int.Parse(tokens[i]);
        }
        

        return result;
    }
}
