namespace SearchFunctionality.Tests;

public class SearchFunctionalityTest
{
    [Fact]
    public void GivenEmptyChar_whenSearch_thenResultIsEmpty()
    {
        //Given
        var input = "";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal([], result);
    }
    [Fact]
    public void GivenSingleChar_whenSearch_thenResultIsEmpty()
    {
        //Given
        var input = "a";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal([], result);
    }
    [Fact]
    public void GivenLowerVA_whenSearch_thenResultIsValenciaAndVancouver()
    {
        //Given
        var input = "va";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal(["Valencia", "Vancouver"], result);
    }
    [Fact]
    public void GivenUpperVA_whenSearch_thenResultIsValenciaAndVancouver()
    {
        //Given
        var input = "VA";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal(["Valencia", "Vancouver"], result);
    }

    [Fact]
    public void GivenUpperVLowerA_whenSearch_thenResultIsValenciaAndVancouver()
    {
        //Given
        var input = "Va";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal(["Valencia", "Vancouver"], result);
    }
    [Fact]
    public void GivenAPE_whenSearch_thenResultIsBudapest()
    {
        //Given
        var input = "ape";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal(["Budapest"], result);
    }
    [Fact]
    public void GivenAsterix_whenSearch_thenResultIsEveryCity()
    {
        //Given
        var input = "*";
        var searchFunctionality = new SearchFunctionality();
        //When
        var result = searchFunctionality.Search(input).SearchResult;
        //Then
        Assert.Equal(searchFunctionality.DB, result);
    }
}