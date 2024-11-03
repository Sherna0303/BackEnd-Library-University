using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystemWeb.Models;

public class Loan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;
    public DateOnly ExpireDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(14));
    public int Student_Id { get; set; }
    public int Book_Id { get; set; }
}