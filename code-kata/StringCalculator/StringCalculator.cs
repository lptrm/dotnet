using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace String.Calculator;
public class StringCalculator
{
    public int Add(string numbers)
    {
        if(numbers.Trim() == "") {
            return 0;
        }

        var regex = new Regex("//.*?\n");

        var delimiters = Array.Empty<string>();

        if (regex.IsMatch(numbers)){
            var splitOuter = regex.Split(numbers);
            var delimitersString = splitOuter[0][1..splitOuter.Length];
            delimiters = delimitersString.Split("");
        } else {
            delimiters = new string[] { ",", ";", "\n" };
        }

        var delimitersAmount = 0;

        foreach (var delimiter in delimiters)
        {
            delimitersAmount += Regex.Matches(numbers, delimiter).Count;
        }
        
        var charSplit = new char[delimiters.Length];

        for (int i = 0; i < delimiters.Length; i++)
        {
            charSplit[i] = delimiters[i].ToCharArray()[0];
        }

        var split = numbers.Split(charSplit);

        if (delimitersAmount != split.Length - 1){
            throw new FormatException("The input string does not have the expected format.");
        }


        var operandsSize = split.Length;

        var result = 0;

        for (int i = 0; i < operandsSize; i++)
        {
            result += Int32.Parse(split[i]);
        }
        

        return result;
    }
}
