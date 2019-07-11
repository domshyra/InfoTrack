using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InfoTrack.Interfaces;
using InfoTrack.Models;

namespace InfoTrack.Providers
{
    public class SearchProvider : ISearchProvider
    {
        private const string _googleURL = "https://www.google.com.au/search?";

        public Search GetSearchResults(int maxResults, string keyword, string url)
        {
            Search search = new Search()
            {
                MaxSearchResults = maxResults,
                SearchKeyword = keyword.Trim(),
                SearchURL = url.Trim(),
                SearchResultCards = GetSearchResultCards(maxResults, keyword.Trim(), url.Trim())
            };


            return search;
        }

        public List<SearchResultCard> GetSearchResultCards(int maxResults, string keyword, string url)
        {
            List<SearchResultCard> cards = new List<SearchResultCard>();

            string searchURL = $"{_googleURL}num={maxResults}&q={keyword.Replace(' ', '+')}";

            WebClient webClient = new WebClient();
            string downloadStr = webClient.DownloadString(searchURL);

            foreach (Link item in Find(downloadStr))
            {
                Debug.WriteLine(item);
            }

            return cards;
        }

        public List<Link> Find(string file)
        {
            List<Link> list = new List<Link>();

            // Find all matches in file.
            MatchCollection matches = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                RegexOptions.Singleline);

            // Loop over each match.
            foreach (Match match in matches)
            {
                string value = match.Groups[1].Value;
                Link link = new Link();

                // Get href attribute.
                Match hrefMatch = Regex.Match(value, @"href=\""(.*?)\""",
                    RegexOptions.Singleline);
                if (hrefMatch.Success)
                {
                    link.Href = hrefMatch.Groups[1].Value;
                }

                // Remove inner tags from text.
                string text = Regex.Replace(value, @"\s*<.*?>\s*", "",
                    RegexOptions.Singleline);
                link.Text = text;

                list.Add(link);
            }
            return list;
        }
    }
}
