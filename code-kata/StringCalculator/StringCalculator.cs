using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
        var stringBuilder = new StringBuilder();
        var negatives = new ArrayList();

        foreach (var token in tokens)
        {
            if (!Regex.IsMatch(token, @"^\d+$"))
            {   
                if (Regex.IsMatch(token, @"^-?\d+[^0-9]-?\d+$"))
                {
                    stringBuilder.Append($"Expected {delimiters[0][..1]} but instead {Regex.Match(token, "[^0-9]").Value} found at position {position + 1}.");
                } 

                var negativeMatches = Regex.Matches(token, @"-\d+");
                if (negativeMatches.Count != 0) {
                    foreach(var negativeMatch in negativeMatches){
                        negatives.Add(negativeMatch);
                    }
                }
            }
            position += token.Length + 1;
        }

        var errorMessage = stringBuilder.ToString();

        if(negatives.Count != 0){
            stringBuilder.Clear();
            if(!string.IsNullOrEmpty(errorMessage)){
                stringBuilder.Append('\n');
            }
            stringBuilder.Append($"Negative numbers are not allowed:");
            foreach(var negative in negatives){
                stringBuilder.Append($" {negative},");
            }
            var errorString = stringBuilder.ToString();
            errorMessage += errorString[..(errorString.Length - 1)];
        }

        if (!string.IsNullOrEmpty(errorMessage)){
            throw new FormatException(errorMessage);
        }

        var result = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            var intRepresentation = int.Parse(tokens[i]);
            if(intRepresentation < 1000){
                result += int.Parse(tokens[i]);
            }
        }


        return result;
    }
}
