using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;
using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using System.Threading.Tasks;

namespace MovieShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public HomeController(IMovieService movieService, IGenreService genreService, ILogger<HomeController> logger) : base(genreService)
        {
            _logger = logger;
            _movieService = movieService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetTopGrossingMovies();
            var genres = await _genreService.GetAllGenres();
            ViewBag.Genres = genres;
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
