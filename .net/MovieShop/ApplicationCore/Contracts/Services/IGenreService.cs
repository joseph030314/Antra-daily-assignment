using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
        Task<IEnumerable<GenreModel>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
    }
}