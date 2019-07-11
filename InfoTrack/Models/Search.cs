using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.Models
{
    public class Search
    {
        public Search()
        {
            SearchResultCards = new List<SearchResultCard>();
        }

        public List<SearchResultCard> SearchResultCards { get; set; }
        public int MaxSearchResults { get; set; }
        public string SearchKeyword  { get; set; }
        public string SearchURL { get; set; }

    }
}
