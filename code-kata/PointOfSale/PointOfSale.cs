namespace PointOfSale;

public class PointOfSale
{
    public string Amount {get; private set;}
    public PointOfSale(){
        Amount = "";
    }
    public string Scan(string barCode){
        var intAmount = 0;
        if(barCode.Contains("total\n")){
            var split = barCode.Split("\n");
            for (int i = 1; i < split.Length; i++)
            {
                if(IsValidBarCode(split[i])){
                    intAmount += GetIntFromBarCode(split[i]);
                }
            }
        } else {
            if(IsValidBarCode(barCode)){
                intAmount += GetIntFromBarCode(barCode);
            }
        }
        if(!Amount.StartsWith("Error")){
            var stringRep = intAmount.ToString();
            Amount = $"${stringRep[..(stringRep.Length-2)]}.{stringRep[(stringRep.Length-2)..]}";
        }
        
        return Amount;
    }
    private bool IsValidBarCode(string barCode){
        if (barCode.Equals("99999")){
            if(Amount.StartsWith("Error")){
                Amount += "\nError: barcode not found";
            } else{
                Amount = "Error: barcode not found";
            }
            return false;
        }
        if (string.IsNullOrEmpty(barCode)){
            if(Amount.StartsWith("Error")){
                Amount += "\nError: barcode not found";
            } else {
                Amount = "Error: empty barcode";
            }
            return false;
        }
        return true ;
    }

    private static int GetIntFromBarCode(string barCode){
        return barCode switch
        {
            "12345" => 725,
            "23456" => 1250,
            _ => 0,
        };
    }
}
