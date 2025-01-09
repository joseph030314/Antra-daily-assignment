using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ApplicationCore.Contracts.Repository;

namespace Infrastructure.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly MovieShopDbContext _dbContext;
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> AddAsync(Genre entity)
        {
            _dbContext.Set<Genre>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Genre entity)
        {
            _dbContext.Set<Genre>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Genre>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Genre>> ListAllAsync()
        {
            return await _dbContext.Set<Genre>().ToListAsync();
        }

        public async Task<IReadOnlyList<Genre>> ListAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _dbContext.Set<Genre>().Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(Genre entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // You can add any custom methods for GenreRepository here
    }
}