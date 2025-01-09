using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Repository;
using Infrastructure.Services;

namespace MovieShop.Controllers
{
    public class MoviesController : BaseController
    {
        //private readonly IMovieRepository _movieRepository;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService) : base(genreService)
        {
            //_movieRepository = movieRepository;
            _movieService = movieService;
            _genreService = genreService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.MovieDetails(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        public async Task<IActionResult> HighestGrossing()
        {
            var movies = await _movieService.GetTopGrossingMovies();
            return View(movies);
        }
       // [HttpGet("Movies/Genre/{id}")]
        public async Task<IActionResult> Genre(int id, int pageSize = 24, int pageNumber = 1)
        {
            var movies = await _movieService.GetMoviesByGenre(id, pageSize, pageNumber);
            var genre = await _genreService.GetGenreByIdAsync(id); 
            ViewBag.GenreName = genre.Name; 
            ViewBag.GenreId = id;
            return View(movies);
        }

    }
}
