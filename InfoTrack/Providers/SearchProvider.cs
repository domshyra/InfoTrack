using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using InfoTrack.Interfaces;
using InfoTrack.Models;
using InfoTrack.Assemblers;
using System.Diagnostics;

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
            string searchURL = $"{_googleURL}num={maxResults}&q={keyword.Replace(' ', '+')}";

            WebClient webClient = new WebClient();
            try
            {
                //prevent too many requests
                System.Threading.Thread.Sleep(5000);

                string downloadStr = webClient.DownloadString(searchURL);

                List<Link> links = Find(downloadStr);

                //remove null links
                List<Link> nullLinks = links.Where(x => string.IsNullOrEmpty(x.Href)).ToList();
                foreach (Link nullLink in nullLinks)
                {
                    links.Remove(nullLink);
                }

                List<Link> matchedURLs = links.Where(x => x.Href.Contains(url)).ToList();

                return matchedURLs.MakeSearchResultCards();
            }
            catch (WebException e)
            {
                Debug.WriteLine(e.Status);
            }

            return new List<SearchResultCard>();
            
        }

        public List<Link> Find(string file)
        {
            List<Link> list = new List<Link>();

            // Find all matches in file.
            MatchCollection matches = Regex.Matches(file, @"(?s)<div[^>]*?class=\""ZINbbc xpd O9g5cc uUPGi\""[^>]*?><div[^>](.*?)</div></div>");

            // Loop over each match.
            foreach (Match match in matches)
            { 
                string value = match.Groups[1].Value;
                Link link = new Link();

                // Get title attribute
                Match titleMatch = Regex.Match(value, @"(?s)<div[^>]*?class=\""BNeawe vvjwJb AP7Wnd\""[^>]*?>(.*?)</div>", RegexOptions.Singleline);
                if (titleMatch.Success)
                {
                    link.Title = titleMatch.Groups[1].Value;
                }
                // Get href attribute
                Match hrefMatch = Regex.Match(value, @"(?s)<div[^>]*?class=\""BNeawe UPmit AP7Wnd\""[^>]*?>(.*?)</div>", RegexOptions.Singleline);
                if (hrefMatch.Success)
                {
                    link.Href = hrefMatch.Groups[1].Value;
                }
                // Get text attribute
                //<div class="BNeawe s3v9rd AP7Wnd"><div><div><div class="BNeawe s3v9rd AP7Wnd">
                Match descriptionMatch = Regex.Match(value, @"(?s)<div[^>]*?class=\""BNeawe s3v9rd AP7Wnd\""[^>]*?><div[^>]*?[^>]*?><div[^>]*?[^>]*?><div[^>]*?class=\""BNeawe s3v9rd AP7Wnd\""[^>]*?>(.*?)(.*)", RegexOptions.Multiline);
                if (descriptionMatch.Success)
                {
                    link.Text = descriptionMatch.Groups[2].Value;
                }

                list.Add(link);
            }


            return list;
        }
    }
}
