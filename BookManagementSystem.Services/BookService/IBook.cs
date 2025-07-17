using BookManagementSystem.Domain.Models;

namespace BookManagementSystem.Services.BookService
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string keyword);
    }
}
