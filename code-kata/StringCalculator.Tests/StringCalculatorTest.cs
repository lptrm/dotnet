namespace String.Calculator.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void GivenEmptyString_whenAdd_thenResultIs0()
    {
        // Arrange
        var calculator = new StringCalculator();
        // Act
        var result = calculator.Add("");
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenString1_whenAdd_thenResultIs1()
    {
        // Given
        var calculator = new StringCalculator();
        // When
        var result = calculator.Add("1");
        // Then
        Assert.Equal(1, result);
    }

    [Fact]
    public void GivenString1And2_whenAdd_thenResultIs3()
    {
        // Given
        var calculator = new StringCalculator();
        // When
        var result = calculator.Add("1,2");
        // Then
        Assert.Equal(3, result);
    }

       [Fact]
    public void GivenString1And2And3_whenAdd_thenResultIs6()
    {
        // Given
        var calculator = new StringCalculator();
        // When
        var result = calculator.Add("1,2,3");
        // Then
        Assert.Equal(6, result);
    }

       [Fact]
    public void GivenString1And2And3And4_whenAdd_thenResultIs10()
    {
        // Given
        var calculator = new StringCalculator();
        // When
        var result = calculator.Add("1,2,3,4");
        // Then
        Assert.Equal(10, result);
    }

       [Fact]
    public void GivenString1And2AndNewlineAnd3_whenAdd_thenResultIs6()
    {
        // Given
        var calculator = new StringCalculator();
        // When
        var result = calculator.Add("1,2\n3");
        // Then
        Assert.Equal(6, result);
    }
}