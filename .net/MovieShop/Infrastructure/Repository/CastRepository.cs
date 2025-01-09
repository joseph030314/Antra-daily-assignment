using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;

namespace Infrastructure.Repository
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        private readonly MovieShopDbContext dbContext;
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public override async Task<Cast> GetById(int id)
        {
            return await _dbContext.Casts
            .Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
