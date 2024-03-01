using Microsoft.VisualBasic;

namespace SearchFunctionality;

public class SearchFunctionality
{
    public List<string> DB { get; private set; }
    public List<string> SearchResult { get; private set; }
    public SearchFunctionality()
    {
        DB = ["Paris", "Budapest", "Skopje", "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York City", "London", "Bangkok", "Dubai", "Rome", "Istandbul"];
        SearchResult = [];
    }

    public SearchFunctionality Search(string input)
    {
        input = input.Trim();
        if (string.IsNullOrEmpty(input) || input.Length < 2)
        {
            return this;
        }
        if (input.Equals("*"))
        {
            SearchResult.AddRange(DB);
        }
        SearchResult = DB.Where(city => city.StartsWith(input, StringComparison.CurrentCultureIgnoreCase)
                                        || city.Contains(input, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return this;
    }
}
