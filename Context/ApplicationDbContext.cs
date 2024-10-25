using LibrarySystemWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWeb;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Users> Users { get; set; }
}