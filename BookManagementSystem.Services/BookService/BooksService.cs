using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.BookRepository;
using Microsoft.Extensions.Logging;

namespace BookManagementSystem.Services.BookService
{
    public class BooksService(IBookRepository bookRepository, ILogger<BooksService> logger) : IBook
    {
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                return await bookRepository.GetAllBooksAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving all books.");
                return [];
            }
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await bookRepository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
                return book;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error retrieving book with ID {BookId}.", id);
                return null;
            }
        }

        public async Task AddBookAsync(Book book)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(book.Title))
                    throw new ArgumentException("Book title is required.");

                await bookRepository.AddBookAsync(book);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding book with title: {Title}", book.Title);
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                _ = await bookRepository.GetBookByIdAsync(book.BookID) ?? throw new KeyNotFoundException($"Cannot update. Book with ID {book.BookID} not found.");
                await bookRepository.UpdateBookAsync(book);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating book with ID {BookId}.", book.BookID);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                _ = await bookRepository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException($"Cannot delete. Book with ID {id} not found.");
                await bookRepository.DeleteBookAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting book with ID {BookId}.", id);
            }
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    throw new ArgumentException("Search keyword is required.");

                return await bookRepository.SearchBooksAsync(keyword);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error searching books with keyword: {Keyword}", keyword);
                return [];
            }
        }
    }
}