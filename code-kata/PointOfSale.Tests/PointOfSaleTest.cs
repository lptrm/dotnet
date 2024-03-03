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

    [Fact]
    public void GivenBarCode23456_whenScan_thenDisplayPriceIsDollarSign12Point50()
    {
        //Given
        var input = "23456";
        var pointOfSale = new PointOfSale();
        //When
        var result = pointOfSale.Scan(input);
        //Then
        Assert.Equal("$12.50", result);
    }
    [Fact]
    public void GivenBarCode99999_whenScan_thenDisplayErrorBarCodeNotFound()
    {
        //Given
        var input = "99999";
        var pointOfSale = new PointOfSale();
        //When
        var result = pointOfSale.Scan(input);
        //Then
        Assert.Equal("Error: barcode not found", result);
    }
    [Fact]
    public void GivenEmptyBarCode_whenScan_thenDisplayErrorEmptyBarCode()
    {
        //Given
        var input = "";
        var pointOfSale = new PointOfSale();
        //When
        var result = pointOfSale.Scan(input);
        //Then
        Assert.Equal("Error: empty barcode", result);
    }
    [Fact]
    public void GivenTotalNewLine12345NewLine23456_whenScan_thenDisplayDollarSign19Point75()
    {
        //Given
        var input = "total\n12345\n23456";
        var pointOfSale = new PointOfSale();
        //When
        var result = pointOfSale.Scan(input);
        //Then
        Assert.Equal("$19.75", result);
    }
}