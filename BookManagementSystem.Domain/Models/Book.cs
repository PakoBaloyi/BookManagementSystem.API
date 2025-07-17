namespace BookManagementSystem.Domain.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
