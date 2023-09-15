namespace LibraryAPI.DTOs
{
    public class BooksGetDetailsResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
