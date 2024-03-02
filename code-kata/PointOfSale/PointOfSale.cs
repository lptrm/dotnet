namespace PointOfSale;

public class PointOfSale
{
    public string Scan(string barCode){
        var amount = "";
        if(barCode.Equals("12345")){
            amount = "$7.25";
        }
        
        return amount;
    }
}
