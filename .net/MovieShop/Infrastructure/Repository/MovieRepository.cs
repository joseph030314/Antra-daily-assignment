using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ApplicationCore.Helpers;
namespace Infrastructure.Repository
{
    

    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext dbContext;
        public MovieRepository(MovieShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            return await dbContext.Movies
                         .OrderByDescending(m => m.Revenue)
                         .Take(24)
                         .ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await dbContext.Movies
                         //.Include(m => m.Title)
                         .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Movie> GetMovieDetails(int id)
        {
            return await dbContext.Movies
                             .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                             .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                             .Include(m => m.Trailers)
                             .Include(m => m.Reviews)
                             .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<PaginatedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 24, int pageNumber = 1)
        {
            var totalMoviesCount = await dbContext.MovieGenres
                .Where(g => g.GenreId == genreId)
                .CountAsync();

            var movies = await dbContext.MovieGenres
                .Where(g => g.GenreId == genreId)
                .Include(mg => mg.Movie)
                .ThenInclude(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(mg => mg.Movie)
                .ToListAsync();

            return new PaginatedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCount);
        }

  
    }
}
