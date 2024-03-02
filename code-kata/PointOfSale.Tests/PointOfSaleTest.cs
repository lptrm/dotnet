namespace PointOfSale.Tests;

public class PointOfSaleTest
{
    [Fact]
    public void GivenBarCode12345_whenScan_thenDisplayPriceIsDollarSign7Point25()
    {
        //Given
        var input = "12345";
        var pointOfSale = new PointOfSale();
        //When
        var result = pointOfSale.Scan(input);
        //Then
        Assert.Equal("$7.25", result);
    }
}