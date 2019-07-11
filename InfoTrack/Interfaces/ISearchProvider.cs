using System.Collections.Generic;
using InfoTrack.Models;

namespace InfoTrack.Interfaces
{
    public interface ISearchProvider
    {
        List<Link> Find(string file);
        List<SearchResultCard> GetSearchResultCards(int maxResults, string keyword, string url);
        /// <summary>
        /// returns Search object based on inputs
        /// </summary>
        /// <param name="maxResults">max results of search</param>
        /// <param name="keyword">seach keyword</param>
        /// <param name="url">url to find</param>
        /// <returns></returns>
        Search GetSearchResults(int maxResults, string keyword, string url);
    }
}