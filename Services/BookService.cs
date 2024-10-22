using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Services;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _dbContext;

    public BookService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Book> GetAll()
    {
        return _dbContext.Books.ToList();
    }

    public Book GetById(int id)
    {
        return _dbContext.Books.FirstOrDefault(s => s.Id == id);
    }

    public void Add(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var bookToRemove = _dbContext.Books.FirstOrDefault(s => s.Id == id);
        if (bookToRemove != null)
        {
            _dbContext.Books.Remove(bookToRemove);
            _dbContext.SaveChanges();
        }
    }
}