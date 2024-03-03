namespace PointOfSale;

public class PointOfSale
{
    public string Amount { get; private set; }
    private string ErrorMessage { get; set; }
    public PointOfSale()
    {
        Amount = "";
        ErrorMessage = "";
    }
    public string Scan(string barCode)
    {
        var intAmount = 0;
        if (barCode.Contains("total\n"))
        {
            var split = barCode.Split("\n");
            for (int i = 1; i < split.Length; i++)
            {
                if (IsValidBarCode(split[i]))
                {
                    intAmount += GetIntFromBarCode(split[i]);
                }
            }
        }
        else
        {
            if (IsValidBarCode(barCode))
            {
                intAmount += GetIntFromBarCode(barCode);
            }
        }
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            var stringRep = intAmount.ToString();
            Amount = $"${stringRep[..(stringRep.Length - 2)]}.{stringRep[(stringRep.Length - 2)..]}";
        }
        else
        {
            Amount = ErrorMessage;
        }

        return Amount;
    }
    private bool IsValidBarCode(string barCode)
    {
        if (barCode.Equals("99999"))
        {
            SetErrorMessage("Error: barcode not found");
            return false;
        }
        if (string.IsNullOrEmpty(barCode))
        {
            SetErrorMessage("Error: emtpy barcode");
            return false;
        }
        return true;
    }
    private void SetErrorMessage(string errorMessage)
    {
        if (ErrorMessage.StartsWith("Error"))
        {
            ErrorMessage += "\n" + errorMessage;
        }
        else
        {
            ErrorMessage = errorMessage;
        }
    }

    private static int GetIntFromBarCode(string barCode)
    {
        return barCode switch
        {
            "12345" => 725,
            "23456" => 1250,
            _ => 0,
        };
    }
}
