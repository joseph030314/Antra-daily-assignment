using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Contracts.Repository;
using AutoMapper;
using ApplicationCore.RepositoryInterfaces;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.ListAllAsync();
            var genreModels = _mapper.Map<IEnumerable<GenreModel>>(genres);
            return genreModels;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.ListAllAsync();
            var genreModels = _mapper.Map<IEnumerable<GenreModel>>(genres);
            return genreModels;
        }
        public async Task<Genre> GetGenreByIdAsync(int id) 
        {
            return await _genreRepository.GetByIdAsync(id);
        }
    }
}
