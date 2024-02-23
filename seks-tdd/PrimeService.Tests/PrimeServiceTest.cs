namespace Prime.Services.Tests;

public class PrimeServiceTests
{
    [Fact]
    public void TestOneIsPrime()
    {
        var primeService = new PrimeService();
        var result = primeService.IsPrime(1);
        Assert.False(result, "1 should not be prime");
    }
}