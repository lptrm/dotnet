namespace PointOfSale;

public class PointOfSale
{
    public string Scan(string barCode){
        var amount = "";
        if(barCode.Equals("12345")){
            amount = "$7.25";
        } else if (barCode.Equals("23456")){
            amount = "$12.50";
        } else if (barCode.Equals("99999")){
            amount = "Error: barcode not found";
        } else if (string.IsNullOrEmpty(barCode)){
            amount = "Error: empty barcode";
        }
        
        return amount;
    }
}
