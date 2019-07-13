using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.Models
{
    public class Link
    {
        public string Href { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Href}\n\t{Text}";
        }
    }
}
