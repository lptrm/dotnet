namespace SearchFunctionality.Tests;

public class SearchFunctionalityTest
{
    [Fact]
    public void GivenEmptyChar_whenSearch_thenResultIsEmpty()
    {
        //Given
        var  input = "";
        var expected = new List<string>();
        //When
        var result = SearchFunctionality.Search(input);
        //Then
        Assert.Equal(expected, result);
    }
}