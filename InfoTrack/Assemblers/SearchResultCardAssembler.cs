using InfoTrack.Models;
using System.Collections.Generic;
using System.Linq;


namespace InfoTrack.Assemblers
{
    public static class SearchResultCardAssembler
    {
        public static SearchResultCard MakeSearchResultCard(this Link source)
        {
            return new SearchResultCard
            {
                Title = source.Title,
                TitleLink = source.Href,
                CardBodyText = source.Text
            };
        }

        public static List<SearchResultCard> MakeSearchResultCards(this IEnumerable<Link> source)
        {
            return source.Select(r => r.MakeSearchResultCard()).ToList();
        }
    }
}
