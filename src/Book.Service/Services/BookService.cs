using BackendTest.Interfaces;
using BackendTest.Models;
using BackendTest.Models.Validations;

namespace BackendTest.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, INotifier notifier) : base(notifier)
        {
            _bookRepository = bookRepository;
        }

        public async Task Add(Book book)
        {
            if (!ExecuteValidation(new BookValidation(), book)) return;

            await _bookRepository.Add(book);
        }

        public async Task Remove(Guid id)
        {
            await _bookRepository.Remove(id);
        }

        public async Task Update(Book book)
        {
            if (!ExecuteValidation(new BookValidation(), book)) return;

            await _bookRepository.Update(book);
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }
    }
}