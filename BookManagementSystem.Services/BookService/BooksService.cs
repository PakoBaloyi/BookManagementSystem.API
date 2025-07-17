using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.BookRepository;

namespace BookManagementSystem.Services.BookService
{
    public class BooksService(IBookRepository bookRepository) : IBook
    {

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await bookRepository.GetAllBooksAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
            return book;
        }

        public async Task AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title is required.");

            await bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _ = await bookRepository.GetBookByIdAsync(book.BookID) ?? throw new KeyNotFoundException($"Cannot update. Book with ID {book.BookID} not found.");
            await bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            _ = await bookRepository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException($"Cannot delete. Book with ID {id} not found.");
            await bookRepository.DeleteBookAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Search keyword is required.");

            return await bookRepository.SearchBooksAsync(keyword);
        }
    }
}