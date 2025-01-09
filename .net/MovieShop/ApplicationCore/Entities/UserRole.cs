using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class UserRole
    {
        [Required]
        [Column(TypeName = "int")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
