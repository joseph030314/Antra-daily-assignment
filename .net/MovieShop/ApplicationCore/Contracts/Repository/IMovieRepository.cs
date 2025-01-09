using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetHighestGrossingMovies();
        Task<Movie> GetMovieById(int id);

        Task<Movie> GetMovieDetails(int id);

        Task<PaginatedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
