using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystemWeb.Models;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(200)]
    public string Name { get; set; } = default!;
    [MaxLength(200)]
    public string? Email { get; set; }
    [MaxLength(20)]
    public string? Dni { get; set; }
}