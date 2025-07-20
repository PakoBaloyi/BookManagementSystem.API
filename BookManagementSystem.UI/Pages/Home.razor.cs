using BookManagementSystem.UI.Services;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages
{
    public partial class HomeBase : ComponentBase
    {
        [Inject] public IBookApiService BookService { get; set; } = default!;

        protected int totalBooks;
        protected int availableBooks;
        protected Dictionary<int, int> booksByYear = new();

        protected override async Task OnInitializedAsync()
        {
            var books = await BookService.GetAllBooksAsync();
            totalBooks = books.Count;
            availableBooks = books.Count(b => b.IsAvailable);

            booksByYear = books
                .GroupBy(b => b.PublicationYear)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}