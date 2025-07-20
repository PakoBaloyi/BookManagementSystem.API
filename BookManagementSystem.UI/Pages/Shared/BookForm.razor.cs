using BookManagementSystem.Domain.Models;
using BookManagementSystem.UI.Services;
using Microsoft.AspNetCore.Components;

namespace BookManagementSystem.UI.Pages.Shared;

public partial class BookForm : ComponentBase
{
    [Inject] public IBookApiService BookService { get; set; } = default!;

    [Parameter] public Book Book { get; set; } = new();
    [Parameter] public EventCallback OnSave { get; set; }
    [Parameter] public EventCallback OnCancel { get; set; }

    protected async Task HandleValidSubmit()
    {
        if (Book.BookID == 0)
            await BookService.AddBookAsync(Book);
        else
            await BookService.UpdateBookAsync(Book);

        await OnSave.InvokeAsync();
    }
}
