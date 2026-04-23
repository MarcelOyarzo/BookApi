using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookApi.Data;
using BookApi.Models;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class QuotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public QuotesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetQuotes()
    {
        return Ok(_context.Quotes.ToList());
    }

    [HttpPost]
    public IActionResult AddQuote(Quote quote)
    {
        _context.Quotes.Add(quote);
        _context.SaveChanges();
        return Ok(quote);
    }

[HttpPut("{id}")]
public IActionResult UpdateQuote(int id, Quote updated)
{
    var quote = _context.Quotes.Find(id);
    if (quote == null) return NotFound();

    quote.Text = updated.Text;
    _context.SaveChanges();
    return Ok(quote);
}
    [HttpDelete("{id}")]
    public IActionResult DeleteQuote(int id)
    {
        var quote = _context.Quotes.Find(id);
        if (quote == null) return NotFound();

        _context.Quotes.Remove(quote);
        _context.SaveChanges();
        return Ok();
    }
}