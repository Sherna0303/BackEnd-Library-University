using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibrarySystemWeb.Models.Enum;

namespace LibrarySystemWeb.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; } = default!;

        [MaxLength( 200 )]
        public required string Email { get; set; }

        [MaxLength( 200 )]
        public required string Password { get; set; }

        public RoleEnum Role { get; set; }
    }
}
