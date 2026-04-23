using Microsoft.AspNetCore.Mvc;
using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/books
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(_context.Books.ToList());
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();

        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();

        return Ok(book);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book updatedBook)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.PublishedDate = updatedBook.PublishedDate;

        _context.SaveChanges();

        return Ok(book);
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();

        _context.Books.Remove(book);
        _context.SaveChanges();

        return Ok();
    }
}