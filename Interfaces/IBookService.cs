using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Interfaces;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book GetById(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
}