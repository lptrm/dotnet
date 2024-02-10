namespace Prime.Services;

public class NumberGenerator
{
    IPrimeService _primeService = new PrimeService();
    public NumberGenerator(IPrimeService primeService)
    {
        _primeService = primeService;
    }
    public int GenerateNextPrime(int number)
    {
        var nextNumber = number + 1;
        while (!_primeService.IsPrime(nextNumber))
        {
            nextNumber++;
        }
        return nextNumber;
    }
}