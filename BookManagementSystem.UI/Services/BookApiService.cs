using BookManagementSystem.Domain.Models;
using System.Net.Http.Json;

namespace BookManagementSystem.UI.Services
{
    public class BookApiService(HttpClient http) : IBookApiService
    {
        private readonly HttpClient _http = http;

        public async Task<List<Book>> GetAllBooksAsync() =>
            await _http.GetFromJsonAsync<List<Book>>("api/Book/GetAllBooks") ?? [];

        public async Task<Book?> GetBookByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Book>($"api/Book/GetBookById/{id}");

        public async Task AddBookAsync(Book book) =>
            await _http.PostAsJsonAsync("api/Book/AddBook", book);

        public async Task UpdateBookAsync(Book book) =>
            await _http.PutAsJsonAsync("api/Book/UpdateBook", book);

        public async Task DeleteBookAsync(int id) =>
            await _http.DeleteAsync($"api/Book/DeleteBook/{id}");

        public async Task<List<Book>> SearchBooksAsync(string keyword) =>
            await _http.GetFromJsonAsync<List<Book>>($"api/Book/SearchBooks?keyword={keyword}") ?? [];
    }
}