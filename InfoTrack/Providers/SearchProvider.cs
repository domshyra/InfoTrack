using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTrack.Models;

namespace InfoTrack.Providers
{
    public class SearchProvider
    {
        private const string _googleURL = "https://www.google.com.au/search?";

        public Search GetSearchResults(int maxResults, string keyword, string url)
        {
            Search search = new Search()
            {
                MaxSearchResults = maxResults,
                SearchKeyword = keyword,
                SearchURL = url
            };


            return search;
        }

        public List<SearchResultCard> GetSearchResultCards(Search search)
        {
            List<SearchResultCard> cards = new List<SearchResultCard>();

            string searchURL = $"{_googleURL}num={search.MaxSearchResults}&q={search.SearchKeyword.Replace(' ', '+')}";

            return cards;
        }
    }
}
