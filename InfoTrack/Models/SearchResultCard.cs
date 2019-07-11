using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.Models
{
    public class SearchResultCard
    {
        //card title
        public string Title { get; set; }
        //click through link for card title 
        public string TitleLink { get; set; }
        public string CardBodyText { get; set; }
    }
}
