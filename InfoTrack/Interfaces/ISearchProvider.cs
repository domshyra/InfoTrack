using System.Collections.Generic;
using InfoTrack.Models;

namespace InfoTrack.Interfaces
{
    public interface ISearchProvider
    {
        List<Link> Find(string file);
        List<SearchResultCard> GetSearchResultCards(Search search);
        Search GetSearchResults(int maxResults, string keyword, string url);
    }
}