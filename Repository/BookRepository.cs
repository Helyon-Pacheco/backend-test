using BackendTest.Context;
using BackendTest.Interfaces;
using BackendTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookApiDbContext context) : base(context){}

        public async Task<Book> GetBookByName(string name)
        {
            return await Db.Book.AsNoTracking()
                .Include(c => c.Name)
                .FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}