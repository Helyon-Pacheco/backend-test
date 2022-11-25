using BackendTest.Models;

namespace BackendTest.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookByName(string name);
    }
}