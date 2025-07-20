using BookManagementSystem.Domain.Models;
using BookManagementSystem.UI.Services;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Books;

public partial class BookList : ComponentBase
{
    [Inject] public IBookApiService BookService { get; set; } = default!;

    protected List<Book>? books;
    protected string alertMessage = string.Empty;
    protected bool showForm = false;
    protected Book selectedBook = new();
    protected string searchKeyword = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadBooks();
    }

    protected async Task LoadBooks()
    {
        books = await BookService.GetAllBooksAsync();
    }

    protected void ShowAddForm()
    {
        selectedBook = new Book();
        showForm = true;
        StateHasChanged();
    }

    protected void EditBook(Book book)
    {
        selectedBook = new Book
        {
            BookID = book.BookID,
            Title = book.Title,
            Author = book.Author,
            PublicationYear = book.PublicationYear,
            IsAvailable = book.IsAvailable
        };
        showForm = true;
        StateHasChanged();
    }

    protected async Task DeleteBook(int id)
    {
        await BookService.DeleteBookAsync(id);
        alertMessage = "Book deleted successfully!";
        await LoadBooks();
    }

    protected async Task OnBookSaved()
    {
        alertMessage = "Book saved successfully!";
        showForm = false;
        await LoadBooks();
    }

    protected void CloseModal()
    {
        showForm = false;
    }
    protected async Task SearchBooks()
    {
        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            books = await BookService.SearchBooksAsync(searchKeyword);
        }
    }
    protected async Task ClearSearch()
    {
        searchKeyword = string.Empty;
        await LoadBooks();
    }
}
