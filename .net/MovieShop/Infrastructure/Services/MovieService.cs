using ApplicationCore.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repository;
using AutoMapper;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        /*public async Task<List<MovieCardModel>> GetTestMovies()
        {
            return new List<MovieCardModel>
            {
                new MovieCardModel { Id = 1, Title = "Inception", PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg" },
                new MovieCardModel { Id = 2, Title = "Interstellar", PosterUrl = "/images/interstellar.jpg" },
                new MovieCardModel { Id = 3, Title = "The Dark Knight", PosterUrl = "/images/thedarkknight.jpg" }
            };
        }*/
        public async Task<IEnumerable<Movie>> GetTopGrossingMovies()
        {
            return await _movieRepository.GetHighestGrossingMovies();
        }
        public async Task<Movie> MovieDetails(int id)
        {
            return await _movieRepository.GetMovieDetails(id);
        }
        public async Task<PaginatedResultSet<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize, int pageNumber)
        {
            var paginatedMovies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageNumber);
            var movieCardModels = paginatedMovies.Data.Select(m => _mapper.Map<MovieCardModel>(m)).ToList();
            return new PaginatedResultSet<MovieCardModel>(movieCardModels, paginatedMovies.PageNumber, paginatedMovies.PageSize, paginatedMovies.TotalCount);
        }
    }
}
