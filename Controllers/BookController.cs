using System.Threading.Tasks;
using BackendTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Controllers;

[Authorize]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookContext _context;
    
    public BookController(BookContext context) =>
        _context = context;

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _context.Book.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(long id)
    {
        var book = await _context.Book.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Book book)
    {
        _context.Book.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Book book)
    {
        await _context.Book.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        _context.Book.Update(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Book.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        _context.Book.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
