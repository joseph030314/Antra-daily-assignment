using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Required]
        [Column(TypeName = "int")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ReviewText { get; set; }
    }
}
