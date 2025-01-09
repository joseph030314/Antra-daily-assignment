using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2048)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(2048)")]
        public string TrailerUrl { get; set; }
    }
}
