using BackendTest.Models;

namespace BackendTest.Interfaces
{
    public interface IBookService
    {
        Task Add(Book book);
        Task Update(Book book);
        Task Remove(Guid id);
    }
}