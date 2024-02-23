namespace FizzBuzz.Tests;

public class FizzBuzzTests
{
    [Fact]
    public void TestFizz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = "";
        for (int i = 3; i < 100; i += 3)
        {   
            if (i % 5 == 0)
            {
                continue;
            }
            result = fizzBuzz.Get(i);
            Assert.Equal("Fizz", result);
        }
    }
    [Fact]
    public void TestBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = "";
        for (int i = 5; i < 100; i += 5)
        {
            if (i % 3 == 0)
            {
                continue;
            }
            result = fizzBuzz.Get(i);
            Assert.Equal("Buzz", result);
        }
    }
    [Fact]
    public void TestFizzBuzz()
    {
        var fizzBuzz = new FizzBuzz();
        var result = "";
        for (int i = 15; i < 100; i += 15)
        {
            result = fizzBuzz.Get(i);
            Assert.Equal("FizzBuzz", result);
        }
    }
}