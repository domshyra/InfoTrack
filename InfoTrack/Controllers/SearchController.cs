using InfoTrack.Interfaces;
using InfoTrack.Models;
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

        public IActionResult Search(Search model)
        {
            model = _searchProvider.GetSearchResults(model.MaxSearchResults, model.SearchKeyword, model.SearchURL);
            return View("Search", model);
        }
    }
}