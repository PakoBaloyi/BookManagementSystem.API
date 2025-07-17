using BookManagementSystem.infrastructure.BookRepository;
using BookManagementSystem.Services.BookService;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagementSystem.Services.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBookServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>(); 
            services.AddScoped<IBook, BooksService>();

            return services;
        }
    }
}