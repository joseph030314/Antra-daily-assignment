using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Overview { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Budget { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Revenue { get; set; }
        [Column(TypeName = "nvarchar(2084)")]
        public string ImdbUrl { get; set; }
        [Column(TypeName = "nvarchar(2084)")]
        public string TmdbUrl { get; set; }
        [Column(TypeName = "nvarchar(2084)")]
        public string PosterUrl { get; set; }
        [Column(TypeName = "nvarchar(2084)")]
        public string BackdropUrl { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string OriginalLanguage { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "int")]
        public int? RunTime { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string Tagline { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Trailer> Trailers { get; set; }
    }
}
