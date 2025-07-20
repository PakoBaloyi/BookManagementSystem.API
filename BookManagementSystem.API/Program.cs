using BookManagementSystem.infrastructure.ServiceCollectionExtensions;
using BookManagementSystem.Services.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add custom services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddBookServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy
            .WithOrigins("https://localhost:7255") 
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
