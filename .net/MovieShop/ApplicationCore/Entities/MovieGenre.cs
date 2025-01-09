using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        [Required]
        [Column(TypeName = "int")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
