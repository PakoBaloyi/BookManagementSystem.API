namespace BookManagementSystem.API.Controllers
{
    public class BookRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
