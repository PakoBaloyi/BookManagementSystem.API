using BookManagementSystem.Domain.Models;

namespace BookManagementSystem.infrastructure.BookRepository
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string keyword);
    }
}
