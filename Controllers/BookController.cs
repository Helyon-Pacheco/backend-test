using System.Threading.Tasks;
using BackendTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Controllers;

[Route("api/[controller]")]
public class BookController : ControllerBase
{
    public BookController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new System.NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        throw new System.NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> AddOne([FromBody] Book book)
    {
        throw new System.NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ReplaceOne(int id, [FromBody] Book book)
    {
        throw new System.NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOne(int id)
    {
        throw new System.NotImplementedException();
    }
}
