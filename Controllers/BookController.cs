using System.Threading.Tasks;
using BackendTest.Context;
using BackendTest.Extensions;
using BackendTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/book")]
public class BookController : ControllerBase
{
    private readonly BookApiDbContext _context;
    
    public BookController(BookApiDbContext context) =>
        _context = context;

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _context.Books.ToListAsync();

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(long id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [ClaimsAuthorize("Book", "Create")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [ClaimsAuthorize("Book", "Update")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Book book)
    {
        await _context.Books.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        _context.Books.Update(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [ClaimsAuthorize("Book", "Delete")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
