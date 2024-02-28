using Microsoft.VisualBasic;

namespace String.Calculator.Tests;

public class StringCalculatorTest
{
    [Fact]
    public void GivenEmptyString_whenAdd_thenResultIs0()
    {
        // Given
        var intput = "";
        // When
        var result = StringCalculator.Add(intput);
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenString1_whenAdd_thenResultIs1()
    {
        // Given
        var input = "1";
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(1, result);
    }

    [Fact]
    public void GivenString1Comma2_whenAdd_thenResultIs3()
    {
        // Given
        var input = "1,2";
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(3, result);
    }

       [Fact]
    public void GivenString1Comma2Comma3_whenAdd_thenResultIs6()
    {
        // Given
        var input = "1,2,3";
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }

       [Fact]
    public void GivenString1Comma2Comma3Comma4_whenAdd_thenResultIs10()
    {
        // Given
        var input = "1,2,3,4";
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(10, result);
    }

       [Fact]
    public void GivenString1Comma2Newline3_whenAdd_thenResultIs6()
    {
        // Given
        var input = "1,2\n3";
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }
    
    [Fact]
    public void GivenString2Newline3_whenAdd_thenThrowsException()
    {
        // Given
        var input = "2,\n3";
        // When Then
        Assert.Throws<FormatException> (() => StringCalculator.Add(input));
    }

    [Fact]
    public void GivenDelimitersSemicolonOps1Semicolon2_whenAdd_thenResultIs3()
    {
        // Given
        var input = "//;\n1;2";   
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(3, result);
    }

    [Fact]
    public void GivenDelimiterBarOps1Bar2Bar3_whenAdd_thenResultIs6()
    {
        // Given
        var input = "//|\n1|2|3";   
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(6, result);
    }

    [Fact]
    public void GivenDelimiterSepOps2sep5_whenAdd_thenResultIs7()
    {
        // Given
        var input = "//sep\n2sep5";   
        // When
        var result = StringCalculator.Add(input);
        // Then
        Assert.Equal(7, result);
    }

    [Fact]
    public void GivenDelimiterBarOps1Bar2Semicolon5_whenAdd_thenThrowsException()
    {
        // Given
        var input = "//|\n1|2;3";   
        // When Then
        var ex = Assert.Throws<FormatException> (() => StringCalculator.Add(input));
        Assert.Equal("The input String does not have the expected format. Expected \\ but instead ; found at position 3.", ex.Message);

    }
    
    [Fact]
    public void Given1CommaMinus2_whenAdd_thenThrowsException()
    {
        // Given
        var input = "1,-2";   
        // When Then
        var ex = Assert.Throws<FormatException> (() => StringCalculator.Add(input));
        Assert.Equal("The input String does not have the expected format. Negative numbers are not allowed: -2", ex.Message);

    }
}