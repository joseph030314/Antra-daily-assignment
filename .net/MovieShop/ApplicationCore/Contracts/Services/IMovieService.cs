using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // Task<List<MovieCardModel>> GetTestMovies();
        Task<PaginatedResultSet<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize, int pageNumber);
        Task<Movie> MovieDetails(int id);
        Task<IEnumerable<Movie>> GetTopGrossingMovies();
    }
}
