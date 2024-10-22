using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystemWeb.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(200)] public string Name { get; set; } = default!;

    [MaxLength(200)] public string? Isbn { get; set; }

    [MaxLength(200)] public string? Color { get; set; }
}