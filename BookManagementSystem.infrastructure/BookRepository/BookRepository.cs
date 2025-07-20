using BookManagementSystem.Domain.Enum;
using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.DataAccess.Interface;

namespace BookManagementSystem.infrastructure.BookRepository
{
    public class BookRepository(IDapperContext dapperContext) : IBookRepository
    {
        private readonly DbConnectionEnum _db = DbConnectionEnum.Default;

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await dapperContext.GetAsync<Book, dynamic>(_db, "[dbo].[GetAvailableBooks]", null);
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var parameters = new { BookID = id };
            return await dapperContext.GetSingleAsync<Book, dynamic>(_db, "[dbo].[GetBookById]", parameters);
        }

        public async Task AddBookAsync(Book book)
        {
            var parameters = new
            {
                book.Title,
                book.Author,
                book.PublicationYear,
                book.IsAvailable
            };
            await dapperContext.ExecuteAsync(_db, "[dbo].[AddBook]", parameters);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var parameters = new
            {
                book.BookID,
                book.Title,
                book.Author,
                book.PublicationYear,
                book.IsAvailable
            };
            await dapperContext.ExecuteAsync(_db, "[dbo].[UpdateBook]", parameters);
        }

        public async Task DeleteBookAsync(int id)
        {
            var parameters = new { BookID = id };
            await dapperContext.ExecuteAsync(_db, "[dbo].[RemoveBook]", parameters);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string keyword)
        {
            var parameters = new { Keyword = keyword };
            return await dapperContext.GetAsync<Book, dynamic>(_db, "[dbo].[SearchBooks]", parameters);
        }
    }
}