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

        var delimiters = new char[] { ',', ';', '\n' };

        var delimitersAmount = 0;

        foreach (var delimiter in delimiters)
        {
            delimitersAmount += Regex.Matches(numbers, delimiter.ToString()).Count;
        }
        
        var split = numbers.Split(delimiters);

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
