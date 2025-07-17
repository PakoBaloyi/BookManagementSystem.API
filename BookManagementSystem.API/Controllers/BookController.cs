using BookManagementSystem.Domain.Models;
using BookManagementSystem.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBook bookService) : ControllerBase
    {

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            await bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookID }, book);
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] Book updatedBook)
        {
            await bookService.UpdateBookAsync(updatedBook);
            return NoContent();
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await bookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpGet("SearchBooks")]
        public async Task<IActionResult> SearchBooks([FromQuery] string keyword)
        {
            var books = await bookService.SearchBooksAsync(keyword);
            return Ok(books);
        }
    }
}