using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("\"MovieShopDbConnection\": \"Data Source=SARTHAKX360\\\\MSSQLSERVER01;Initial Catalog=MovieShopApp;Integrated Security=True;Trust Server Certificate=True\"",
                    sqlServerOptions => sqlServerOptions.CommandTimeout(180)); // Timeout in seconds
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.GenreId, mg.MovieId });

            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.CastId, mc.MovieId });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.RoleId, ur.UserId });

            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.MovieId, r.UserId });

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.MovieId, f.UserId });

            modelBuilder.Entity<Purchase>()
                .HasKey(p => new { p.MovieId, p.UserId });

        }
    }
}
