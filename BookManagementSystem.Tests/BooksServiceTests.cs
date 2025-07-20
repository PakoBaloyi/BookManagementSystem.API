using BookManagementSystem.Domain.Models;
using BookManagementSystem.infrastructure.BookRepository;
using BookManagementSystem.Services.BookService;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BookManagementSystem.Tests
{
    public class BooksServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepoMock = new();
        private readonly Mock<ILogger<BooksService>> _loggerMock = new();
        private readonly BooksService _booksService;

        public BooksServiceTests()
        {
            _booksService = new BooksService(_bookRepoMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllBooksAsync_ReturnsListOfBooks()
        {
            var expectedBooks = new List<Book>
            {
                    new() { BookID = 1, Title = "Test Book 1" },
                    new() { BookID = 2, Title = "Test Book 2" }
            };

            _bookRepoMock.Setup(repo => repo.GetAllBooksAsync())
                         .ReturnsAsync(expectedBooks);

            var result = await _booksService.GetAllBooksAsync();

            Assert.NotNull(result);
            Assert.Equal(expectedBooks.Count, ((List<Book>)result).Count);
        }

        [Fact]
        public async Task GetBookByIdAsync_ValidId_ReturnsBook()
        {
            var book = new Book { BookID = 1, Title = "How to code" };
            _bookRepoMock.Setup(r => r.GetBookByIdAsync(book.BookID)).ReturnsAsync(book);

            var result = await _booksService.GetBookByIdAsync(book.BookID);

            Assert.NotNull(result);
            Assert.Equal(book.Title, result!.Title);
        }

        [Fact]
        public async Task AddBookAsync_ValidBook_CallsRepository()
        {
            var book = new Book { BookID = 1, Title = "Coding Is Nice" };

            await _booksService.AddBookAsync(book);

            _bookRepoMock.Verify(r => r.AddBookAsync(book), Times.Once);
        }

        [Fact]
        public async Task UpdateBookAsync_ValidBook_CallsRepository()
        {
            var book = new Book { BookID = 1, Title = "Updated" };

            _bookRepoMock.Setup(r => r.GetBookByIdAsync(book.BookID)).ReturnsAsync(book);

            await _booksService.UpdateBookAsync(book);

            _bookRepoMock.Verify(r => r.UpdateBookAsync(book), Times.Once);
        }

        [Fact]
        public async Task DeleteBookAsync_ValidId_CallsRepository()
        {
            var book = new Book { BookID = 3, Title = "To be deleted" };
            _bookRepoMock.Setup(r => r.GetBookByIdAsync(book.BookID)).ReturnsAsync(book);

            await _booksService.DeleteBookAsync(book.BookID);

            _bookRepoMock.Verify(r => r.DeleteBookAsync(book.BookID), Times.Once);
        }

        [Fact]
        public async Task SearchBooksAsync_WithKeyword_ReturnsResults()
        {
            string keyword = "Test";
            var books = new List<Book>
            {
                 new() { BookID = 1, Title = "Test Driving" }
            };

            _bookRepoMock.Setup(r => r.SearchBooksAsync(keyword)).ReturnsAsync(books);

            var result = await _booksService.SearchBooksAsync(keyword);

            Assert.Single(result);
        }
    }
}