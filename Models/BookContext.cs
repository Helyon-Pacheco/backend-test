using Microsoft.EntityFrameworkCore;

namespace BackendTest.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Book => Set<Book>();
    }
}