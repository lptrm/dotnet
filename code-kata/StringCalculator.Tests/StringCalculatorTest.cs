using Microsoft.VisualBasic;

namespace String.Calculator.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void GivenEmptyString_whenAdd_thenResultIs0()
    {
        // Given
        var calculator = new StringCalculator();
        var intput = "";
        // When
        var result = calculator.Add(intput);
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenString1_whenAdd_thenResultIs1()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "1";
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(1, result);
    }

    [Fact]
    public void GivenString1Comma2_whenAdd_thenResultIs3()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "1,2";
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(3, result);
    }

       [Fact]
    public void GivenString1Comma2Comma3_whenAdd_thenResultIs6()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "1,2,3";
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }

       [Fact]
    public void GivenString1Comma2Comma3Comma4_whenAdd_thenResultIs10()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "1,2,3,4";
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(10, result);
    }

       [Fact]
    public void GivenString1Comma2Newline3_whenAdd_thenResultIs6()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "1,2\n3";
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }
    
    [Fact]
    public void GivenString2Newline3_whenAdd_thenThrowsException()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "2,\n3";
        // When Then
        Assert.Throws<FormatException> (() => calculator.Add(input));
    }

    [Fact]
    public void GivenDelimiters1Semicolon2_whenAdd_thenResultIs3()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "//;\n1;2";   
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(3, result);
    }

    [Fact]
    public void GivenDelimiters1Bar2Bar3_whenAdd_thenResultIs6()
    {
        // Given
        var calculator = new StringCalculator();
        var input = "//|\n1|2|3";   
        // When
        var result = calculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }

}