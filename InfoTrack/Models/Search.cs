using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTrack.Models
{
    public class Search
    {
        public Search()
        {
            SearchResultCards = new List<SearchResultCard>();
            MaxSearchResults = 100;
            SearchKeyword = "online title search";
            SearchURL = "www.infotrack.com.au";
        }

        public List<SearchResultCard> SearchResultCards { get; set; }
        [Display(Name="Max search results")]
        public int MaxSearchResults { get; set; }
        [Display(Name = "Search keyword")]
        public string SearchKeyword  { get; set; }
        [Display(Name = "Search URL")]
        public string SearchURL { get; set; }

    }
}
