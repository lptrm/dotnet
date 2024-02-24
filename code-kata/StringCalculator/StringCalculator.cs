using System.Reflection.Metadata.Ecma335;

namespace String.Calculator;
public class StringCalculator
{
    public int Add(string numbers)
    {
        if(numbers.Trim() == "") {
            return 0;
        } 
        
        var split = numbers.Split(",");

        var operandsSize = split.Length;

        var parsed = new int[operandsSize];

        var result = 0;

        for (int i = 0; i < operandsSize; i++)
        {
            result += Int32.Parse(split[i]);
        }
        

        return result;
    }
}
