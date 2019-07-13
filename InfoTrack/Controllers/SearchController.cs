using InfoTrack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        public IActionResult Index()
        {
            _searchProvider.GetSearchResults(100, "online title search", "www.infotrack.com.au");
            return View();
        }

        public string UpdateSearch(int maxResults, string keyword, string url)
        {
            return "";
        }
    }
}