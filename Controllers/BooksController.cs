using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IEnumerable<Book> GetAllBooks()
    {
        return _bookService.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _bookService.GetById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        _bookService.Add(book);
        return Created($"/books/{book.Id}", book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();

        _bookService.Update(book);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}