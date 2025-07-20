using BookManagementSystem.Domain.Models;

namespace BookManagementSystem.UI.Services
{
    public interface IBookApiService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<List<Book>> SearchBooksAsync(string keyword);
    }
}
